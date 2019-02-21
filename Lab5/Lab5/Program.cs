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
            
            string filePath = @"C:\Users\robin\source\repos\UCSD_CSharpII_Assignments\Lab5\Lab5\Documents";
            DocumentStatistics stats = new DocumentStatistics();
            ProcessFiles(filePath, stats);
            Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Start serialization...");
            SerializeStats(filePath, stats);
            Console.WriteLine($"Serialization completes; Document statistics is written to {Path.Combine(filePath, "stats.json")}");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();

        }

        private static void ProcessFiles(string filepath, DocumentStatistics stats)
        {
            foreach (string file in Directory.GetFiles(filepath,"*.txt")) //only looking for text files
            {
                Console.WriteLine($"File {file} is being processed...");
                stats.Documents.Add(file);
                ++stats.DocumentCount;
                
                try
                {
                    using (StreamReader reader = File.OpenText(Path.Combine(filepath, file)))
                    {
                        do
                        {
                            string line = reader.ReadLine();
                            string[] words = Split(line);

                            foreach (string word in words)
                            {
                                if (stats.WordCounts.ContainsKey(word.ToLower()))
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
                catch(Exception ex)
                {
                    Console.WriteLine($"Cannot read file {file}:" + ex.Message);
                }
                
            }
        }

        private static void SerializeStats(string filepath, DocumentStatistics stats)
        {
            string file = Path.Combine(filepath, "stats.json");

            try
            {
                using (FileStream stream = new FileStream(file, FileMode.Create, FileAccess.ReadWrite))
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DocumentStatistics));
                    serializer.WriteObject(stream, stats);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Cannot write to file stats.json:" + ex.Message);
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
