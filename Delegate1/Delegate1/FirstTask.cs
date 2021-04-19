using System;
using System.Collections.Generic;

namespace Delegate1
{
    class FirstTask
    {
        delegate int GetInt();
        delegate void DoSomeWork(GetInt getInt, List<float> list);

        public static void Run()
        {
            Console.WriteLine("\ntask 1:");

            DoSomeWork doWork;

            List<float> floatList = new List<float>();
            floatList.Add((float)1.0);
            floatList.Add((float)24.234);
            floatList.Add((float)18.234);
            floatList.Add((float)0.403);

            doWork = GetSum;
            doWork += ShowNumbers;

            doWork(GetRandomInt, floatList);
        }

        private static void GetSum(GetInt getInt, List<float> list)
        {
            if (list == null)
            {
                return;
            }

            foreach (var item in list)
            {
                Console.WriteLine($"sum of float and random int: {item + getInt()}");
            }
        }

        private static void ShowNumbers(GetInt getInt, List<float> list)
        {
            if (list == null)
            {
                return;
            }

            Console.WriteLine(getInt());
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }

        private static int GetRandomInt()
        {
            return new Random().Next();
        }
    }
}