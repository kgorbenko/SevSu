using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6
{
    public class Rectangle
    {
        public double SideA { get; private set; }

        public double SideB { get; private set; }

        public Rectangle(double a, double b)
        {
            SideA = a;
            SideB = b;
        }

        public Rectangle()
        {
            SideA = 0;
            SideB = 0;
        }

        public static bool operator !(Rectangle rectangle)
        {
            return rectangle.SideA == rectangle.SideB;
        }

        public static double operator - (Rectangle rectangle)
        {
            return rectangle.SideA - rectangle.SideB;
        }

        public static double operator + (Rectangle rect1, Rectangle rect2)
        {
            var firstRectangleArea = rect1.SideA * rect1.SideB;
            var secondRectangleArea = rect2.SideA * rect2.SideB;

            return firstRectangleArea + secondRectangleArea;
        }

        public static bool operator == (Rectangle rect1, Rectangle rect2)
        {
            var firstRectangleArea = rect1.SideA * rect1.SideB;
            var secondRectangleArea = rect2.SideA * rect2.SideB;

            return firstRectangleArea == secondRectangleArea;
        }

        public static bool operator != (Rectangle rect1, Rectangle rect2)
        {
            var firstRectangleArea = rect1.SideA * rect1.SideB;
            var secondRectangleArea = rect2.SideA * rect2.SideB;

            return firstRectangleArea != secondRectangleArea;
        }

        public override bool Equals(object obj)
        {
            var rectangle = obj as Rectangle;
            if (rectangle == null) throw new ArgumentNullException();

            var firstRectangleArea = SideA * rectangle.SideB;
            var secondRectangleArea = SideA * rectangle.SideB;

            return firstRectangleArea == secondRectangleArea;
        }

        public override string ToString()
        {
            return $"A={SideA};B={SideB}";
        }

        public override int GetHashCode()
        {
            var hashCode = 999451561;
            hashCode = hashCode * -1521134295 + SideA.GetHashCode();
            hashCode = hashCode * -1521134295 + SideB.GetHashCode();
            return hashCode;
        }
    }
}
