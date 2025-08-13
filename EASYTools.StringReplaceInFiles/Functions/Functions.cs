using System;
using System.IO;
using System.Text;

namespace EASYTools.ReplaceInFilesTool {

    internal class Functions {

        public static Encoding fn_file_detect_encoding(string FileName) {
            string enc = "";
            if (File.Exists(FileName)) {
                FileStream filein = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                if ((filein.CanSeek)) {
                    byte[] bom = new byte[5];
                    filein.Read(bom, 0, 4);
                    if ((((bom[0] == 0xEF) && (bom[1] == 0xBB) && (bom[2] == 0xBF)) || ((bom[0] == 0xFF) && (bom[1] == 0xFE)) || ((bom[0] == 0xFE) && (bom[1] == 0xFF)) || ((bom[0] == 0x0) && (bom[1] == 0x0) && (bom[2] == 0xFE) && (bom[3] == 0xFF))))
                        enc = "Unicode";
                    else
                        enc = "ASCII";
                    filein.Seek(0, SeekOrigin.Begin);
                }
                filein.Close();
            }
            if (enc == "Unicode")
                return Encoding.UTF8;
            else
                return Encoding.Default;
        }

        public static void ApplicationClose() {
            Environment.Exit(0);
        }
    }
}