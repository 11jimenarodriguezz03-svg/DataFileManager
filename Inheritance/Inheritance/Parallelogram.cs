using System;
using System.Drawing;

namespace Inheritance
{
    class Parallelogram : Rectangle
    {
        private double _h;
        public double H
        {
            get => _h;
            set => _h = ValidateH(value);
        }

        public Parallelogram(string name, double a, double b, double h) : base(name, a, b)
        {
            H = h;
        }

        public override double GetArea() => B * H;
        public override double GetPerimeter() => 2 * (A + B);

        private double ValidateH(double value)
        {
            if (value <= 0) throw new ArgumentException("H must be > 0");
            return value;
        }
    }
}
