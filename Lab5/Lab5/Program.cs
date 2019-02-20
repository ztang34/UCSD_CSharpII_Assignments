using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text.RegularExpressions;

namespace Lab5
{
    class Program
    {       
        static void Main(string[] args)
        {
            
            string filePath = @"C:\Users\robin\OneDrive\Desktop\UCSD\CSharp_II\Lesson5\Documents";
            DocumentStatistics stats = new DocumentStatistics();
            ProcessFiles(filePath, stats);
            Console.ReadLine();
            Console.WriteLine();

            foreach(var item in stats.WordCounts)
            {
                Console.WriteLine($"{item.Key}: { item.Value}");
            }
            

            /*
            string s = "The ability to manipulate files is a feature common to most programming languages both present and past.  The term file refers to blocks of data stored on a variety of readable and/or writable media including, but not limited to: hard disks, flash drives, CD/DVD/Blu-ray optical discs and magnetic tape.  File I/O (Input/Output) is such an important feature in computer technology that the popular operating system DOS, from decades past, refers to file manipulation as part of its name Disk Operating System.  C# and the .NET Framework also considers file I/O to be a very important component for creating robust programs.  The System.IO namespace, where most IO types are defined, is part of the mscorlib library assembly so most C# programs will have access to this namespace by default.  All that you need to do is add the following using directive to the top of any code files that will make use of file I/O";
            string[] words = Split(s);

            foreach(string word in words)
            {
                Console.WriteLine(word);
            }*/

            Console.ReadLine();

        }

        private static void ProcessFiles(string filepath, DocumentStatistics stats)
        {
            foreach (string file in Directory.GetFiles(filepath))
            {
                Console.WriteLine($"File {file} is being processed...");
                stats.Documents.Add(file);
                ++stats.DocumentCount;

                using (StreamReader reader = File.OpenText(Path.Combine(filepath, file)))
                {
                    do
                    {
                        string line = reader.ReadLine();
                        string[] words = Split(line);

                        foreach(string word in words)
                        {
                            if(stats.WordCounts.ContainsKey(word.ToLower()))
                            {
                                ++stats.WordCounts[word.ToLower()];
                            }
                            else
                            {
                                stats.WordCounts[word.ToLower()] = 1;
                            }
                        }
                   } while (!reader.EndOfStream);
                }
            }
        }

        private static void SerializeStats(string filepath, DocumentStatistics stats)
        {

        }

        private static string [] Split(string line)
        {
            line = Regex.Replace(line, @"[():;.,]", " ");
            string[] words = Regex.Split(line, @"\s+");
            return words;
        }
    }
}
