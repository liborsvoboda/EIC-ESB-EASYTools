using System.Reflection;
using System.Text;
using EASYTools.Summary;


class Program {


    private static string startup_path { get; set; } = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    private static List<string>? loadFiles = new();
    private static string summary = "" + Environment.NewLine;

    static void Main(string[] args) {
        CreateSummaryFromPath(startup_path);
        //Console.ReadKey();
    }


    public static bool CreateSummaryFromPath(string startupPath) {
        loadFiles = FileOperations.GetPathFiles(startupPath, "*.md", SearchOption.TopDirectoryOnly);
        if (loadFiles.Any())
        {
            loadFiles.ForEach(mdfile => {
                if (Path.GetFileName(mdfile) == "Summary.md")
                {
                    summary = "- [" + Path.GetFileNameWithoutExtension(mdfile) + "](./" + Path.GetFileName(mdfile) + ")   " + Environment.NewLine + summary;
                }
                else { summary += "- [" + Path.GetFileNameWithoutExtension(mdfile) + "](./" + Path.GetFileName(mdfile) + ")   " + Environment.NewLine; }
            });
            summary += Environment.NewLine + Environment.NewLine + "---    " + Environment.NewLine + "Last Update: " + DateTimeOffset.Now.DateTime.ToString() + Environment.NewLine;

            File.WriteAllText(Path.Combine(startup_path, "Summary.md"), summary, Encoding.UTF8);

            Console.WriteLine("summary.md created");
            return true;
        }
        else
        {
            Console.WriteLine("Any md file founded. Summary.md not created");
            return false;
        }

    } 
}
