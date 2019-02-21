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
            
            string filePath = @"C:\Users\ztang\Desktop\Documents";
            DocumentStatistics stats = new DocumentStatistics();
            ProcessFiles(filePath, stats);
            Console.ReadLine();
            Console.WriteLine();

            foreach(var item in stats.WordCounts)
            {
                Console.WriteLine($"{item.Key}: { item.Value}");
            }

            Console.WriteLine("Start serialization...");
            SerializeStats(filePath, stats);

            /*
            string s = "\n";

            
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
            string file = Path.Combine(filepath, "DocumentStats.txt");
            using (FileStream stream = new FileStream(file, FileMode.CreateNew, FileAccess.ReadWrite))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DocumentStatistics));
                serializer.WriteObject(stream, stats);
            }

        }

        private static string [] Split(string line)
        {
            line = Regex.Replace(line, @"[();.,]", "");
            string[] words = Regex.Split(line, @"\s+");
            return words;
        }
    }
}
