using System.Windows.Forms;
using BATODA.UI_Displays;
using System.Drawing;
internal static class ExceptionManager
{
    public static void Show(string message, Color backColor)
    {
        using (Form overlay = new Form())
        {
            overlay.FormBorderStyle = FormBorderStyle.None;
            overlay.StartPosition = FormStartPosition.Manual;
            overlay.Bounds = Screen.PrimaryScreen.Bounds;
            overlay.BackColor = Color.Gray;
            overlay.Opacity = 0.5;
            overlay.TopMost = true;
            overlay.ShowInTaskbar = false;

            overlay.Show();

            using (ExceptionForm exForm = new ExceptionForm(message))
            {
                exForm.BackColor = backColor; // set the color here
                exForm.StartPosition = FormStartPosition.CenterScreen;
                exForm.TopMost = true;

                exForm.ShowDialog(overlay);
            }
        }
    }
}
