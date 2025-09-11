using System;
using System.Drawing;
using System.Windows.Forms;

namespace BATODA
{
    public static class PlaceHolderTextBox
    {
        public static void SetPlaceholder(TextBox tb, string placeholder)
        {
            // Store placeholder text in Tag
            tb.Tag = placeholder;
            tb.Text = placeholder;
            tb.ForeColor = Color.Gray;

            // When textbox gains focus
            tb.Enter += (s, e) =>
            {
                if (tb.Text == (string)tb.Tag)
                {
                    tb.Text = "";
                    tb.ForeColor = Color.Black;
                }
            };

            // When textbox loses focus
            tb.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    tb.Text = (string)tb.Tag;
                    tb.ForeColor = Color.Gray;
                }
            };
        }

        // Safe getter (returns "" if placeholder is showing)
        public static string GetText(TextBox tb)
        {
            return tb.Text == (string)tb.Tag ? "" : tb.Text;
        }
    }
}
