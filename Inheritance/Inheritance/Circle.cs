using Inheritance;
using System;

namespace Inheritance
{
    class Circle : GeometricFigure
    {
        private double _r;
        public double R
        {
            get => _r;
            set => _r = ValidateR(value);
        }

        public Circle(string name, double r) : base(name)
        {
            R = r;
        }

        public override double GetArea() => Math.PI * Math.Pow(R, 2);
        public override double GetPerimeter() => 2 * Math.PI * R;

        private double ValidateR(double value)
        {
            if (value <= 0) throw new ArgumentException("R must be > 0");
            return value;
        }
    }
}

