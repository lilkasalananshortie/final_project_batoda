using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BATODA.UI_Displays
{
    public static class MontserratFont
    {
        private static System.Drawing.FontFamily _montserratFamily;
        private static PrivateFontCollection _privateFonts;
        private static readonly Dictionary<FontStyle, Font> _fontCache = new Dictionary<FontStyle, Font>();

        public static void Initialize()
        {
            if (_privateFonts != null)
                return;

            _privateFonts = new PrivateFontCollection();

            string resourceName = "BATODA.Fonts.Montserrat-Normal.ttf";
            using (var fontStream = typeof(MontserratFont).Assembly.GetManifestResourceStream(resourceName))
            {
                if (fontStream == null)
                {
                    _montserratFamily = new System.Drawing.FontFamily("Segoe UI");
                    return;
                }

                byte[] fontData = new byte[fontStream.Length];
                fontStream.Read(fontData, 0, fontData.Length);

                IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
                try
                {
                    Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
                    _privateFonts.AddMemoryFont(fontPtr, fontData.Length);
                }
                finally
                {
                    Marshal.FreeCoTaskMem(fontPtr);
                }

                _montserratFamily = _privateFonts.Families.Length > 0
                    ? _privateFonts.Families[0]
                    : new System.Drawing.FontFamily("Segoe UI");
            }
        }

        public static Font GetFont(float size = 10.5f, FontStyle style = FontStyle.Regular)
        {
            if (_montserratFamily == null)
                return new Font("Segoe UI", size, style);

            Font cachedFont;
            if (_fontCache.TryGetValue(style, out cachedFont))
                return cachedFont;

            
            float adjustedSize = size * 1f;
            Font newFont = new Font(_montserratFamily, adjustedSize, style);
            _fontCache[style] = newFont;
            return newFont;
        }

        public static void ApplyToForm(Form form)
        {
            if (form == null) return;

            form.SuspendLayout();

            FreezeControlLayout(form.Controls);
            form.Font = GetFont();
            ApplyToControls(form.Controls);

            form.ControlAdded -= Control_ControlAdded;
            form.ControlAdded += Control_ControlAdded;

            form.ResumeLayout(false);
        }
        public static void ApplyToUserControl(UserControl control)
        {
            if (control == null) return;

            control.SuspendLayout();

            FreezeControlLayout(control.Controls);
            control.Font = GetFont();
            ApplyToControls(control.Controls);

            control.ControlAdded -= Control_ControlAdded;
            control.ControlAdded += Control_ControlAdded;

            control.ResumeLayout(false);
        }


        private static void ApplyToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.Font = GetFont(control.Font.Size, control.Font.Style);

                if (control.HasChildren)
                    ApplyToControls(control.Controls);
            }
        }

        private static void Control_ControlAdded(object sender, ControlEventArgs e)
        {
            if (e.Control == null) return;

            e.Control.Font = GetFont(e.Control.Font.Size, e.Control.Font.Style);

            if (e.Control.HasChildren)
                ApplyToControls(e.Control.Controls);
        }

        //Prevents layout changes when changing fonts
        private static void FreezeControlLayout(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                control.AutoSize = false;

               
                Rectangle bounds = control.Bounds;

                if (control.HasChildren)
                    FreezeControlLayout(control.Controls);

               
                control.Bounds = bounds;
            }
        }
    }
}
