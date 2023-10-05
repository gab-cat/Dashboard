using System.Drawing;
using System.Windows.Forms;

public class CustomProgressBar : ProgressBar
{
    public CustomProgressBar()
    {
        SetStyle(ControlStyles.UserPaint, true);
        ForeColor = Color.Blue; // Set the foreground color to blue
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        Rectangle rect = ClientRectangle;
        rect.Width = (int)(rect.Width * ((double)Value / Maximum));
        if (ProgressBarRenderer.IsSupported)
            ProgressBarRenderer.DrawHorizontalBar(e.Graphics, ClientRectangle);
        rect.Height = Height;
        e.Graphics.FillRectangle(new SolidBrush(ForeColor), 0, 0, rect.Width, rect.Height);
    }
}
