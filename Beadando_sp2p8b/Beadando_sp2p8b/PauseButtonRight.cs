using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beadando_sp2p8b
{
    public class PauseButtonRight : Label
    {
        public PauseButtonRight()
        {
            AutoSize = false;
            Width = 5;
            Height = 20;
            Top = 10;
            Left = 22;
            Paint += PauseButton_Paint;
        }

        private void PauseButton_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);

        }

        protected void DrawImage(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.Black), 0, 0, Width, Height);

        }
    }
}
