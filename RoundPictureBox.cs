using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class RoundPictureBox : PictureBox
{
    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        // Create a GraphicsPath to draw the image in a round shape
        using (GraphicsPath path = new GraphicsPath())
        {
            path.AddEllipse(new Rectangle(0, 0, 68, 68));
            this.Region = new Region(path);
        }
    }
}