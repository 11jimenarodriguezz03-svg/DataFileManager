using System;

namespace Inheritance
{
    class Triangle : Rectangle
    {
        private double _c, _h;
        public double C
        {
            get => _c;
            set => _c = ValidateC(value);
        }

        public double H
        {
            get => _h;
            set => _h = ValidateH(value);
        }

        public Triangle(string name, double a, double b, double c, double h) : base(name, a, b)
        {
            C = c;
            H = h;
        }

        public override double GetArea() => (B * H) / 2;
        public override double GetPerimeter() => A + B + C;

        private double ValidateC(double value)
        {
            if (value <= 0) throw new ArgumentException("C must be > 0");
            return value;
        }

        private double ValidateH(double value)
        {
            if (value <= 0) throw new ArgumentException("H must be > 0");
            return value;
        }
    }
}
