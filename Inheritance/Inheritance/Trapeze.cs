using System;

namespace Inheritance
{
    class Trapeze : Triangle
    {
        private double _d;
        public double D
        {
            get => _d;
            set => _d = ValidateD(value);
        }

        public Trapeze(string name, double a, double b, double c, double d, double h) : base(name, a, b, c, h)
        {
            D = d;
        }

        public override double GetArea() => (B + D) * H / 2;
        public override double GetPerimeter() => A + B + C + D;

        private double ValidateD(double value)
        {
            if (value <= 0) throw new ArgumentException("D must be > 0");
            return value;
        }
    }
}
