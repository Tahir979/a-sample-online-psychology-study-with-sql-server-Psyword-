using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEMO
{
    [DefaultEvent("_TextChanged")]

    public partial class UserControl_aa : UserControl
    {
        //Fields
        private Color borderColor_ = Color.White;
        private Color borderFocusColor_ = Color.FromArgb(29, 29, 27);
        private int borderSize_ = 2;
        private bool underlinedStyle_ = false;
        private bool isFocused_ = false;

        private int borderRadius_ = 15;

        Rectangle rectBorder_;

        public UserControl_aa()
        {
            InitializeComponent();
        }

        public event EventHandler _TextChanged;

        //Properties
        public Color BorderColor
        {
            get
            {
                return borderColor_;
            }
            set
            {
                borderColor_ = value;
                this.Invalidate();
            }
        }

        public int BorderSize
        {
            get
            {
                return borderSize_;
            }
            set
            {
                borderSize_ = value;
                this.Invalidate();
            }
        }

        public bool UnderlinedStyle
        {
            get
            {
                return underlinedStyle_;
            }
            set
            {
                underlinedStyle_ = value;
                this.Invalidate();
            }
        }

        public override Color BackColor
        {
            get
            {
                return base.BackColor;
            }

            set
            {
                base.BackColor = value;
                textBox1.BackColor = value;
            }
        }

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }

            set
            {
                base.ForeColor = value;
                textBox1.ForeColor = value;
            }
        }

        public override Font Font
        {
            get
            {
                return base.Font;
            }

            set
            {
                base.Font = value;
                textBox1.Font = value;
            }
        }

        public string Texts
        {
            get
            {
                return textBox1.Text;
            }

            set
            {
                textBox1.Text = value;
            }
        }

        public bool Multiline
        {
            get
            {
                return textBox1.Multiline;
            }

            set
            {
                textBox1.Multiline = value;
            }
        }

        public bool readonly_x
        {
            get
            {
                return textBox1.ReadOnly;
            }

            set
            {
                textBox1.ReadOnly = value;
            }
        }

        //bak, özellikler böyle ekleniyormuş demek lan
        public void select(int x, int y)
        {
            textBox1.Select(x, y);
        }

        //bak, özellikler böyle ekleniyormuş demek lan
        public int SelectionStart
        {
            get
            {
                return textBox1.SelectionStart;
            }

            set
            {
                textBox1.SelectionStart = value;
            }
        }

        public int SelectionLength
        {
            get
            {
                return textBox1.SelectionLength;
            }

            set
            {
                textBox1.SelectionLength = value;
            }
        }

        public Color BorderFocusColor
        {
            get
            {
                return borderFocusColor_;
            }
            set
            {
                borderFocusColor_ = value;
            }
        }

        public bool IsFocused { get => isFocused_; set => isFocused_ = value; }

        //vay vay vay; demek ki bu özellikler böyle ekleniyormuş aq ya; microsoft tepede veriyormuş zaten bunları bize

        public bool AcceptsTab { get; set; }
        public int BorderRadius
        {
            get
            {
                return borderRadius_;
            }
            set
            {
                if (value >= 0)
                {
                    borderRadius_ = value;
                    this.Invalidate();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            if (borderRadius_ > 1)
            {
                var rectBorderSmooth = this.ClientRectangle;

                if (dilandlocate.Default.mod == "d")
                {
                    rectBorder_ = Rectangle.Inflate(rectBorderSmooth, 0, 0);
                }
                else
                {
                    rectBorder_ = Rectangle.Inflate(rectBorderSmooth, -borderSize_, -borderSize_);
                }

                int smoothSize = borderSize_ > 0 ? borderSize_ : 1;

                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius_))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder_, borderRadius_ - borderSize_))
                using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor_, borderSize_))
                {
                    //-Drawing
                    this.Region = new Region(pathBorderSmooth);//Set the rounded region of UserControl
                    if (borderRadius_ > 15) SetTextBoxRoundedRegion();//Set the rounded region of TextBox component
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;
                    if (isFocused_) penBorder.Color = borderFocusColor_;
                    if (underlinedStyle_) //Line Style
                    {
                        //Draw border smoothing
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        //Draw border
                        graph.SmoothingMode = SmoothingMode.None;
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    }
                    else //Normal Style
                    {
                        //Draw border smoothing
                        graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                        //Draw border
                        graph.DrawPath(penBorder, pathBorder);
                    }
                }
            }
            else
            {
                using (Pen penBorder = new Pen(borderColor_, borderSize_))
                {
                    this.Region = new Region(this.ClientRectangle);
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                    if (isFocused_) penBorder.Color = borderFocusColor_;//Set Border color in focus. Otherwise, normal border color
                    if (underlinedStyle_) //Line Style
                        graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    else //Normal Style
                        graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                }
            }
        }

        private void SetTextBoxRoundedRegion()
        {
            GraphicsPath pathTxt;
            if (Multiline)
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderRadius_ - borderSize_);
                textBox1.Region = new Region(pathTxt);
            }
            else
            {
                pathTxt = GetFigurePath(textBox1.ClientRectangle, borderSize_ * 2);
                textBox1.Region = new Region(pathTxt);
            }
            pathTxt.Dispose();
        }

        private GraphicsPath GetFigurePath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        private void UpdateControlHeight()
        {
            if (textBox1.Multiline == false)
            {
                int txtHeight = TextRenderer.MeasureText("Text", this.Font).Height + 1;
                textBox1.Multiline = true;
                textBox1.MinimumSize = new Size(0, txtHeight);
                textBox1.Multiline = false;
                this.Height = textBox1.Height + this.Padding.Top + this.Padding.Bottom;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
                UpdateControlHeight();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (this.DesignMode)
                UpdateControlHeight();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
            {
                _TextChanged.Invoke(sender, e);
            }
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            IsFocused = true;
            this.Invalidate();
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            IsFocused = false;
            this.Invalidate();
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }
    }
}
