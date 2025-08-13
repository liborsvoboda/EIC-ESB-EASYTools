using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace EASYTools.ReplaceInFilesTool {

    internal class Program {
        internal static string? directoryPath;
        internal static string? fileType;
        internal static string? searchedString;
        internal static string? replaceString;
        internal static bool caseSensitive;
        internal static bool rootDirOnly;
        internal static bool pathIsFile = false;
        internal static int? startLine = null;
        internal static int? endLine = null;


        internal static bool simulation = false;

        private static void Main(string[] args) {

            if (args.Length == 6) { // full functionality
                directoryPath = args[0];
                fileType = args[1];
                searchedString = args[2];
                replaceString = args[3];
                caseSensitive = bool.Parse(args[4]);
                rootDirOnly = bool.Parse(args[5]);
            }
            else if (args.Length == 4) { //One File Only
                directoryPath = args[0];
                searchedString = args[1];
                replaceString = args[2];
                caseSensitive = bool.Parse(args[3]);
            }
            else if (args.Length == 3) { //Removing Line Range
                directoryPath = args[0];
                startLine = int.Parse(args[1]);
                endLine = int.Parse(args[2]);
                rootDirOnly = true;
            }
            else if (simulation) {
                directoryPath = "E:\\Projekty\\MyGitHub\\GroupWare-Solution\\Universal-Backend-Server\\SHOPINGERDATACenter\\DATABASES\\SHOPINGER\\DBModel\\ScaffoldContext.cs";
                startLine = 20;
                endLine = 34;
                rootDirOnly = true;
            }
            else {
                Console.WriteLine();
                Console.WriteLine("This is utility for replacing defined string for newstring IN all files in inserted Directory and his SubDirectories");
                Console.WriteLine("Run App with Write Rights for inserted Folder ");
                Console.WriteLine("Param Description: \"RootFolderPath\" \"fileType\" \"OldString\" \"NewString\" caseSensitive rootDirOnly ");
                Console.WriteLine("For replacing in All files example: tool.exe \"c:\test\" \"*.*\" \"oldstring\" \"newstring\" false false ");
                Console.WriteLine("You can define specific file types by mask on second position examle: tool.exe \"c:\test\" \"*.txt\" \"oldstring\" \"newstring\" true false");
                Console.WriteLine("Replacing in One File: tool.exe \"c:\test\test.txt\" \"oldstring\" \"newstring\" false ");
                Console.WriteLine("Removing Line Range in One File (25-30 lines will be removed): tool.exe \"c:\test\test.txt\" \"25\" \"30\"");
                Console.WriteLine("Simple using. Bye from https://GroupWare-Solution.Eu");
                Console.ReadKey();
                Functions.ApplicationClose();
            }
            

            //Check If is File Only
            try {
                pathIsFile = File.Exists(directoryPath);
            } catch { }

            string[] files = pathIsFile ? new string[] { directoryPath }  : Directory.GetFiles(directoryPath, fileType, rootDirOnly ? SearchOption.TopDirectoryOnly : SearchOption.AllDirectories);
            foreach (string file in files) {
                try {

                    if (startLine == null) { //normal Rewriting
                        string contents = File.ReadAllText(file, Functions.fn_file_detect_encoding(file));

                        contents = contents.Replace(searchedString, replaceString, caseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase);

                        File.SetAttributes(file, FileAttributes.Normal);
                        File.WriteAllText(file, contents, Functions.fn_file_detect_encoding(file));

                    } else { //Line Removing 
                        List<string> newContent = File.ReadAllLines(file, Functions.fn_file_detect_encoding(file)).ToList();
                        newContent.RemoveRange((int)startLine - 1, (int)endLine - (int)startLine + 1);
                                                
                        File.SetAttributes(file, FileAttributes.Normal);
                        File.WriteAllLines(file, newContent, Functions.fn_file_detect_encoding(file));
                    }
                } catch (Exception ex) {
                    Console.WriteLine(ex.StackTrace + Environment.NewLine + ex.Message);
                }
            }
            Console.WriteLine("Replaced text in " + files?.Length + " file(s).");
            Functions.ApplicationClose();

        }
    }
}