using System;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Exercises;

namespace CodeExcerciseDataImportOutput
{
    class Program
    {
        private static async Task Main(string[] args)
        {

            Console.WriteLine("--------------------------------");
            Console.WriteLine("Welcome to Code Exercises");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("A simple console app where we practice in order to keep our skills sharp.\n");


            Console.WriteLine("ready to get stated? (y/n)");
            var input = Console.ReadLine();

            if (input?.ToLower() != "y")
            {
                Console.WriteLine("Goodbye!");
                return;
            } else
            {

                int mainChoice = mainMenuChoices();



                Console.WriteLine("What exercise do you want to run?");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Two Sums");
                Console.WriteLine("2. Async Examples");
                Console.WriteLine("3. Binary tree comparer (coming soon!)");
                Console.WriteLine("4. Binary Search (coming soon!)");
                Console.WriteLine("5. Web sockets (coming soon!)");
                Console.WriteLine("6. LINQ (coming soon!)");
                Console.WriteLine("Enter the number of the exercise you want to run:");
                var exercise = Console.ReadLine();
                switch (exercise)
                {
                    case "0":
                        Console.WriteLine("Goodbye! See you next time!\n");
                        break;
                    case "1":
                        var twoSums = new TwoSums();
                        break;
                    case "2":
                        await new AsyncExamples().RunConcurrentExampleAsync(CancellationToken.None);
                        break;
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                        Console.WriteLine("Coming soon!\n");
                        break;
                    default:
                        Console.WriteLine("Invalid exercise number. Please try again.");
                        break;
                }


            }

            //Console.WriteLine("This exercise will read a file and output two files based on field count.");
            //FileConverter();
        }

        private static int mainMenuChoices()
        {
            while (true)
            { 
                Console.WriteLine("What topic would you like to try?");
                Console.WriteLine("0. Back");
                Console.WriteLine("1. Arrays & String Manipulation (25 problems)");
                Console.WriteLine("2. Linked Lists (10 problems)");
                Console.WriteLine("3. Stacks & Queues (10 problems)");
                Console.WriteLine("4. Trees & Graphs (15 problems)");
                Console.WriteLine("5. Hash Tables & Sets (8 problems)");
                Console.WriteLine("6. Sorting & Searching (8 problems)");
                Console.WriteLine("7. Dynamic Programming (10 problems)");
                Console.WriteLine("8. Async/Await & Tasks (8 problems)");
                Console.WriteLine("9. Advanced Algorithms (6 problems)");
                Console.WriteLine("10. How to Use This List");
                Console.WriteLine("Enter the number of the exercise you want to run:");
                
                var input = Console.ReadLine();

                if (int.TryParse(input, out int topic) && topic >= 0 && topic <= 10)
                {
                    return topic;
                }
            
                Console.WriteLine("Invalid topic, Please Choose a topic 1-10, or 0 to go back.");
            }
        }


        public static void TwoSums()
        {
            
                Console.WriteLine("Great! Let's get started with Two Sums!\n");
                var twoSums = new TwoSums();

                try{
                    var result = twoSums.FindTwoSumForEach(new int[] { 2, 7, 11, 15 }, 9);
                    Console.WriteLine($"Indices found: [{result[0]}, {result[1]}]");

                    var result3 = twoSums.FindTwoSumFor(new int[] {2,5,3,6}, 8);
                    Console.WriteLine($"Found: [{result[0]}, {result[1]}]");

                } 
                catch (NotImplementedException)
                {
                    Console.WriteLine("FindTwoSum method is not yet implemented.");
                }
        }

        public static void FileConverter()
        {
            string fileLocation;
            int numberOfFields;
            string[] fileData = null;
            string delimiter;
            ConsoleKeyInfo cki;



            int count = 0;
            do
            {
                if (count > 0) {
                    Console.WriteLine("\r\nFile does not exist OR you do not sufficant permissions.");
                    Console.WriteLine("\rPlease enter a valid file path:");
                }
                count++;
                Console.WriteLine("\r\nWhere is the file located?");
                fileLocation = Console.ReadLine();
            } while (!File.Exists(fileLocation));

            Console.WriteLine("\r\nIs the file format CSV (comma-seperated values) or TSV (tab seperated values)?");
            Console.WriteLine("Enter 1 for CSV Or Enter 2 for TSV:");
            delimiter = (Convert.ToInt32(Console.ReadLine()) == 1) ? "," : "\t";

            Console.WriteLine("\r\nHow many fields should each record contain?");
            numberOfFields = Convert.ToInt32(Console.ReadLine());

            fileData = readData(@fileLocation);
            ReadRecords(fileData, delimiter, numberOfFields );

            Console.WriteLine("\r\nExport Complete");
            Console.WriteLine("\nPress the \"q\" key to quit.");
            do
            {
                cki = Console.ReadKey();
            } while (cki.Key != ConsoleKey.Q);
        }

        public static string[] readData(string filepath)
        {
            try
            {
                return File.ReadAllLines(@filepath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error reading the file.");
                throw new ApplicationException("Error retrieving record:", ex);
            }
        }

        public static void ReadRecords(string[] data, string delimiter, int numOfFields)
        {

            try
            {
                var header = data[0].Split(delimiter);
                var correctFields = new StringBuilder();
                var incorrectFields = new StringBuilder();

                foreach (var row in data.Skip(1))
                {
                    string[] recordFields = row.Split(delimiter);

                    if ((recordFields.Count()) == numOfFields)
                    {
                        correctFields.AppendLine(row);
                    }
                    else {
                        incorrectFields.AppendLine(row);
                    }
                }
                File.WriteAllText(@"Records.csv", correctFields.ToString());
                File.WriteAllText(@"InvalidFieldRecords.csv", incorrectFields.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was an error reading the record.");
                throw new ApplicationException("Error retrieving record:", ex);
            }

        }

    }
}
