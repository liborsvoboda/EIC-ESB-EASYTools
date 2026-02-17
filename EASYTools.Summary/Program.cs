using System.Reflection;
using System.Text;
using EASYTools.Summary;


class Program {


    private static string startup_path { get; set; } = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    static void Main(string[] args) {
        GlobalFunctions.CreateSummaryFromPath(startup_path);
        //Console.ReadKey();
    }


    
}


namespace EASYTools.Summary {
    public static class GlobalFunctions {


        public static bool CreateSummaryFromPath(string startupPath) {
            List<string>? loadFiles = new();
            string summary = "" + Environment.NewLine;

            loadFiles = FileOperations.GetPathFiles(startupPath, "*.md", SearchOption.TopDirectoryOnly);
            if (loadFiles.Any()) {
                loadFiles.ForEach(mdfile => {
                    if (Path.GetFileName(mdfile) == "Summary.md") {
                        summary = "- [" + Path.GetFileNameWithoutExtension(mdfile) + "](./" + Path.GetFileName(mdfile) + ")   " + Environment.NewLine + summary;
                    } else { summary += "- [" + Path.GetFileNameWithoutExtension(mdfile) + "](./" + Path.GetFileName(mdfile) + ")   " + Environment.NewLine; }
                });
                summary += Environment.NewLine + Environment.NewLine + "---    " + Environment.NewLine + "Last Update: " + DateTimeOffset.Now.DateTime.ToString() + Environment.NewLine;

                File.WriteAllText(Path.Combine(startupPath, "Summary.md"), summary, Encoding.UTF8);

                Console.WriteLine("summary.md created");
                return true;
            } else {
                Console.WriteLine("Any md file founded. Summary.md not created");
                return false;
            }

        }


    }
}