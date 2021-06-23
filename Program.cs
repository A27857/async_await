using System.Diagnostics;
using System.Threading;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace C__Fundamental__3
{
    class Program
    {
        static List<int> temp = new List<int>();
        static List<int> result = new List<int>();
        static List<int> result1 = new List<int>();
        static List<int> result2 = new List<int>();
        static List<int> result3 = new List<int>();
        static List<int> result4 = new List<int>();
        static async Task Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            int min = 0;
            int max = 100;
            List<int> Temp = new List<int>();
            Temp = GetNumberRange(min, max);
            Temp = await GetPrimeNumberAsyns();
            for (int i = 0; i < Temp.Count; i++)
            {
                System.Console.WriteLine(Temp[i]);
            }
            sw.Stop();
            System.Console.WriteLine("Total time running is: {0}", sw.ElapsedMilliseconds);
            //Print(result1);
        }
        static void Print(List<int> list)
        {
            for (var i = 0; i < list.Count; i++)
            {
                System.Console.WriteLine(list[i]);
            }
        }
        static async Task<List<int>> GetPrimeNumberAsyns()
        {
            var sw = new Stopwatch();
            sw.Start();
            var task = Task.Factory.StartNew(() =>
            {

                System.Console.WriteLine("Space 1: ");
                foreach (var item in result1)
                {
                    if (IsPrimeNumber(item))
                    {
                        result.Add(item);
                    }
                }
                sw.Stop();
                System.Console.WriteLine("Time running is: {0}", sw.ElapsedMilliseconds);
            });
            var task2 = Task.Factory.StartNew(() =>
            {
                var sw = new Stopwatch();
                sw.Start();
                System.Console.WriteLine("Space 2: ");
                foreach (var item in result2)
                {
                    if (IsPrimeNumber(item))
                    {
                        result.Add(item);
                    }
                }
                sw.Stop();
                System.Console.WriteLine("Time running is: {0}", sw.ElapsedMilliseconds);
            });
            var task3 = Task.Factory.StartNew(() =>
            {
                var sw = new Stopwatch();
                sw.Start();

                foreach (var item in result3)
                {
                    if (IsPrimeNumber(item))
                    {
                        result.Add(item);
                    }
                }
                sw.Stop();
                System.Console.WriteLine("Space running is: {0}", sw.ElapsedMilliseconds);
            });
            var task4 = Task.Factory.StartNew(() =>
            {
                var sw = new Stopwatch();
                sw.Start();
                System.Console.WriteLine("Space 4: ");
                foreach (var item in result4)
                {
                    if (IsPrimeNumber(item))
                    {
                        result.Add(item);
                    }
                }
                sw.Stop();
                System.Console.WriteLine("Space running is: {0}", sw.ElapsedMilliseconds);
            });
            await Task.WhenAll(task, task2, task3, task4);
            return result;
        }
        static List<int> GetNumberRange(int min, int max)
        {
            for (int i = min; i < min + (max / 4); i++)
            {
                result1.Add(i);
            }
            for (int i = min + (max / 4); i < (max / 2); i++)
            {
                result2.Add(i);
            }
            for (int i = (max / 2); i < (max * (3 / 4)); i++)
            {
                result3.Add(i);
            }
            for (int i = (max * (3 / 4)); i <= max; i++)
            {
                result4.Add(i);
            }
            return temp;
        }
        static bool IsPrimeNumber(int number)
        {
            if (number < 2)
                return false;
            var boundary = (int)Math.Floor(Math.Sqrt(number));
            for (int i = 2; i <= boundary; i++)
            {
                if (number % i == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
