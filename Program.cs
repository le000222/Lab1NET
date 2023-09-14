using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1
{
    class Lab1
    {
        private static IList<string> words = new List<string>();
        private static IList<string> sortedWords = new List<string>();
        private static IList<string> linqWords = new List<string>();
        
        static void Main()
        {
            int option;
            do {
                printMenu();
                option = userInput();
                if (option == -1)
                {
                    Console.Write("Invalid input!!\n");
                }
            } while(true);
        }

        public static void printMenu()
        {
            Console.Write("\n1 - Import words from File\n" +
            "2 - Bubble sort words\n" +
            "3 - LINQ/Lambda sort words\n" +
            "4 - Count the distinct words\n" +
            "5 - Take the first 50 words\n" +
            "6 - Reverse print the words\n" +
            "7 - Get and display words that end with ‘a’ and display the count\n" +
            "8 - Get and display words that include ‘m’ and display the count\n" +
            "9 - Get and display words that are less than 4 characters long and include the letter ‘i’, and display the count\n" +
            "x – Exit\n");
        }
        public static int userInput()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Stop();
            Console.Write("Please enter your option: ");
            switch (Console.ReadLine())
            {
                case "1": //import word file
                    words = readFile(words);
                    break;
                case "2": //bubble sort words
                    if (!watch.IsRunning)
                    {
                        watch.Restart();
                    }
                    sortedWords = BubbleSort(words);
                    watch.Stop();
                    Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
                    break;
                case "3": //LINQ/Lambda sort words
                    if (!watch.IsRunning)
                    {
                        watch.Restart();
                    }
                    linqWords = LINQSort(words);
                    watch.Stop();
                    Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
                    break;
                case "4": //Count distinct words
                    CountDistinct(words);
                    break;
                case "5": //take first 50 words
                    RetrieveFirst50();
                    break;
                case "6": //reverse print all the words
                    ReverseAllWords(words);
                    break;
                case "7": //Get and display words that end with ‘a’ and display the count
                    FilterListEndWith(words, "a");
                    break;
                case "8": //Get and display words that start with ‘m’ and display the count
                    FilterListStartWith(words, "m");
                    break;
                case "9": //Get and display words that are less than 4 characters long and include the letter ‘i’, and display the count
                    FilterListInclude(words, "i", 4);
                    break;
                case "x": //Exit
                    System.Environment.Exit(1);
                    break;
                default:
                    return -1;
            }
            return 0;
        }
        public static IList<string> readFile(IList<string> words)
        {
            try
            {
                using (StreamReader sr = new StreamReader("C:\\Users\\phuon\\OneDrive - Algonquin College\\.NET\\Lab1NET\\Words.txt"))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        words.Add(line.Trim());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.Write("There are " + CountWords(words) + " words in total\n");
            return words;
        }
        public static IList<string> BubbleSort(IList<string> words)
        {
            IList< string> copy = CopyList(words);
            for (int i = 0; i < copy.Count - 1; i++)
            {
                for (int j = 0; j < copy.Count - i - 1; j++)
                {
                    if (copy[j].CompareTo(copy[j + 1]) > 0)
                    {
                        string temp = copy[j];
                        copy[j] = copy[j + 1];
                        copy[j + 1] = temp;
                    }
                }
            }
            return copy;
        }
        public static IList<string> LINQSort(IList<string> words)
        {
            var linqSortList = words.OrderBy(w=>w).ToList();
            return words;
        }
        public static void CountDistinct(IList<string> words)
        {
            var linqDistinctList = words.Distinct().ToList();
            Console.Write("There are " + CountWords(linqDistinctList) + " distinct words\n");
            
        }
        private static void RetrieveFirst50()
        {
            var first50 = words.Take(50).ToList();
            Console.WriteLine("The first 50 words: ");
            DisplayList(first50);
        }
        public static void ReverseAllWords(IList<string> words)
        {
            var reverseList = words.Reverse().ToList();
            DisplayList(reverseList);
        }
        public static void FilterListEndWith(IList<string> words, string condition)
        {
            var filterList = words.Where(w => w.EndsWith(condition)).ToList();
            Console.WriteLine("There are " + CountWords(filterList) + " words that end with '" + condition + "':");
            DisplayList(filterList);
        }
        public static void FilterListStartWith(IList<string> words, string condition)
        {
            var filterList = words.Where(w => w.StartsWith(condition)).ToList();
            Console.WriteLine("There are " + CountWords(filterList) + " words that start with '" + condition + "':");
            DisplayList(filterList);
        }
        public static void FilterListInclude(IList<string> words, string condition, int length = 0)
        {
            var filterList = words.Where(w => w.Contains(condition) && w.Length < length).ToList();
            Console.WriteLine("There are " + CountWords(filterList) + " words that have less than 4 characters and include '" + condition + "':");
            DisplayList(filterList);
        }
        public static int CountWords(IList<string> words)
        {
            int numOfWords = 0;
            foreach (var word in words)
            {
                numOfWords++;
            }
            return numOfWords;
        }
        public static IList<string> CopyList(IList<string> words)
        {
            IList<string> copy = new List<string>(words.Count);
            foreach (string s in words)
            {
                copy.Add(s);
            }
            return copy;
        }
        public static void DisplayList(IList<string> list)
        {
            foreach (string s in list)
            {
                Console.WriteLine(s);
            }
        }
    }
}
