using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace ClassLibrary
{
    public class WindowPosition
    {
        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string section, string key, string defaultVal, StringBuilder retVal, int size, string filePath);

        public static string IniPath { get; set; } = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Neocrops",
            "settings.ini"
        );

        static WindowPosition()
        {
            var dir = Path.GetDirectoryName(IniPath);
            if (dir != null)
            {
                Directory.CreateDirectory(dir);
            }
            Debug.WriteLine(dir);

        }

        public static void SaveWindowPosition(Form form)
        {
            Debug.WriteLine($"Save left: {form.Left.ToString()}, Save top: {form.Top.ToString()}");
            WritePrivateProfileString("WindowPosition", "Left", form.Left.ToString(), IniPath);
            WritePrivateProfileString("WindowPosition", "Top", form.Top.ToString(), IniPath);
        }

        public static void LoadWindowPosition(Form form)
        {
            StringBuilder left = new StringBuilder(255);
            StringBuilder top = new StringBuilder(255);

            GetPrivateProfileString("WindowPosition", "Left", "100", left, 255, IniPath);
            GetPrivateProfileString("WindowPosition", "Top", "100", top, 255, IniPath);

            if (int.TryParse(left.ToString(), out int l) && int.TryParse(top.ToString(), out int t))
            {
                Debug.WriteLine($"Load left: {l}, Load top: {t}");
                form.StartPosition = FormStartPosition.Manual;
                form.Left = l;
                form.Top = t;
            }
        }
    }
}
