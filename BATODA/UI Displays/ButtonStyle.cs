using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Imaging;

namespace BATODA
{
    public class ButtonStyle : Button
    {
       
        private int borderSize = 0;
        private Color borderColor = Color.Red;
        private int borderRadius = 40;

        private Image buttonImage;
        private Size imageSize = new Size(24, 24);
        private Point imagePosition = new Point(10, 0);
        private Color imageColor = Color.Black;


        private int paddingX = 0;
        private int paddingY = 0;
        private int textOffset = 20;

        private Color hoverColor;
        private Color hoverBorderColor;

        private bool isHovered = false;
        private bool isToggled = false;
        private bool isPressed = false;

        private Color mouseDownColor;
        private Color toggleColor;

        
        [Browsable(false)]
        public bool IsToggled
        {
            get => isToggled;
            set { isToggled = value; Invalidate(); }
        }

        [Category("PARA MA EDIT BUTTON")]
        public Color MouseDownColor
        {
            get => mouseDownColor == Color.Empty ? ControlPaint.Dark(hoverColor, 0.2f) : mouseDownColor;
            set { mouseDownColor = value; Invalidate(); }
        }

        [Category("PARA MA EDIT BUTTON")]
        public Color ToggleColor
        {
            get => toggleColor;
            set { toggleColor = value; if (isToggled) Invalidate(); }
        }

        [Category("PARA MA EDIT BUTTON")]
        public Color HoverColor
        {
            get => hoverColor;
            set { hoverColor = value; if (mouseDownColor == Color.Empty) Invalidate(); }
        }

        [Category("PARA MA EDIT BUTTON")]
        public Color HoverBorderColor
        {
            get => hoverBorderColor;
            set { hoverBorderColor = value; Invalidate(); }
        }

        [Category("PARA MA EDIT BUTTON")]
        public int BorderSize
        {
            get => borderSize;
            set { borderSize = value; Invalidate(); }
        }

        [Category("PARA MA EDIT BUTTON")]
        public Color BorderColor
        {
            get => borderColor;
            set { borderColor = value; Invalidate(); }
        }

        [Category("PARA MA EDIT BUTTON")]
        public int BorderRadius
        {
            get => borderRadius;
            set { borderRadius = Math.Min(value, Height); Invalidate(); }
        }

        [Category("PARA MA EDIT BUTTON")]
        public Color BackgroundColor
        {
            get => BackColor;
            set => BackColor = value;
        }

        [Category("PARA MA EDIT BUTTON")]
        public Color TextColor
        {
            get => ForeColor;
            set => ForeColor = value;
        }

        [Category("PARA MA EDIT BUTTON")]
        public int PaddingX
        {
            get => paddingX;
            set { paddingX = value; Invalidate(); }
        }

        [Category("PARA MA EDIT BUTTON")]
        public int PaddingY
        {
            get => paddingY;
            set { paddingY = value; Invalidate(); }
        }

        [Category("PARA MA EDIT BUTTON")]
        public int TextOffset
        {
            get => textOffset;
            set { textOffset = value; Invalidate(); }
        }

        [Category("PARA MA EDIT BUTTON - IMAGE")]
        public Image ButtonImage
        {
            get => buttonImage;
            set { buttonImage = value; Invalidate(); }
        }

        [Category("PARA MA EDIT BUTTON - IMAGE")]
        public Size ImageSize
        {
            get => imageSize;
            set { imageSize = value; Invalidate(); }
        }

        [Category("PARA MA EDIT BUTTON - IMAGE")]
        public Point ImagePosition
        {
            get => imagePosition;
            set { imagePosition = value; Invalidate(); }
        }

        [Category("PARA MA EDIT BUTTON - IMAGE")]
        public Color ImageColor
        {
            get => imageColor;
            set { imageColor = value; Invalidate(); }
        }

        // Constructor
        public ButtonStyle()
        {
            FlatStyle = FlatStyle.Standard;
            Size = new Size(150, 40);
            BackColor = Color.WhiteSmoke;
            ForeColor = Color.WhiteSmoke;

            Resize += (s, e) => { if (borderRadius > Height) borderRadius = Height; };
            MouseEnter += (s, e) => { isHovered = true; Invalidate(); };
            MouseLeave += (s, e) => { isHovered = false; Invalidate(); };
            MouseDown += (s, e) => { isPressed = true; Invalidate(); };
            MouseUp += (s, e) => { isPressed = false; Invalidate(); };
        }

        private GraphicsPath GetGraphicsPath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Right - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Right - radius, rect.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();
            return path;
        }

        private Image RecolorImage(Image originalImage, Color color)
        {
            if (originalImage == null)
                return null;

            Bitmap recoloredImage = new Bitmap(originalImage.Width, originalImage.Height);
            using (Graphics g = Graphics.FromImage(recoloredImage))
            {
                float r = color.R / 255f, gC = color.G / 255f, b = color.B / 255f;
                ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                {
                    new float[] {r, 0, 0, 0, 0},
                    new float[] {0, gC, 0, 0, 0},
                    new float[] {0, 0, b, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
                });

                using (ImageAttributes attributes = new ImageAttributes())
                {
                    attributes.SetColorMatrix(colorMatrix);
                    g.DrawImage(originalImage, new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                        0, 0, originalImage.Width, originalImage.Height, GraphicsUnit.Pixel, attributes);
                }
            }
            return recoloredImage;
        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            Rectangle rectSurface = ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = borderSize > 0 ? borderSize : 2;

            Color currentBack = isPressed && isToggled
                ? ControlPaint.Dark(toggleColor)
                : isPressed
                    ? mouseDownColor
                    : isToggled
                        ? toggleColor
                        : isHovered
                            ? hoverColor
                            : BackColor;

            Graphics g = pevent.Graphics;
            using (SolidBrush brush = new SolidBrush(currentBack))
                g.FillRectangle(brush, rectSurface);

            if (buttonImage != null)
            {
                
                Image img = imageColor != Color.Transparent ? RecolorImage(buttonImage, imageColor) : buttonImage;
                int imgX = paddingX + imagePosition.X;
                int imgY = (Height - imageSize.Height) / 2 + imagePosition.Y + paddingY;

                Rectangle imageRect = new Rectangle(imgX, imgY, imageSize.Width, imageSize.Height);
                g.DrawImage(img, imageRect);

                
                Rectangle textRect = new Rectangle(
                    imageRect.Right + textOffset, paddingY,
                    Width - imageRect.Right - textOffset - paddingX,
                    Height - paddingY * 2
                );

                TextRenderer.DrawText(g, Text, Font, textRect, ForeColor,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }
            else
            {
                
                Rectangle textRect = new Rectangle(
                    paddingX, paddingY,
                    Width - paddingX * 2,
                    Height - paddingY * 2
                );

                TextRenderer.DrawText(g, Text, Font, textRect, ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }




            if (borderRadius > 2)
            {
                using (GraphicsPath pathSurface = GetGraphicsPath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetGraphicsPath(rectBorder, borderRadius - borderSize))
                using (Pen penSurface = new Pen(this.Parent?.BackColor ?? this.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                    // Button surface
                    this.Region = new Region(pathSurface);

                    // Draw surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    // Button border
                    if (borderSize >= 1)
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else
            {
                pevent.Graphics.SmoothingMode = SmoothingMode.None;
                this.Region = new Region(rectSurface);

                if (borderSize >= 1)
                {
                    using (Pen penBorder = new Pen(borderColor, borderSize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            if (Parent != null)
                Parent.BackColorChanged += Container_BackColorChanged;
        }

        protected override void OnParentChanged(EventArgs e)
        {
            if (Parent != null)
                Parent.BackColorChanged -= Container_BackColorChanged;
            base.OnParentChanged(e);
            if (Parent != null)
                Parent.BackColorChanged += Container_BackColorChanged;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && Parent != null)
                Parent.BackColorChanged -= Container_BackColorChanged;
            base.Dispose(disposing);
        }

        private void Container_BackColorChanged(object sender, EventArgs e) => Invalidate();
    }
}
