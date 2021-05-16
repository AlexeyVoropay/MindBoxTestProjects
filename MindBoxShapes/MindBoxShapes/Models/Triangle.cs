namespace MindBoxShapes.Models
{
	using System;
	using System.Linq;
    using MindBoxShapes.Interfaces;

    public class Triangle : IShape
	{
		public Triangle(double sideA, double sideB, double sideC)
		{
			SideA = sideA;
			SideB = sideB;
			SideC = sideC;
		}

		public double SideA { get; set; }
		public double SideB { get; set; }
		public double SideC { get; set; }

		public void Validate()
		{
			if (SideA <= 0 || SideB <= 0 || SideC <= 0)
				throw new ArgumentException("Длины всех сторон треугольника, должны быть положительнымы числами.");

			if (SideA > SideB + SideC ||
				SideB > SideA + SideC ||
				SideC > SideA + SideB)
				throw new ArgumentException("Сторона треугольника, не может быть больше суммы длин других сторон.");
		}

		public double GetArea()
		{
			Validate();
			var p = (SideA + SideB + SideC) / 2;
			return Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
		}

		public bool HasRightAngle()
		{
			Validate();

			var values = new[] { SideA, SideB, SideC }
				.OrderBy(x => x).ToArray();

			var result = values[0] * values[0] + values[1] * values[1] - values[2] * values[2];

			return Math.Abs(result) < double.Epsilon;
		}
	}
}
