using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace zumkuler
{
    internal class Program
    {
        delegate bool Num(int num);
        delegate bool Nums(int num1, int num2);
        delegate string Parse(int numP);

        public static string ParseToStr(int numP)
        {
            return numP.ToString();
        }


        static void Main(string[] args)
        {
            Num metod1 = delegate (int reqem)
            {
                return 7 * reqem == 28;

            };
            Nums metod2 = delegate (int a, int b)
            {
                return a % 2 == 0 && b + a == 2;
            };
            Parse parseMetod = ParseToStr;

            parseMetod = delegate (int ijn)
            {
                return ijn.ToString();
            };

            metod1 = x => x %3==1; 

            var resultMetod1=metod1.Invoke(34);
            Console.WriteLine(resultMetod1);

            var resultMetod2= metod2(23, 56);
            Console.WriteLine(resultMetod2);
            Console.WriteLine(SumIsPossible(23,2,metod2));
            Console.WriteLine(SumIsPossible(12,23,delegate (int num, int num2) { return num / num2==0; }));
            Console.WriteLine(SumIsPossible(2, 2, (x,a) => x == 3 && a+x==2));

            metod1(2);


            Func<int, bool> check = metod1.Invoke;
            check(2);

            Func<int, int, int> sum = (x, y) => x + y;

            Action<int, int> sum2 = ShowSum(3, 3);
           

            //Predicate<int> predicate = IsEven;
            //predicate = x => x % 3 == 0;
            //predicate = delegate (int x) { return x > 100; };
        }
        static bool SumIsPossible(int nm, int nm2, Nums nums )
        {
            return nums(nm, nm2);
        }
        static void ShowSum(int num, int num2)
        {
            Console.WriteLine( num / num2);
        }
        
    }
}
