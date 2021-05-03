using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BibliotecaEtec
{
    class IMGRadius : PictureBox
    {
        protected override void OnPaint(PaintEventArgs pe)
        {
            GraphicsPath img = new GraphicsPath();
            img.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new System.Drawing.Region(img);
            base.OnPaint(pe);
        }
    }
}
