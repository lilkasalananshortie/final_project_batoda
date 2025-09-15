using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BATODA.UI_Displays
{
    public static class ToastManager
    {
        private static readonly List<ToastForm> ActiveToasts = new List<ToastForm>();
        private const int Margin = 20;
        private const int Gap = 10;

        private static readonly Color BackgroundColor = Color.FromArgb(45, 45, 48);

        public static void Success(string message, int durationMs = 2000)
        {
            Show(message, Properties.Resources.success, Color.LimeGreen, durationMs);
        }

        public static void Warning(string message, int durationMs = 2000)
        {
            Show(message, Properties.Resources.warning, Color.Orange, durationMs);
        }

        public static void Error(string message, int durationMs = 2000)
        {
            Show(message, Properties.Resources.error, Color.Red, durationMs);
        }

        private static void Show(string message, Image icon, Color progressColor, int durationMs)
        {
            var toast = new ToastForm(message, BackgroundColor, icon, durationMs);
            toast.SetProgressColor(progressColor);
            toast.FormClosed += (s, e) =>
            {
                ActiveToasts.Remove(toast);
                Reposition();
            };

            ActiveToasts.Add(toast);
            Reposition();
            toast.Show();
        }

        private static void Reposition()
        {
            var screenArea = Screen.PrimaryScreen.WorkingArea;
            for (int i = 0; i < ActiveToasts.Count; i++)
            {
                var t = ActiveToasts[i];
                int x = screenArea.Right - t.Width - Margin;
                int y = screenArea.Bottom - Margin - t.Height - i * (t.Height + Gap);
                t.Location = new Point(x, y);
            }
        }
    }
}