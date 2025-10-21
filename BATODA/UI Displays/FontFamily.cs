using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BATODA.UI_Displays
{
    public static class FontFamily
    {
        private static System.Drawing.FontFamily _montserratFamily;
        private static PrivateFontCollection _privateFonts;
        private static Dictionary<FontStyle, Font> _fontCache = new Dictionary<FontStyle, Font>();

        public static void Initialize()
        {
            _privateFonts = new PrivateFontCollection();

            string resourceName = "BATODA.UI_Displays.Fonts.Montserrat-Regular.ttf";
            var fontStream = typeof(FontFamily).Assembly.GetManifestResourceStream(resourceName);

            if (fontStream != null)
            {
                byte[] fontData = new byte[fontStream.Length];
                fontStream.Read(fontData, 0, fontData.Length);

                IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
                Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

                _privateFonts.AddMemoryFont(fontPtr, fontData.Length);
                Marshal.FreeCoTaskMem(fontPtr);

                _montserratFamily = _privateFonts.Families[0];
            }
            else
            {
                _montserratFamily = new System.Drawing.FontFamily("Segoe UI");
            }
        }

        public static Font GetFont(float size = 12f, FontStyle style = FontStyle.Regular)
        {
            if (_montserratFamily == null)
                return new Font("Segoe UI", size, style);

            if (_fontCache.TryGetValue(style, out Font cachedFont))
                return cachedFont;

            Font newFont = new Font(_montserratFamily, size, style);
            _fontCache[style] = newFont;
            return newFont;
        }

        public static void ApplyToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control.Font != null)
                    control.Font = GetFont(control.Font.Size, control.Font.Style);

                // Hook dynamically added child controls
                control.ControlAdded -= Control_ControlAdded;
                control.ControlAdded += Control_ControlAdded;

                if (control.HasChildren)
                    ApplyToControls(control.Controls);
            }
        }

        private static void Control_ControlAdded(object sender, ControlEventArgs e)
        {
            ApplyToControls(new Control.ControlCollection(e.Control.Parent) { e.Control });
        }

        public static void ApplyToForm(Form form)
        {
            form.Font = GetFont();
            ApplyToControls(form.Controls);

           
            form.ControlAdded -= Control_ControlAdded;
            form.ControlAdded += Control_ControlAdded;
        }
    }
}
