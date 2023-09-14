using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1
{
    class Lab1
    {
        static IList<string> words = new List<string>();
        static IList<string> sortedWords = new List<string>();
        static IList<string> linqWords = new List<string>();
        static void Main()
        {
            int option;
            do {
                printMenu();
                option = userInput();
                if (option == 0)
                {
                    Console.Write("Invalid input!!\n\n");
                }
            } while(true);
        }

        public static void printMenu()
        {
            Console.Write("1 - Import words from File\n" +
            "2 - Bubble sort words\n" +
            "3 - LINQ/Lambda sort words\n" +
            "4 - Count the distinct words\n" +
            "5 - Take the first 50 words\n" +
            "6 - Reverse print the words\n" +
            "7 - Get and display words that end with ‘a’ and display the count\n" +
            "8 - Get and display words that include ‘m’ and display the count\n" +
            "9 - Get and display words that are less than 4 characters long and include the letter ‘I’, and display the count\n" +
            "x – Exit\n");
        }
        public static int userInput()
        {
           
            Console.Write("Please enter your option: ");
            switch (Console.ReadLine())
            {
                case "1": //import word file
                    words = readFile(words);
                    break;
                case "2": //bubble sort words
                    sortedWords = BubbleSort(words);
                    break;
                case "3": //LINQ/Lambda sort words
                    linqWords = LINQSort(words);
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
                    FilterList(0, "a");
                    break;
                case "8": //Get and display words that include ‘m’ and display the count
                    FilterList(0, "m");
                    break;
                case "9": //Get and display words that are less than 4 characters long and include the letter ‘I’, and display the count
                    FilterList(4, "I");
                    break;
                case "x": //Exit
                    System.Environment.Exit(1);
                    break;
                default:
                    return 0;
            }
            return 1;
        }
        public static IList<string> readFile(IList<string> words)
        {
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("C:\\Users\\phuon\\OneDrive - Algonquin College\\.NET\\Lab1NET\\Words1.txt"))
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
            DisplayList(words);
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
            DisplayList(copy);
            //find how long this takes
            return copy;
        }
        public static IList<string> LINQSort(IList<string> words)
        {
            var linqSortList = (from w in words orderby w descending select w).ToList();
            DisplayList(linqSortList);

            //find how long this takes
            return words;
        }
        public static void CountDistinct(IList<string> words)
        {
            var linqDistinctList = (from w in words select w).Distinct().ToList();
            int numOfDistinct = 0;
            foreach (var word in words)
            {
                numOfDistinct++;
            }
            DisplayList(linqDistinctList);
            Console.WriteLine("Number of distinct words: " + numOfDistinct);
        }
        private static void RetrieveFirst50()
        {

        }
        public static void ReverseAllWords(IList<string> words)
        {

        }
        public static void FilterList(int length, string condition)
        {
            DisplayCount();
        }
        public static void DisplayCount()
        {

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
            Console.WriteLine();
        }
    }
}
