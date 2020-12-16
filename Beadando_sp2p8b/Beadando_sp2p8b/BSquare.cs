using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beadando_sp2p8b
{
    public class BSquare : Label
    {
        public BSquare()
        {
            AutoSize = false;
            Width = 37;
            Height = 37;
            Paint += BSquare_Paint;
        }

        private void BSquare_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
            
        }

        protected void DrawImage(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, Width, Height);
            
        }
    }
}
