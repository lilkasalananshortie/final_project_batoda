using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA.UI_Displays
{
    public partial class ToastForm : Form
    {
        private Timer _fadeIn;
        private Timer _fadeOut;
        private Timer _life;
        private Timer _progressTimer;

        private int _durationMs;
        private int _elapsed;

        public ToastForm(string message, Color backColor, Image icon = null, int durationMs = 2000)
        {
            InitializeComponent();

            _durationMs = durationMs;
            BackColor = backColor;
            label1.Text = message;
            label1.ForeColor = Color.White;

            if (icon != null)
            {
                iconTextBox.Image = icon;
                iconTextBox.SizeMode = PictureBoxSizeMode.StretchImage;
                iconTextBox.Visible = true;
            }
            else
            {
                iconTextBox.Visible = false;
            }

            // timers
            _fadeIn = new Timer { Interval = 30 };
            _fadeIn.Tick += (s, e) =>
            {
                Opacity = Math.Min(1.0, Opacity + 0.12);
                if (Opacity >= 1.0) _fadeIn.Stop();
            };

            _fadeOut = new Timer { Interval = 30 };
            _fadeOut.Tick += (s, e) =>
            {
                Opacity = Math.Max(0.0, Opacity - 0.12);
                if (Opacity <= 0.0)
                {
                    _fadeOut.Stop();
                    Close();
                }
            };

            _life = new Timer { Interval = _durationMs };
            _life.Tick += (s, e) =>
            {
                _life.Stop();
                _fadeOut.Start();
            };

            _progressTimer = new Timer { Interval = 30 };
            _progressTimer.Tick += (s, e) =>
            {
                _elapsed += _progressTimer.Interval;
                double percent = (double)_elapsed / _durationMs;
                if (percent > 1) percent = 1;

                int newWidth = (int)(progressBarPanel.Width * percent);
                progressFillPanel.Width = newWidth;

                if (percent >= 1)
                {
                    _progressTimer.Stop();
                }
            };

            // close triggers
            Click += (s, e) => StartFadeOut();
            label1.Click += (s, e) => StartFadeOut();
            iconTextBox.Click += (s, e) => StartFadeOut();
            btnClose.Click += (s, e) => StartFadeOut();

            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            TopMost = true;
            DoubleBuffered = true;

            btnClose.Visible = false; // start hidden
            btnClose.MouseEnter += (s, e) => btnClose.Visible = true;
            btnClose.MouseLeave += (s, e) =>
            {
                if (!ClientRectangle.Contains(PointToClient(Cursor.Position)))
                    btnClose.Visible = false;
            };
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            var screenArea = Screen.PrimaryScreen.WorkingArea;
            Location = new Point(
                screenArea.Right - Width - 20,
                screenArea.Bottom - Height - 20
            );

            Opacity = 0;
            _elapsed = 0;
            progressFillPanel.Width = 0;

            _fadeIn.Start();
            _life.Start();
            _progressTimer.Start();
        }

        private void StartFadeOut()
        {
            _life.Stop();
            _progressTimer.Stop();
            _fadeOut.Start();
        }

        public void SetProgressColor(Color color)
        {
            progressFillPanel.BackColor = color;
            SideColorPanel.BackColor = color;
        }

        // Rounded corners
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int radius = 12;
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(Width - radius, Height - radius, radius, radius, 0, 90);
                path.AddArc(0, Height - radius, radius, radius, 90, 90);
                path.CloseAllFigures();
                Region = new Region(path);
            }
        }

        // Shadow
        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x00020000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
    }
}