using System;
using System.Drawing;
using System.Windows.Forms;

namespace BATODA.UI_Displays
{
    public class ExceptionOverlay : Form
    {
        private ExceptionForm _exceptionForm;

        public ExceptionOverlay(string message, Color backColor)
        {
            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            ShowInTaskbar = false;
            BackColor = Color.FromArgb(120, Color.Gray); // gray overlay
            TopMost = true;
            Bounds = Screen.PrimaryScreen.Bounds;

            // Create the popup
            _exceptionForm = new ExceptionForm(message)
            {
                BackColor = backColor,
                TopMost = true
            };

            // Center on overlay
            _exceptionForm.StartPosition = FormStartPosition.Manual;
            _exceptionForm.Location = new Point(
                (Width - _exceptionForm.Width) / 2,
                (Height - _exceptionForm.Height) / 2
            );

            // Close overlay when popup closes
            _exceptionForm.FormClosed += (s, e) => this.Close();

            Controls.Add(_exceptionForm);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _exceptionForm.Show(); // just show normally; overlay is modal
            _exceptionForm.BringToFront();
        }
    }
}
