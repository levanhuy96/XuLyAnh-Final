using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Dynamic;
using AForge.Imaging;
using AForge.Imaging.Filters;
using ColorMine.ColorSpaces;
using ColorMine.ColorSpaces.Comparisons;

namespace XuLyAnhFinal
{
    /// <summary>
    /// Bộ lọc phân đoạn ảnh dùng thuật toán đồ thị.
    /// Phương pháp sử dụng: Minimun Spanning Tree on undirected-weighted graph.
    /// Thuật toán sử dụng: Krusal's algorithm
    /// Sử dụng thư viện hỗ trợ AForge.NET
    /// </summary>
    public class GraphImageSegmentation: BaseFilter
    {
        private readonly double threshold;
        private readonly int minsize;
        private readonly Random rand = new Random(8080);
        private readonly Dictionary<PixelFormat, PixelFormat> formats;

        private ILogProvider _logger;
        /// <summary>
        /// Hàm khởi tạo
        /// </summary>
        /// <param name="opt">Tham số truyền vào cho bộ lọc</param>
        public GraphImageSegmentation(ILogProvider logger,SegmentOptions opt)
        {
            this.threshold = opt.ThreshHold;
            this.minsize = opt.MinSize;
            _logger = logger;
            formats = new Dictionary<PixelFormat, PixelFormat>
            {
                [PixelFormat.Format24bppRgb] = PixelFormat.Format24bppRgb
            };
        }

        /// <summary>
        /// Hàm tạo màu ngẫn nhiên.
        /// Để fill vào các vùng sau quá trình phân đoạn
        /// </summary>
        /// <returns>Màu ngẫn nhiên</returns>
        private Color RandomColor()
        {
            return Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
        }

        /// <summary>
        /// Hàm kế thừa từ thư viện AForge.NET.
        /// Là hàm chính của bộ lọc.
        /// </summary>
        /// <param name="sourceData">Ảnh nguồn đầu vào</param>
        /// <param name="destinationData">Ảnh đầu ra thể hiện các đoạn sau khi được chia. Các đoạn được tô màu ngẫu nhiên</param>
        protected override void ProcessFilter(UnmanagedImage sourceData, UnmanagedImage destinationData)
        {
            // Có thể cần làm mượt ảnh trước khi tiến hành phân đoạn
            // sourceData = new GaussianBlur().Apply(sourceData);

            // Ở đây chúng ta dùng Color LAB để so sánh độ tương đồng của 2 màu khác nhau trong không gian màu RGB
            // Link tham khảo: 
            // +: http://colormine.org/delta-e-calculator/ 
            // +: http://zschuessler.github.io/DeltaE/learn/
            // Sử dụng lớp so sánh từ thư viện ColorMine

            // Xây dựng đồ thị từ hình ảnh
            // Mỗi đỉnh đồ thị là 1 điểm ảnh, 
            // Các đỉnh lân cận sẽ có cạnh nối với nhau và
            // có trọng số là <độ chênh lệnh> giữa 2 điểm ảnh đó
            // Ở đây sử dụng 4 liền kề
            // Kết quả sẽ có (Width-1)*(Height-1)*2 cạnh của đồ thị
            var comp = new CieDe2000Comparison();
            var items = new QueueItem[(sourceData.Width-1)*(sourceData.Height - 1)* 2];
            var itemCount = 0;
            for (var y = 0; y < sourceData.Height-1; y++)
            {
                for (var x = 0; x < sourceData.Width-1; x++)
                {
                    var color = sourceData.GetPixel(x, y).ToColorMine();
                    items[itemCount++] = new QueueItem(color.Compare(sourceData.GetPixel(x + 1, y).ToColorMine(), comp),
                        new Point(x, y), new Point(x + 1, y));
                    items[itemCount++] = new QueueItem(color.Compare(sourceData.GetPixel(x, y + 1).ToColorMine(), comp),
                        new Point(x, y), new Point(x, y + 1));
                }
            }

            // Xây dựng hàng chờ bao gồm các cạnh sắp xếp theo thứ tự
            // Trọng số không giảm
            // Bắt đầu tiến hành tìm cây khung nhỏ nhất (Minimum spanning tree) bằng thuật toán Krusal.
            Array.Sort(items, new QueueItemComparer());
            var set = new DisjointSet(sourceData.Width, sourceData.Height);
            for (var i = 0; i < itemCount; i++)
            {
                if (items[i].Val > threshold) break;
                set.Join(items[i].U, items[i].V);
            }

            // Tiết hành sát nhập các vùng nhỏ hơn "minSize" với nhau
            // Cho chất lượng ảnh đầu ra tốt hơn
            for (var y = 0; y < sourceData.Height - 1; y++)
            {
                for (var x = 0; x < sourceData.Width - 1; x++)
                {
                    var current = set.Parent(new Point(x, y));
                    int a = set.Parent(new Point(x+1, y)), b = set.Parent(new Point(x, y+1));
                    if (current != a && (set.SizeOf(current) < minsize || set.SizeOf(a) < minsize))
                    {
                        set.Join(current, a);
                    }
                    if (current != b && (set.SizeOf(current) < minsize || set.SizeOf(b) < minsize))
                    {
                        set.Join(current, b);
                    }
                }
            }

            // Bảng màu tô màu các đoạn (super pixels) đã tìm được
            var colorDict = new Dictionary<int, Color>();
            for (var y = 0; y < sourceData.Height; y++)
            {
                for (var x = 0; x < sourceData.Width; x++)
                {
                    var p = set.Parent(new Point(x, y));
                    Color cl;
                    if (!colorDict.ContainsKey(p))
                    {
                        cl = RandomColor();
                        colorDict[p] = cl;
                    }
                    else
                    {
                        cl = colorDict[p];
                    }
                    destinationData.SetPixel(x, y, cl);
                }
            }
        }

        public override Dictionary<PixelFormat, PixelFormat> FormatTranslations => formats;
    }

    // Hàng chờ các đối tượng
    // Bản chất là các cạnh bao gồm Trọng số, 2 đỉnh đầu mút
    internal class QueueItem
    {
        public double Val;
        public Point U, V;

        public QueueItem(double val, Point u, Point v)
        {
            Val = val;
            U = u;
            V = v;
        }
    }

    // Hàm so sánh các đối tượng
    internal class QueueItemComparer : IComparer<QueueItem>
    {
        public int Compare(QueueItem x, QueueItem y)
        {
            return x.Val < y.Val ? -1 : x.Val > y.Val ? 1 : 0;
        }
    }
}
