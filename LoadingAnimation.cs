using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dashboard
{
    public partial class LoadingAnimation : Form
    {
        public LoadingAnimation()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Define the border color and width
            Color borderColor = Color.Black;

            // Create a rectangle that defines the border area
            Rectangle borderRectangle = new Rectangle(
                new Point(0, 0),
                new Size(ClientSize.Width, ClientSize.Height)
            );

            // Draw the border outline
            ControlPaint.DrawBorder(e.Graphics, borderRectangle, borderColor, ButtonBorderStyle.Solid);
        }
    }
}
