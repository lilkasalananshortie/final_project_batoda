using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Drawing.Imaging;

namespace BATODA
{
    public class ButtonStyle : Button
    {
        // Fields
        private int borderSize = 0;
        private Color borderColor = Color.Red;
        private int borderRadius = 40;
        private int textPadding = 10;
       

        private Image buttonImage = null;
        private Size imageSize = new Size(24, 24);
        private Point imagePosition = new Point(10, 8); 
        private Color imageColor = Color.Black;
        


        [Category("PARA MA EDIT BUTTON")]
        public int BorderSize
        {
            get
            {
                return borderSize;
            }
            set
            {
                if (borderSize != value)
                {
                    borderSize = value;
                    this.Invalidate();
                }
            }
        }


        [Category("PARA MA EDIT BUTTON")]
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                if (borderColor != value)
                {
                    borderColor = value;
                    this.Invalidate();
                }
            }
        }
        [Category("PARA MA EDIT BUTTON")]
        public int BorderRadius
        {
            get
            {
                return borderRadius;
            }
            set
            {
                int newValue = value <= this.Height ? value : this.Height;
                if (borderRadius != newValue)
                {
                    borderRadius = newValue;
                    this.Invalidate();
                }
            }
        }

        [Category("PARA MA EDIT BUTTON")]
        public Color BackgroundColor
        {
            get { return this.BackColor; }
            set { this.BackColor = value; }
        }

        [Category("PARA MA EDIT BUTTON")]
        public Color TextColor
        {
            get { return this.ForeColor; }
            set { this.ForeColor = value; }
        }

        [Category("PARA MA EDIT BUTTON")]
        public int TextPadding
        {
            get => textPadding;
            set { textPadding = value; Invalidate(); }
        }

        [Category("PARA MA EDIT BUTTON - IMAGE")]
        public Image ButtonImage
        {
            get { return buttonImage; }
            set { buttonImage = value; this.Invalidate(); }
        }

        [Category("PARA MA EDIT BUTTON - IMAGE")]
        public Size ImageSize
        {
            get { return imageSize; }
            set { imageSize = value; this.Invalidate(); }
        }

        [Category("PARA MA EDIT BUTTON - IMAGE")]
        public Point ImagePosition
        {
            get { return imagePosition; }
            set { imagePosition = value; this.Invalidate(); }
        }

        [Category("PARA MA EDIT BUTTON - IMAGE")]
        public Color ImageColor
        {
            get { return imageColor; }
            set { imageColor = value; this.Invalidate(); }
        }
        


        //Constructor
        public ButtonStyle()
        {
            this.FlatStyle = FlatStyle.Flat;

            this.Size = new Size(150, 40);
            this.BackColor = Color.Red;
            this.ForeColor = Color.Black;
            this.Resize += new EventHandler(Button_Resize);
        }


       
        //Methods
        private GraphicsPath GetGraphicsPath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
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
                
                float r = color.R / 255f;
                float gC = color.G / 255f;
                float b = color.B / 255f;

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

                    g.DrawImage(
                        originalImage,
                        new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                        0, 0, originalImage.Width, originalImage.Height,
                        GraphicsUnit.Pixel,
                        attributes
                    );
                }
            }
            return recoloredImage;
        }


        protected override void OnPaint(PaintEventArgs pevent)
        {
            
            base.OnPaint(pevent);

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);
            int smoothSize = borderSize > 0 ? borderSize : 2;

            
            if (buttonImage != null)
            {
                Image img = imageColor != Color.Transparent
                    ? RecolorImage(buttonImage, imageColor)
                    : buttonImage;

               
                int y = (this.Height - imageSize.Height) / 2;
                Rectangle imageRect = new Rectangle(imagePosition.X, y, imageSize.Width, imageSize.Height);

                pevent.Graphics.DrawImage(img, imageRect);
            }

            
            if (borderRadius > 2)
            {
                using (GraphicsPath pathSurface = GetGraphicsPath(rectSurface, borderRadius))
                using (GraphicsPath pathBorder = GetGraphicsPath(rectBorder, borderRadius - borderSize))
                using (Pen penSurface = new Pen(this.Parent?.BackColor ?? this.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    this.Region = new Region(pathSurface);

                    pevent.Graphics.DrawPath(penSurface, pathSurface);

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
            if (this.Parent != null)
            {
                this.Parent.BackColorChanged += Container_BackColorChanged;
            }
        }

        protected override void OnParentChanged(EventArgs e)
        {
            if (this.Parent != null)
            {
                this.Parent.BackColorChanged -= Container_BackColorChanged;
            }
            base.OnParentChanged(e);
            if (this.Parent != null)
            {
                this.Parent.BackColorChanged += Container_BackColorChanged;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.Parent != null)
            {
                this.Parent.BackColorChanged -= Container_BackColorChanged;
            }
            base.Dispose(disposing);
        }

        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ResumeLayout(false);

        }
        private void Button_Resize(object sender, EventArgs e)
        {
            if (borderRadius > this.Height)
            {
                borderRadius = this.Height;
                this.Invalidate();
            }
        }
    }
}
