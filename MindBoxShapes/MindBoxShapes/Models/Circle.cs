namespace MindBoxShapes.Models
{
	using System;
    using MindBoxShapes.Interfaces;

    public class Circle : IShape
	{
		public Circle(double radius)
        {
			Radius = radius;
        }

		public double Radius { get; set; }

		public void Validate()
		{
			if (Radius < 0)
				throw new ArgumentException("Радиус круга не может отрицательным числом");
		}

		public double GetArea()
		{
			Validate();
			return Math.PI * Radius * Radius;
		}

        public bool HasRightAngle()
        {
            return false;
        }
    }
}
