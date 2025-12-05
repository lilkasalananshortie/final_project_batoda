using System;
using System.Windows.Forms;

namespace BATODA.UI_Displays
{
    public partial class ExceptionForm : Form
    {
        private Timer _fadeIn;
        private Timer _fadeOut;
        private Timer _autoClose;

        public ExceptionForm(string message = "An error has occurred.")
        {
            InitializeComponent();

            Opacity = 0;
            TopMost = true;

            btnClose.Click += (s, e) => StartFadeOut();

   
            _fadeIn = new Timer { Interval = 25 };
            _fadeIn.Tick += (s, e) =>
            {
                Opacity = Math.Min(1.0, Opacity + 0.10);
                if (Opacity >= 1.0) _fadeIn.Stop();
            };

   
            _fadeOut = new Timer { Interval = 25 };
            _fadeOut.Tick += (s, e) =>
            {
                Opacity = Math.Max(0.0, Opacity - 0.10);
                if (Opacity <= 0.0)
                {
                    _fadeOut.Stop();
                    Close();
                }
            };

            _autoClose = new Timer { Interval = 3000 };
            _autoClose.Tick += (s, e) =>
            {
                _autoClose.Stop();
                StartFadeOut();
            };
        }

        private void StartFadeOut()
        {
            _fadeIn.Stop();
            _fadeOut.Start();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            _fadeIn.Start();
            _autoClose.Start();
        }
    }
}
