using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_2
{
    public struct Point
    {
        public int X;
        public int Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void Move(int dx, int dy)
        {
            X += dx;
            Y += dy;
        }

        public override string ToString()
        {
            return $"Point({X}, {Y})";
        }
    }

    public enum Days
    {
        Saturday, Sunday, Monday, Tuesday, Wednesday, Thursday, Friday
    }

    public class DayPrinter
    {
        public static void PrintDayMessage(Days day)
        {
            switch (day)
            {
                case Days.Sunday:
                    Console.WriteLine("Start of the week! Let's work hard.");
                    break;
                case Days.Thursday:
                    Console.WriteLine("Weekend is almost here!");
                    break;
                case Days.Saturday:
                case Days.Friday:
                    Console.WriteLine("It's weekend! Relax and enjoy.");
                    break;
                default:
                    Console.WriteLine("Just another working day.");
                    break;
            }
        }
    }
}
