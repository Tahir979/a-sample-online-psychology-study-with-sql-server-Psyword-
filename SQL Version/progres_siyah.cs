using System.Windows.Forms;
using System.Drawing;

namespace DEMO
{
    public partial class progres_siyah : ProgressBar
    {
        public progres_siyah()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rec = e.ClipRectangle;

            rec.Width = (int)(rec.Width * ((double)Value / Maximum));
            if (ProgressBarRenderer.IsSupported)
                ProgressBarRenderer.DrawHorizontalBar(e.Graphics, e.ClipRectangle);
            rec.Height = rec.Height;
            e.Graphics.FillRectangle(Brushes.Black, 0, 0, rec.Width, rec.Height);
        }
    }
}
