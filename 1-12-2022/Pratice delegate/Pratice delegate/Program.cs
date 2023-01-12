using System;

namespace Pratice_delegate
{
    internal class Program
    {
        delegate int Calculate(int num1, int num2);
        delegate bool CheckNum(int num);

        static int Sum(int[] numbers, Predicate<int> check)
        {
            int sum = 0;
            foreach (var num in numbers)
            {
                if (check(num))
                    sum += num;
            }

            return sum;
        }
        static int SumOfOdd(int[] numbers)
        {
            int sum = 0;
            foreach (var num in numbers)
            {
                if (num % 2 == 1)
                    sum += num;
            }

            return sum;
        }

        static int SumOfDividedBy3(int[] numbers)
        {
            int sum = 0;
            foreach (var num in numbers)
            {
                if (num % 3 == 0)
                    sum += num;
            }

            return sum;
        }

        static int SumOfDividedBy5(int[] numbers)
        {
            int sum = 0;
            foreach (var num in numbers)
            {
                if (num % 5 == 0)
                    sum += num;
            }

            return sum;
        }

        static bool IsEven(int num)
        {
            return num % 2 == 0;
        }

        static bool IsOdd(int num)
        {
            return num % 2 == 1;
        }

        static void ShowSum(int num1, int num2)
        {
            Console.WriteLine(num1 + num2);
        }


        static void Main(string[] args)
        {
            int[] numbers = { 45, 10, 90, 83, 24, 54, 23, 66 };

            CheckNum method = IsEven;
            method = IsOdd;
            method = delegate (int num) {
                return num % 3 == 0;
            };
            method = x => x % 5 == 0;

            var result = method.Invoke(34);
            result = method(10);

            Console.WriteLine(Sum(numbers, IsEven));
            Console.WriteLine(Sum(numbers, IsOdd));
            Console.WriteLine(Sum(numbers, delegate (int num) { return num < 0; }));
            Console.WriteLine(Sum(numbers, x => x > 0));
            Console.WriteLine(Sum(numbers, x => x < 0 && x % 3 == 0));


            Console.WriteLine(SumOfDividedBy3(numbers));
            Console.WriteLine(SumOfDividedBy5(numbers));
            Console.WriteLine(SumOfOdd(numbers));

            Calculate add = delegate (int x, int y) { return x + y; };

            add = (x, y) => x * y;
            Console.WriteLine(add(10, 30));


            Func<int, bool> check = IsEven;
            Func<int, int, int> sum = (x, y) => x + y;

            Action<int, int> sum2 = ShowSum;

            Predicate<int> predicate = IsEven;
            predicate = x => x % 3 == 0;
            predicate = delegate (int x) { return x > 100; };

        }

    }
}
