using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace XuLyAnhFinal
{
    /// <summary>
    /// Lớp disjoint set sử dụng trong thuật toán của Krusal
    /// Để tìm cây khung nhỏ nhất trong đồ thị
    /// </summary>
    internal class DisjointSet
    {
        private int _w, _h;
        private Dictionary<int, Node> par;
        private int num;

        public int Width => _w;
        public int Height => _h;
        public int NumSet => num;
        public DisjointSet(int w, int h)
        {
            _w = w;
            _h = h;
            num = w*h;
            par = new Dictionary<int, Node>();
            for (var i = 0; i < h; i++)
            {
                for (var j = 0; j < w; j++)
                {
                    par[i*w + j] = new Node(1, i*w + j);
                }
            }
        }

        public void Join(int a, int b)
        {
            a = Parent(a);
            b = Parent(b);
            if (a == b) return;
            par[b].Size += par[a].Size;
            par[a] = par[b];
            num--;
        }
        public void Join(Point src, Point dst)
        {
            Join(ToInt(src), ToInt(dst));
        }

        public int Parent(int i) {
            if (par[i].Parent == i)
            {
                return i;
            }
            par[i].Parent = par[Parent(par[i].Parent)].Parent;
            return par[i].Parent;
        }

        public int Parent(Point p)
        {
            return Parent(ToInt(p));
        }

        public int SizeOf(int t)
        {
            return par[t].Size;
        }
        private int ToInt(Point p)
        {
            return p.Y*Width + p.X;
        }

        private Point ToPoint(int i)
        {
            return new Point(i % Width, i / Width);
        }
    }

    class Node
    {
        public int Size { get; set; }
        public int Parent { get; set; }

        public Node(int size, int parent)
        {
            Size = size;
            Parent = parent;
        }
    }
}
