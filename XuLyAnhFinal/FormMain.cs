using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XuLyAnhFinal
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm, ILogProvider
    {
        private Bitmap bitmap;
        public FormMain()
        {
            InitializeComponent();
        }

        private void OpenFile()
        {
            var dlg = new OpenFileDialog { Title = "Chọn hình ảnh", Filter = "Image file (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif" };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            bitmap = new Bitmap(dlg.FileName);

            // Resize input image
            if ((bool)barEditItemResize.EditValue)
            {
                bitmap = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height), PixelFormat.Format24bppRgb);
                if (bitmap.Width > bitmap.Height)
                {
                    bitmap = new AForge.Imaging.Filters.ResizeNearestNeighbor(400, bitmap.Height * 400 / bitmap.Width).Apply(bitmap);
                }
                else
                {
                    bitmap = new AForge.Imaging.Filters.ResizeNearestNeighbor(bitmap.Width * 400 / bitmap.Height, 400).Apply(bitmap);
                }
            }
            // End resize
            picInput.Image = bitmap;
        }

        private void SaveFile()
        {
            if (picResult.Image == null) return;
            var dlg = new SaveFileDialog { Title = "Lưu file ...", Filter = "PNG Image file (*.png)|*.png" };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            picResult.Image.Save(dlg.FileName);
            MessageBox.Show(this, "Lưu file thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ProcessImage()
        {
            try
            {
                if (bitmap == null)
                {
                    throw new Exception("Chưa chọn ảnh nguồn");
                }
                var opt = new SegmentOptions
                {
                    ThreshHold = double.Parse(editNguong.EditValue.ToString()),
                    MinSize = int.Parse(editMinSize.EditValue.ToString())
                };
                if (opt.MinSize < 0) throw new Exception("Minsize phải >= 0");
                if (opt.ThreshHold < 0 || opt.ThreshHold > 50) throw new Exception("Threshold phải lớn hơn hoặc bằng 0 và nhỏ hơn hoặc bằng 50");
                var newBm = bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                        PixelFormat.Format24bppRgb);
                newBm = new AForge.Imaging.Filters.Sharpen().Apply(newBm);
                newBm = new GraphImageSegmentation(this, opt).Apply(newBm);
                picResult.Image = newBm;
                GC.Collect();
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        
        public void Log(string s)
        {
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            editSizingModeZZ.DataSource = new List<string>
            {
                "Bình thường",
                "Đầy đủ",
                "Thu phóng"
            };
            editSizingMode.EditValue = "Đầy đủ";
        }

        private void barEditItem1_EditValueChanged(object sender, EventArgs e)
        {
            var szMode = PictureBoxSizeMode.Normal;
            switch (editSizingMode.EditValue.ToString())
            {
                case "Bình thường":
                    szMode = PictureBoxSizeMode.Normal;
                    break;
                case "Đầy đủ":
                    szMode = PictureBoxSizeMode.Zoom;
                    break;
                case "Thu phóng":
                    szMode = PictureBoxSizeMode.StretchImage;
                    break;
            }
            picInput.SizeMode = picResult.SizeMode = szMode;
        }

        private void btnLoadImage_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFile();
        }

        private void btnProcess_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ProcessImage();
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFile();
        }
    }
}
