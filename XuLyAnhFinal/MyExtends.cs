using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorMine.ColorSpaces
{
    /// <summary>
    /// Bổ sung các hàm phụ vào lớp có sẵn của .NET và thư viện CorlorMine
    /// </summary>
    public static class Utils
    {
        public static Rgb ToColorMine(this Color src)
        {
            return new ColorMine.ColorSpaces.Rgb { R = src.R, G = src.G, B = src.B };
        }

        public static Color ToColor(this Rgb _this)
        {
            return Color.FromArgb((int)_this.R, (int)_this.G, (int)_this.B);
        }
    }
}
