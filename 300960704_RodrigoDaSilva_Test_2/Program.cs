using _300960704_RodrigoDaSilva_Test_2.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _300960704_RodrigoDaSilva_Test_2
{
    class Program
    {
        static double linqTime;
        static double plinqTime;

        static void Main(string[] args)
        {
            SolveQuestion(ReadQuestion());
            Console.WriteLine("\nPress ENTER key to exit...");
            Console.Read();
        }

        private static void SolveQuestion(int question)
        {
            switch(question)
            {
                case 1:
                    SolveQuestionOne();
                    break;

                case 2:
                    SolveQuestionTwo();
                    break;

                case 3:
                    SolveQuestionThree();
                    break;

                case 4:
                    SolveQuestionFour();
                    break;
                default:
                    throw new InvalidQuestionException(string.Format("The question {0} is not a valid question!", question));
            }
        }

        private static void SolveQuestionOne()
        {
            int[] randomInts = new int[25];

            PopulateArray(randomInts);
            PrintOriginal(randomInts);
            DoWithLinq(randomInts);
            DoWithPLinq(randomInts);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"LINQ Total time in milliseconds: {linqTime:F}ms");
            Console.WriteLine($"PLINQ Total time in milliseconds: {plinqTime:F}ms");
            Console.WriteLine($"Difference in %: {((plinqTime - linqTime) / (linqTime + plinqTime) * 100):F}%");
        }

        private static void PrintOriginal(int[] randomInts)
        {
            PrintHeader();
            Console.WriteLine("##### Original Array:");
            foreach (int e in randomInts)
            {
                Console.Write($"{e} ");
            }
            Console.WriteLine();
        }

        private static void DoWithLinq(int[] randomInts)
        {
            Console.WriteLine();
            PrintHeader();
            Console.WriteLine("#########################                                    U S I N G        L I N Q                                    #########################");

            var start = DateTime.Now;
            PrintOrderedLinq(randomInts);
            PrintEvenLinq(randomInts);
            PrintFristLinq(randomInts);
            PrintLastLinq(randomInts);
            PrintMinLinq(randomInts);
            PrintMaxLinq(randomInts);
            PrintAvgLinq(randomInts);
            PrintSumLinq(randomInts);
            var end = DateTime.Now;
            linqTime = end.Subtract(start).TotalMilliseconds;

            Console.WriteLine();
            PrintHeader();
        }

        private static void PrintOrderedLinq(int[] randomInts)
        {
            Console.WriteLine("##### Ordered Elements:");
            foreach (int e in randomInts.OrderBy(x => x).ToArray())
            {
                Console.Write($"{e} ");
            }
        }

        private static void PrintEvenLinq(int[] randomInts)
        {
            Console.WriteLine();
            Console.WriteLine("##### Even Elements:");
            foreach (int e in randomInts.Where(x => x % 2 == 0).ToArray())
            {
                Console.Write($"{e} ");
            }
        }

        private static void PrintFristLinq(int[] randonInts)
        {
            Console.WriteLine();
            Console.WriteLine("##### First Elements:");
            Console.Write($"{randonInts.First()} ");
        }

        private static void PrintLastLinq(int[] randonInts)
        {
            Console.WriteLine();
            Console.WriteLine("##### Last Elements:");
            Console.Write($"{randonInts.Last()} ");
        }

        private static void PrintMinLinq(int[] randonInts)
        {
            Console.WriteLine();
            Console.WriteLine("##### Minimum Elements:");
            Console.Write($"{randonInts.Min()} ");
        }

        private static void PrintMaxLinq(int[] randonInts)
        {
            Console.WriteLine();
            Console.WriteLine("##### Maximum Elements:");
            Console.Write($"{randonInts.Max()} ");
        }

        private static void PrintAvgLinq(int[] randonInts)
        {
            Console.WriteLine();
            Console.WriteLine("##### Average of Elements:");
            Console.Write($"{randonInts.Average()} ");
        }

        private static void PrintSumLinq(int[] randonInts)
        {
            Console.WriteLine();
            Console.WriteLine("##### Sum of Elements:");
            Console.Write($"{randonInts.Sum()} ");
        }

        private static void DoWithPLinq(int[] randomInts)
        {
            Console.WriteLine();
            PrintHeader();
            Console.WriteLine("#########################                                    U S I N G      P L I N Q                                    #########################");

            var start = DateTime.Now;
            PrintOrderedPLinq(randomInts);
            PrintEvenPLinq(randomInts);
            PrintFristPLinq(randomInts);
            PrintLastPLinq(randomInts);
            PrintMinPLinq(randomInts);
            PrintMaxPLinq(randomInts);
            PrintAvgPLinq(randomInts);
            PrintSumPLinq(randomInts);
            var end = DateTime.Now;
            plinqTime = end.Subtract(start).TotalMilliseconds;

            Console.WriteLine();
            PrintHeader();

        }


        private static void PrintOrderedPLinq(int[] randomInts)
        {
            Console.WriteLine("##### Ordered Elements:");
            foreach (int e in randomInts.AsParallel().OrderBy(x => x).ToArray())
            {
                Console.Write($"{e} ");
            }
        }

        private static void PrintEvenPLinq(int[] randomInts)
        {
            Console.WriteLine();
            Console.WriteLine("##### Even Elements:");
            foreach (int e in randomInts.AsParallel().Where(x => x % 2 == 0).ToArray())
            {
                Console.Write($"{e} ");
            }
        }

        private static void PrintFristPLinq(int[] randonInts)
        {
            Console.WriteLine();
            Console.WriteLine("##### First Elements:");
            Console.Write($"{randonInts.AsParallel().First()} ");
        }

        private static void PrintLastPLinq(int[] randonInts)
        {
            Console.WriteLine();
            Console.WriteLine("##### Last Elements:");
            Console.Write($"{randonInts.AsParallel().Last()} ");
        }

        private static void PrintMinPLinq(int[] randonInts)
        {
            Console.WriteLine();
            Console.WriteLine("##### Minimum Elements:");
            Console.Write($"{randonInts.AsParallel().Min()} ");
        }

        private static void PrintMaxPLinq(int[] randonInts)
        {
            Console.WriteLine();
            Console.WriteLine("##### Maximum Elements:");
            Console.Write($"{randonInts.AsParallel().Max()} ");
        }

        private static void PrintAvgPLinq(int[] randonInts)
        {
            Console.WriteLine();
            Console.WriteLine("##### Average of Elements:");
            Console.Write($"{randonInts.AsParallel().Average()} ");
        }

        private static void PrintSumPLinq(int[] randonInts)
        {
            Console.WriteLine();
            Console.WriteLine("##### Sum of Elements:");
            Console.Write($"{randonInts.AsParallel().Sum()} ");
        }

        private static void PrintHeader()
        {
            Console.WriteLine("##################################################################################################################################################");
        }

        private static void PopulateArray(int[] randomInts)
        {
            Random random = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < randomInts.Length; i++)
            {
                randomInts[i] = random.Next(1, 10000);
            }
        }

        private static void SolveQuestionTwo()
        {
            Console.WriteLine("Please enter a sentence with words separated by spaces and press ENTER when finished.");
            string input = Console.ReadLine();
            string[] words = input.Split(' ');
            Dictionary<string, int> wordMap = new Dictionary<string, int>();

            // Fill the map of word count.
            foreach (string w in words)
            {
                var key = w.ToUpper();
                if (wordMap.ContainsKey(key))
                {
                    wordMap[key]++;
                }
                else
                {
                    wordMap.Add(key, 1);
                }
            }

            Console.WriteLine();
            Console.WriteLine("WORD                 OCCURRENCES");
            Console.WriteLine("-------------------- -----------");
            foreach (KeyValuePair<string, int> entry in wordMap)
            {
                if (entry.Value > 1)
                {
                    Console.WriteLine(string.Format("{0,-20} {1,11}", entry.Key, entry.Value));
                }
            }
        }

        private static void SolveQuestionThree()
        {
            LinkedList<string> linkedList = new LinkedList<string>();

            linkedList.AddLast("Mary");
            linkedList.AddLast("got");
            linkedList.AddLast("a");
            linkedList.AddLast("little");
            linkedList.AddLast("lamb");
            PrintLinkedList("Original List    ", linkedList);


            linkedList.AddFirst("Today");
            PrintLinkedList("Add Today First  ", linkedList);

            var first = linkedList.First;
            linkedList.RemoveFirst();
            linkedList.AddLast(first);
            PrintLinkedList("Move Today Last  ", linkedList);

            first.Value = "yesterday";
            PrintLinkedList("Change Last Node ", linkedList);

            AddAfter("Mary", "Stuart", linkedList);
            PrintLinkedList("Stuart after Mary", linkedList);

            AddBefore("lamb", "white", linkedList);
            PrintLinkedList("white before lamb", linkedList);
        }

        private static void AddAfter(string toSearch, string toAdd, LinkedList<string> linkedList)
        {
            LinkedListNode<string> node = linkedList.First;
            while (node.Value != toSearch)
            {
                node = node.Next;
            }
            linkedList.AddAfter(node, toAdd);
        }

        private static void AddBefore(string toSearch, string toAdd, LinkedList<string> linkedList)
        {
            LinkedListNode<string> node = linkedList.First;
            while (node.Value != toSearch)
            {
                node = node.Next;
            }
            linkedList.AddBefore(node, toAdd);
        }

        private static void PrintLinkedList(string title, LinkedList<string> linkedList)
        {
            Console.Write($"{title}: ");
            foreach (string s in linkedList)
            {
                Console.Write($"{s} ");
            }
            Console.WriteLine();
        }

        private static void SolveQuestionFour()
        {
            const int timesToRoll = 60000000;
            List<int> diceValues = new List<int>(timesToRoll);
            Random random = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < timesToRoll; i++)
            {
                diceValues.Add(random.Next(1, 7));
            }

            Console.WriteLine();
            Console.WriteLine("NUMBER               OCCURRENCES");
            Console.WriteLine("-------------------- -----------");
            foreach (IGrouping<int,int> value in diceValues.GroupBy(x => x).OrderBy(x => x.Key).ToArray())
            {
                Console.WriteLine(string.Format("{0,-20} {1,11}", value.Key, value.Count()));
            }
        }

        private static int ReadQuestion()
        {
            Console.WriteLine("What question do you want to evaluate? Choose the number between () to select!");
            Console.WriteLine("\tQuestion (1) - Random Array or");
            Console.WriteLine("\tQuestion (2) - Duplicate Words or ");
            Console.WriteLine("\tQuestion (3) - Linked List or ");
            Console.Write("\tQuestion (4) - Die Simulation: ");

            int questionNumber = 0;
            do
            {
                string valueRead = Console.ReadLine();
                if (!int.TryParse(valueRead, out questionNumber))
                {
                    Console.Write(string.Format("The option '{0}' is not valid. Choose a valid question (1), (2), (3), or (4): ", valueRead));
                }
                else
                {
                    if (questionNumber != 1 && questionNumber != 2 && questionNumber != 3 && questionNumber != 4)
                    {
                        Console.Write(string.Format("The option '{0}' is not valid. Choose a valid question (1), (2), (3), or (4): ", questionNumber));
                    }
                }
            }
            while (questionNumber != 1 && questionNumber != 2 && questionNumber != 3 && questionNumber != 4);

            return questionNumber;
        }
    }
}
