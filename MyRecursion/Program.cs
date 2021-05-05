using System;
using System.Collections.Generic;

namespace MyRecursion
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Wraite Quantity Films");

            //int n = Convert.ToInt32(Console.ReadLine());
            //List<string> name = new List<string>();
            //List<int> currentTime = new List<int>();

            //for (int i = 0; i < n; i++)
            //{
            //    Console.WriteLine($"Name {i + 1} Fimls");

            //    string N = Console.ReadLine();
            //    name.Add(N);

            //    Console.WriteLine("Long films for minutes");

            //    int time = Convert.ToInt32(Console.ReadLine());
            //    currentTime.Add(time);
            //}
            //TimingCinema.Duration = currentTime;

            TimingCinema.Duration = new List<int>() { 120, 160, 170, 140 };
            TimingCinema.Duration.Sort();
            TimingCinema timingCinema = new TimingCinema(14 * 60);
            timingCinema.CreateScheduleBase();
            timingCinema.WriteAllSessions();

            Console.WriteLine();

            var best = timingCinema.FindTimeShowForCinema();
            foreach (int qqq in best.CurrentDuration)
            {
                Console.Write(qqq  +" " );
                Console.WriteLine(  );
            }



            //****Задача Заполнение****
            //Node.Boxes = new List<int>() { 100, 34, 10 };
            //Node.Boxes.Sort();
            //Node node = new Node(100);
            //node.CreateGraph();
            //node.WriteAllLeaves();

            //Console.WriteLine();
            //Console.WriteLine();
            //var q = node.FindLeafWithMinEmptyPlace();
            //foreach (int w in q.CurrentBoxes)
            //{
            //    Console.Write(w + " ");
            //}



            //Console.WriteLine(Factorial(4)); //****вычесление факториала****


            // BooksSwap(3,new List<string>() {"a","b","c","q" });//****растановка книг на полке****

        }

        static int Factorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

        static void BooksSwap(int n, List<string> books, List<string> current = null)
        {
            if (current is null)
            {
                current = new List<string>();
            }
            if (current.Count == n)
            {
                foreach (string book in current)
                {
                    Console.Write(book + " ");
                }
                Console.WriteLine();
            }
            else
            {
                foreach (string book in books)
                {
                    List<string> tmp = new List<string>(current);
                    tmp.Add(book);
                    BooksSwap(n, books, tmp);

                }
            }
        }
    }
}
