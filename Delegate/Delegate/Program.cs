using System.Runtime.Intrinsics.Arm;

namespace Delegate
{
    delegate int Operation(int x, int y);
    delegate T Add<T>(T a, T b);
    internal class Program
    {
        static int Sum(int a, int b)
        {
            return a + b;
        }
        
        public static int Subtract(int x, int y)
        {
           return x - y;
        }

        public static int Multiply(int x, int y)
        {
           return x * y;
        }

        public static string ConcatStrings(string s1 , string s2)
        {
            return s1 + ' ' + s2;
        }
        static void Main(string[] args)
        {
            #region
            Operation add = Sum;

            int result = add(5, 10);
            Console.WriteLine($"Sum: {result}");
            #endregion
            #region
            Operation add2 = (x, y) => x + y;
            int result2 = add(5, 10);
            Console.WriteLine($"Sum: {result2}");


            Operation add3 = delegate (int a, int b)
            {
                return a + b;
            };
            int result3 = add(5, 10);
            Console.WriteLine($"Sum: {result3}");
            #endregion

            #region
            Operation allOps = Sum;
            allOps += Subtract;
            allOps += Multiply;
            int finalResult = allOps(10, 5);
            Console.WriteLine($"Final Result after all operations: {finalResult}");
            #endregion


            #region
            Add<int> intAdder = (a, b) => a + b;
            int intResult = intAdder(10, 20);
            Console.WriteLine(intResult);
            Add<string> stringAdder = ConcatStrings;
            string stringResult = stringAdder("Hello", "World");
            Console.WriteLine(stringResult);
            #endregion


            #region
            Func<int, int, int> funcAdd = Sum;
            int funcResult = funcAdd(15, 25);
            Console.WriteLine($"Func Add Result: {funcResult}");

            Action<string> printMessage = message => Console.WriteLine(message);
            printMessage("Hello from Action delegate!");
            Predicate<int> isEven = number => number % 2 == 0;
            Console.WriteLine($"Is 10 even? {isEven(10)}");
            #endregion
        }
    }
}
