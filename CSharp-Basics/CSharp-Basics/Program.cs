using System;

namespace CSharp_Basics
{
    internal class Program
    {
        static void print(string message)
        {
            Console.WriteLine(message);
        }

        static dynamic InputNumber()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int i))
                        return i;
                    else if (long.TryParse(input, out long l))
                        return l;
                    else if (double.TryParse(input, out double d))
                        return d;
                    else
                        throw new Exception("Please input a valid number");
                }
                catch (Exception ex)
                {
                    print("Result: " + ex.Message);
                }
            }
        }

        static int chkOperand(char c)
        {
            switch (c)
            {
                case '+': return 1;
                case '-': return 2;
                case '*': return 3;
                case '/': return 4;
                default: return 0;
            }
        }

        static char InputC()
        {
            while (true)
            {
                try
                {
                    return Convert.ToChar(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    print("Result: " + ex.Message);
                }
            }
        }

        static int takeOperation()
        {
            while (true)
            {
                try
                {
                    char op = InputC();
                    int rank = chkOperand(op);
                    if (rank == 0)
                        throw new Exception("Please input one of these (* , / , + , -)");
                    return rank;
                }
                catch (Exception ex)
                {
                    print("Result: " + ex.Message);
                }
            }
        }

        static void makeOperation(dynamic operand1, dynamic operand2, int op)
        {
            try
            {
                dynamic ans = 0;
                switch (op)
                {
                    case 1: ans = operand1 + operand2; break;
                    case 2: ans = operand1 - operand2; break;
                    case 3: ans = operand1 * operand2; break;
                    case 4:
                        if (operand2 == 0)
                            throw new Exception("Cannot divide by zero");
                        ans = operand1 / operand2;
                        break;
                }
                print("Result: " + Convert.ToString(ans));
            }
            catch (Exception ex)
            {
                print("Result: " + ex.Message);
            }
        }

        static void simpleCalculator()
        {
            print("Hello User\n");

            print("Input first operand: ");
            dynamic operand1 = InputNumber();

            print("Input second operand: ");
            dynamic operand2 = InputNumber();

            print("Input operation: ");
            int op = takeOperation();

            makeOperation(operand1, operand2, op);
        }

        static void MinAndMax()
        {
            print("Input 3 numbers");
            long x = InputNumber();
            long y = InputNumber();
            long z = InputNumber();
            long maxVal = Math.Max(Math.Max(x, y), z);
            long minVal = Math.Min(Math.Min(x, y), z);
            print("Result: Max Element is " + maxVal + " | Min Element is: " + minVal);
        }

        static void vowelOrNot()
        {
            print("Input a character: ");
            char c = InputC();
            if ("aeiou".Contains(c))
                print("Result: vowel");
            else
                print("Result: consonant");
        }

        static void multiplicationUp12()
        {
            print("Enter a number: ");
            dynamic x = InputNumber();

            for (int i = 1; i <= 12; i++)
                print("Result: " + x + " * " + i + " = " + (x * i));
        }

        static void Assign()
        {
            int a = 10;
            int b = a;
            print("Result: Before change: a = " + a + ", b = " + b);
            b = 20;
            print("Result: After change: a = " + a + ", b = " + b);
        }

        static void substring()
        {
            print("Enter a string: ");
            string s = Console.ReadLine();
            int len = Math.Min(s.Length, 5);
            print("Result: The first " + len + " characters are: " + s.Substring(0, len));
        }

        static void contacting()
        {
            print("Enter first string: ");
            string s1 = Console.ReadLine();
            print("Enter second string: ");
            string s2 = Console.ReadLine();
            string ans = s1 + s2;
            print("Result: " + ans);
        }

        static void maxAndMinElement()
        {
            print("Enter number of elements: ");
            int sz = InputNumber();
            print($"Enter {sz} numbers separated by space:");
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            Array.Sort(arr);
            print($"Result: Max Element is {arr[sz - 1]} | Min Element is {arr[0]}");
        }

        static void secondMaxElement()
        {
            print("Enter number of elements: ");
            int sz = InputNumber();
            print($"Enter {sz} numbers separated by space:");
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            Array.Sort(arr);
            if (sz < 2)
                print("Result: Not enough elements for a second max");
            else
                print($"Result: Second Max Element is: {arr[sz - 2]}");
        }

        static void reverseArray()
        {
            print("Enter number of elements: ");
            int sz = InputNumber();
            print($"Enter {sz} numbers separated by space:");
            int[] arr = Array.ConvertAll(Console.ReadLine().Split(' '), int.Parse);

            Array.Reverse(arr);
            print("Result: " + string.Join(" ", arr));
        }

        static void Main(string[] args)
        {
            string[] menu = {
                "Simple Calculator",
                "Max and Min of 3 numbers",
                "Vowel or Consonant",
                "Multiplication Table up to 12",
                "Assign value type variable",
                "Extract substring",
                "Concatenate two strings",
                "Max and Min in array",
                "Second largest element in array",
                "Reverse array"
            };

            while (true)
            {
                print("\n=== Menu ===");
                for (int i = 0; i < menu.Length; i++)
                    Console.WriteLine($"{i + 1} - {menu[i]}");
                Console.WriteLine("0 - Exit");

                print("Enter your choice: ");
                if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > menu.Length)
                {
                    print("Result: Invalid choice, try again.");
                    continue;
                }

                if (choice == 0) break;

                switch (choice)
                {
                    case 1: simpleCalculator(); break;
                    case 2: MinAndMax(); break;
                    case 3: vowelOrNot(); break;
                    case 4: multiplicationUp12(); break;
                    case 5: Assign(); break;
                    case 6: substring(); break;
                    case 7: contacting(); break;
                    case 8: maxAndMinElement(); break;
                    case 9: secondMaxElement(); break;
                    case 10: reverseArray(); break;
                }
            }
        }
    }
}