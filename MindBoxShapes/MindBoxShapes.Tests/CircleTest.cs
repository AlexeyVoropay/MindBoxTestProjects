namespace MindBoxShapes.Tests
{
    using System;
    using MindBoxShapes.Models;
    using Xunit;

    public class CircleTests
    {
        [Theory]
        [InlineData(-1)]
        public void CircleValidateTest(double radius)
        {
            var circle = new Circle(radius);
            Assert.Throws<ArgumentException>(() => circle.Validate());
        }

        [Theory]
        [InlineData(1, Math.PI)]
        [InlineData(3, Math.PI * 9)]
        public void CircleGetAreaTest(double radius, double result)
        {
            var circle = new Circle(radius);
            var area = circle.GetArea();
            Assert.Equal(area, result);
        }

        [Theory]
        [InlineData(1, false)]
        public void CircleHasRightAngleTest(double radius, bool result)
        {
            var circle = new Circle(radius);
            var hasRightAngle = circle.HasRightAngle();
            Assert.Equal(hasRightAngle, result);
        }
    }
}