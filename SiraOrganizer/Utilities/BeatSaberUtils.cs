using System;
using System.IO;
using System.Text;

namespace SiraOrganizer.Utilities
{
    public static class BeatSaberUtils
    {
        // Yoinked from ModAssistant | https://github.com/Assistant/ModAssistant/blob/master/ModAssistant/Classes/Utils.cs
        private static readonly char[] _illegalCharacters = new char[]
        {
            '<', '>', ':', '/', '\\', '|', '?', '*', '"',
            '\u0000', '\u0001', '\u0002', '\u0003', '\u0004', '\u0005', '\u0006', '\u0007',
            '\u0008', '\u0009', '\u000a', '\u000b', '\u000c', '\u000d', '\u000e', '\u000d',
            '\u000f', '\u0010', '\u0011', '\u0012', '\u0013', '\u0014', '\u0015', '\u0016',
            '\u0017', '\u0018', '\u0019', '\u001a', '\u001b', '\u001c', '\u001d', '\u001f',
        };

        public static string GetVersion(string path)
        {
            string filename = Path.Combine(path, "Beat Saber_Data", "globalgamemanagers");
            using FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            byte[] file = File.ReadAllBytes(filename);
            byte[] bytes = new byte[32];
            fs.Read(file, 0, Convert.ToInt32(fs.Length));
            fs.Close();
            int index = Encoding.UTF8.GetString(file).IndexOf("public.app-category.games") + 136;
            Array.Copy(file, index, bytes, 0, 32);
            string version = Encoding.UTF8.GetString(bytes).Trim(_illegalCharacters);
            return version;
        }
    }
}