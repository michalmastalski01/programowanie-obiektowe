using System;

namespace lab7
{
    delegate double Operator(double a, double b);
    class Program
    {

        public static double Addition(double x, double y)
        {
            return x + y;
        }
        public static double Mul(double x, double y)
        {
            return x * y;
        }
        public static void PrintIntArray (int[] arr, Func<int, string> formatter)
        {
            foreach(var item in arr)
            {
                Console.WriteLine(formatter.Invoke(item));
            }
        }
        static void Main(string[] args)
        {
            Operator operation = Addition;
            //równoważnik Addition(4, 6);
            double result = operation.Invoke(4, 6);
            Console.WriteLine(result);
            operation = Mul;
            result = operation.Invoke(4, 6);
            Console.WriteLine(result);

            Func<double, double, double> op = Mul;
            Func<int, string> Formatter = delegate (int number)
            {
                return string.Format("0x{0:x}", number);
            };
            Func<int, string> DecFormat = delegate (int number)
            {
                return string.Format("{0}", number);
            };

            Console.WriteLine(Formatter.Invoke(23));

            Predicate<string> OnlyThreeChars = delegate (string s)
            {
                return s.Length == 3;
            };
            Func<int, int, int, bool> InRange = delegate (int value, int min, int max)
            {
                return value > min && value < max;
            };

            Action<string> Print = delegate (string s)
            {
                Console.WriteLine(s);
            };
            Operator AddLambda = (a, b) => a + b;
            Action<string> PrintLambda = s => Console.WriteLine(s);
            Func<int> Lambda = () => 3;
            PrintIntArray(new int[] { 1, 5, 23, 533 }, n => string.Format("{0}", n));
            PrintIntArray(new int[] { 1, 5, 23, 533 }, DecFormat);
        }
    }
}
