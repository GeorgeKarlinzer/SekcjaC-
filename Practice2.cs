using System;

namespace ConsoleApp10
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Fraction
    {
        private int a;
        private int b;

        public int A
        {
            get => a;
            set
            { 
                a = value;
            }
        }
        public int B
        {
            get => b;
            set
            {
                b = value != 0 ? value : b;
            }
        }


        public override string ToString()
        {
            return $"{A}/{B}";
        }

        public Fraction() : this(1, 1) { }

        public Fraction(int a, int b)
        {
            A = a;
            B = b;
        }

        public void Simplify()
        {
            if (b < 0)
            {
                a = -a;
                b = -b;
            }

            int gcd_ab = GCD(a, b);
            a /= gcd_ab;
            b /= gcd_ab;
        }

        private static int GCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (a != 0 && b != 0)
                if (a > b) a %= b;
                else b %= a;

            return a | b;
        }

        public static Fraction operator +(Fraction fraction1, Fraction fraction2)
        {
            int gcd = GCD(fraction1.B, fraction2.B);

            int newA = fraction1.A * (fraction2.B / gcd) + fraction2.A * (fraction1.B / gcd);
            int newB = fraction1.B * (fraction2.B / gcd);
            return new Fraction(newA, newB);
        }

        public static Fraction operator -(Fraction fraction)
        {
            return new Fraction(-fraction.A, fraction.B);
        }

        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            return fraction1 + -fraction2;
        }

        public static Fraction operator *(Fraction fraction1, Fraction fraction2)
        {
            return new Fraction(fraction1.A * fraction2.A, fraction1.B * fraction2.B);
        }

        public static Fraction operator /(Fraction fraction1, Fraction fraction2)
        {
            if (fraction1.A == 0)
                throw new DivideByZeroException();

            return new Fraction(fraction1.A * fraction2.B, fraction1.B * fraction2.A);
        }

        public static bool operator >(Fraction fraction1, Fraction fraction2)
        {
            var diff = fraction1 - fraction2;
            diff.Simplify();
            return diff.A > 0;
        }

        public static bool operator <(Fraction fraction1, Fraction fraction2)
        {
            return fraction2 > fraction1;
        }

        public static bool operator ==(Fraction fraction1, Fraction fraction2)
        {
            return !(fraction1 > fraction2) && !(fraction1 < fraction2);
        }

        public static bool operator !=(Fraction fraction1, Fraction fraction2)
        {
            return !(fraction1 == fraction2);
        }
    }

    class Point2D
    {
        public int x;
        public int y;

        public Point2D() : this(0, 0) { }

        public Point2D(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Trapezoid
    {
        public Point2D p1, p2, p3, p4;

        public Trapezoid(Point2D p1, Point2D p2, Point2D p3, Point2D p4)
        {

        }
    }
}
