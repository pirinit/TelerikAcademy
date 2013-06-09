using System;

namespace Methods
{
    class Methods
    {
        static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Every side of the triangle shloud have positive length.");
            }
            double halfPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(halfPerimeter * (halfPerimeter - a) * (halfPerimeter - b) * (halfPerimeter - c));
            return area;
        }

        static string DigitToString(int digit)
        {
            switch (digit)
            {
                case 0:
                    return "zero";
                case 1:
                    return "one";
                case 2:
                    return "two";
                case 3:
                    return "three";
                case 4:
                    return "four";
                case 5:
                    return "five";
                case 6:
                    return "six";
                case 7:
                    return "seven";
                case 8:
                    return "eight";
                case 9:
                    return "nine";
                default:
                    string message = string.Format("Number should be between 0 and 9. Actual number is {0}.", digit);
                    throw new ArgumentException(message);
            }
        }

        static int FindMax(params int[] elements)
        {
            if (elements.Length == 0)
            {
                throw new ArgumentException("Atleast one argument should be passed.");
            }

            int max = int.MinValue;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        static void PrintAsNumber(object number, string format)
        {
            switch (format)
            {
                case "f":
                    Console.WriteLine("{0:f2}", number);
                    break;
                case "%":
                    Console.WriteLine("{0:p0}", number);
                    break;
                case "r":
                    Console.WriteLine("{0,8}", number);
                    break;
            }
        }

        static double CalcDistance(Point first, Point second)
        {
            double deltaX = first.X - second.X;
            double deltaY = first.Y - second.Y;

            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            return distance;
        }

        static bool IsLineHorizontal(Point first, Point second)
        {
            return first.Y == second.Y;
        }

        static bool IsLineVertical(Point first, Point second)
        {
            return first.X == second.X;
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            Console.WriteLine(DigitToString(5));
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));

            //the easiest and most convinient way to format and print a number to the console. There is no
            //need of a separate method to do that...
            Console.WriteLine("{0:f2}", 1.3);
            Console.WriteLine("{0:p0}", 0.75);
            Console.WriteLine("{0,8}", 2.30);
            //PrintAsNumber(1.3, "f");
            //PrintAsNumber(0.75, "%");
            //PrintAsNumber(2.30, "r");

            Point first = new Point(3, -1);
            Point second = new Point(3, 2.5);
            Console.WriteLine(CalcDistance(first, second));
            Console.WriteLine("Horizontal? " + IsLineHorizontal(first, second));
            Console.WriteLine("Vertical? " + IsLineVertical(first, second));

            Student peter = new Student("Peter", "Ivanov", DateTime.Parse("17.03.1992"), "Sofia");
            peter.OtherInfo = "";

            Student stella = new Student("Stella", "Markova", DateTime.Parse("03.11.1993"), "Vidin");
            stella.OtherInfo = "gamer, high results";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}