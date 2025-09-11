using System;
using System.Drawing;
using System.Windows.Forms;

namespace BATODA
{
    public static class DisplayClass
    {
        private static Panel _mainPanel;
        private static Panel _miniPanel;

        // ========= Placeholder Methods: Text Box -  Combo Box =========
        public static void SetPlaceholder(TextBox tb, string placeholder)
        {
            tb.Tag = placeholder;
            tb.Text = placeholder;
            tb.ForeColor = Color.Gray;

            tb.Enter += (s, e) =>
            {
                if (tb.Text == (string)tb.Tag)
                {
                    tb.Text = "";
                    tb.ForeColor = Color.Black;
                }
            };

            tb.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(tb.Text))
                {
                    tb.Text = (string)tb.Tag;
                    tb.ForeColor = Color.Gray;
                }
            };
        }
        public static void SetPlaceholder(ComboBox cb, string placeholder, params string[] items)
        {
            cb.DropDownStyle = ComboBoxStyle.DropDownList;
            cb.Tag = placeholder;

            cb.Items.Clear();
            cb.Items.AddRange(items);

            cb.SelectedIndex = -1;
            cb.DrawMode = DrawMode.OwnerDrawFixed;

            cb.DrawItem += (s, e) =>
            {
                e.DrawBackground();

                string text;
                Color color;

                if (e.Index < 0 && cb.SelectedIndex == -1)
                {
                    text = (string)cb.Tag;   
                    color = Color.Gray;
                }
                else
                {
                    text = cb.Items[e.Index].ToString();
                    color = Color.Black;
                }

                using (Brush b = new SolidBrush(color))
                {
                    e.Graphics.DrawString(text, cb.Font, b, e.Bounds);
                }

                e.DrawFocusRectangle();
            };
        }
        public static void ClearInputs(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox tb)
                {
                    
                    if (tb.Tag is string placeholder)
                    {
                        tb.Text = placeholder;
                        tb.ForeColor = Color.Gray;
                    }
                    else
                    {
                        tb.Clear();
                    }
                }
                else if (ctrl is ComboBox cb)
                {
                   
                    if (cb.Tag is string placeholder)
                    {
                        cb.SelectedIndex = -1;
                        cb.Refresh(); 
                    }
                    else
                    {
                        cb.SelectedIndex = -1;
                    }
                }

               
                if (ctrl.HasChildren)
                {
                    ClearInputs(ctrl);
                }
            }
        }






        // ========= Display Methods =========
        public static void SetMainPanel(Panel panel)
        {
            _mainPanel = panel;
        }

        public static void SetMiniPanel(Panel panel)
        {
            _miniPanel = panel;
        }

        public static void ShowMain(UserControl uc)
        {
            if (_mainPanel == null)
                throw new InvalidOperationException("Main display panel not set. Call SetMainPanel first.");

            uc.Dock = DockStyle.Fill;
            _mainPanel.Controls.Clear();
            _mainPanel.Controls.Add(uc);
        }

        public static void ShowMini(UserControl uc)
        {
            if (_miniPanel == null)
                throw new InvalidOperationException("Mini display panel not set. Call SetMiniPanel first.");

            uc.Dock = DockStyle.Fill;
            _miniPanel.Controls.Clear();
            _miniPanel.Controls.Add(uc);
        }
    }
}
