using System;

namespace Inheritance
{
    class Kite : Rhombus
    {
        private double _b;
        public double B
        {
            get => _b;
            set => _b = ValidateB(value);
        }

        public Kite(string name, double a, double b, double d1, double d2) : base(name, a, d1, d2)
        {
            B = b;
        }

        public override double GetPerimeter() => 2 * (A + B);

        private double ValidateB(double value)
        {
            if (value <= 0) throw new ArgumentException("B must be > 0");
            return value;
        }
    }
}