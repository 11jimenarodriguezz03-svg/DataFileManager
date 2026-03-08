namespace Inheritance
{
    abstract class GeometricFigure
    {
        public string Name { get; }

        protected GeometricFigure(string name)
        {
            Name = name;
        }

        public abstract double GetArea();
        public abstract double GetPerimeter();

        public override string ToString()
        {
            return $"{Name,-12} => Area.....: {GetArea(),10:F5}   Perimeter: {GetPerimeter(),10:F5}";
        }
    }
}




