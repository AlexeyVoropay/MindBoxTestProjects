namespace TestProject1
{
    using System;
    using MindBoxShapes.Models;
    using Xunit;

    public class TriangleTest
    {
        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(1, 1, 10)]
        [InlineData(-1, 1, 1)]
        public void TriangleValidateTest(double sideA, double sideB, double sideC)
        {
            var triangle = new Triangle(sideA, sideB, sideC);
            Assert.Throws<ArgumentException>(() => triangle.Validate());
        }

        [Theory]
        [InlineData(3, 4, 5, 6)]
        [InlineData(5, 6, 7, 14.696938456699069)]
        public void TriangleGetAreaTest(double sideA, double sideB, double sideC, double result)
        {
            var triangle = new Triangle(sideA, sideB, sideC);
            var area = triangle.GetArea();
            Assert.Equal(area, result);
        }

        [Theory]
        [InlineData(3, 4, 5, true)]
        [InlineData(3, 4, 6, false)]
        public void TriangleHasRightAngleTest(double sideA, double sideB, double sideC, bool result)
        {
            var triangle = new Triangle(sideA, sideB, sideC);
            var hasRightAngle = triangle.HasRightAngle();
            Assert.Equal(hasRightAngle, result);
        }
    }
}
