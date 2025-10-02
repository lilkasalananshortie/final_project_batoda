using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace BATODA
{
    public static class DisplayClass
    {
        private static Panel _mainPanel;
        private static Panel _miniPanel;

        //ButtonColorManager
        private static List<ButtonStyle> _buttons = new List<ButtonStyle>();
        private static Color _defaultColor = Color.FromArgb(105, 100, 100);
        private static Color _activeColor = Color.FromArgb(175, 40, 40);

        // ========= Placeholder Methods: Text Box -  Combo Box  - Label =========
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

       




        // ========= Display Methods - main - mini =========
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


        //========= hover method ===========
        public static void AttachHoverEffect(Button button, Color enterColor, Color leaveColor)
        {
            button.MouseEnter += (sender, e) =>
            {
                button.BackColor = enterColor;
            };

            button.MouseLeave += (sender, e) =>
            {
                button.BackColor = leaveColor;
            };
        }

        public static void SetButtonToggleColor(Button btn, Color toggleColor, Color defaultColor, Color hoverColor)
        {
            bool isToggled = false;

            btn.Click += (s, e) =>
            {
                isToggled = !isToggled;
                btn.BackColor = isToggled ? toggleColor : defaultColor;
            };

            btn.MouseEnter += (s, e) =>
            {
                if (!isToggled)
                    btn.BackColor = hoverColor;
            };

            btn.MouseLeave += (s, e) =>
            {
                if (!isToggled)
                    btn.BackColor = defaultColor;
            };
        }


        

        public static void Register(params ButtonStyle[] buttons)
        {
            _buttons.AddRange(buttons);
        }

        public static void SetActive(ButtonStyle activeButton)
        {
            foreach (var btn in _buttons)
            {
                btn.ImageColor = _defaultColor;
                btn.TextColor = _defaultColor;
            }

            activeButton.ImageColor = _activeColor;
            activeButton.TextColor = _activeColor;
        }
    }
}

