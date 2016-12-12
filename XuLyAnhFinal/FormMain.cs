using System;
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
    public partial class FormMain : Form, ILogProvider
    {
        private Bitmap bitmap;
        public FormMain()
        {
            InitializeComponent();
            cbImageMode.SelectedIndex = 0;
        }

        private void picInput_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog { Title = "Chọn hình ảnh", Filter = "Image file (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif" };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            bitmap = new Bitmap(dlg.FileName);
            picInput.Image = (Bitmap) bitmap.Clone();
        }
        

        private void btnProccess_Click(object sender, EventArgs e)
        {
            try
            {
                if (bitmap == null)
                {
                    throw new Exception("Chưa chọn ảnh nguồn");
                }
                var opt = new SegmentOptions
                {
                    ThreshHold = Double.Parse(txtThreshold.Text),
                    MinSize = int.Parse(txtN.Text)
                };
                if (opt.MinSize<0) throw new Exception("Minsize phải >= 0");
                if (opt.ThreshHold<0 || opt.ThreshHold > 50) throw new Exception("Threshold phải lớn hơn hoặc bằng 0 và nhỏ hơn hoặc bằng 50");
                var newBm =
                    new GraphImageSegmentation(this,opt).Apply(bitmap.Clone(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                        PixelFormat.Format24bppRgb));
                picResult.Image = newBm;
                GC.Collect();
            }
            catch (Exception exc)
            {
                MessageBox.Show(this, exc.Message, "Có lỗi xảy ra", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void cbImageMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            var szMode = PictureBoxSizeMode.Normal;
            switch (cbImageMode.SelectedIndex)
            {
                case 0:
                    szMode = PictureBoxSizeMode.Normal;
                    break;
                case 1:
                    szMode = PictureBoxSizeMode.Zoom;
                    break;
                case 2:
                    szMode = PictureBoxSizeMode.StretchImage;
                    break;
            }
            picInput.SizeMode = picResult.SizeMode = szMode;
        }

        private void btnSaveResult_Click(object sender, EventArgs e)
        {
            if (picResult.Image == null) return;
            var dlg = new SaveFileDialog { Title = "Lưu file ...", Filter = "PNG Image file (*.png)|*.png" };
            if (dlg.ShowDialog() != DialogResult.OK) return;
            picResult.Image.Save(dlg.FileName);
            MessageBox.Show(this, "Lưu file thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void Log(string s)
        {
        }
    }
}
