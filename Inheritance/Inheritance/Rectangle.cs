using System;

namespace Inheritance
{
    class Rectangle : Square
    {
        private double _b;
        public double B
        {
            get => _b;
            set => _b = ValidateB(value);
        }

        public Rectangle(string name, double a, double b) : base(name, a)
        {
            B = b;
        }

        public override double GetArea() => A * B;
        public override double GetPerimeter() => 2 * (A + B);

        private double ValidateB(double value)
        {
            if (value <= 0) throw new ArgumentException("B must be > 0");
            return value;
        }
    }
}


