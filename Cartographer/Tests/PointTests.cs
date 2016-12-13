using Cartographer.World;
using NUnit.Framework;
using System;

namespace Cartographer.Tests
{
    [TestFixture]
    public class PointTests
    {
        private void AssertPushesToCorrectPosition(double newX, double newY, double newZ, double x, double y, double z)
        {
            var point = new Point(x, y, z);
            var newPoint = point.PushFrom(Point.Zero(), 1);

            Assert.AreEqual(newX, newPoint.X, 0.001);
            Assert.AreEqual(newY, newPoint.Y, 0.001);
            Assert.AreEqual(newZ, newPoint.Z, 0.001);
        }

        private void AssertProjectsToCorrectPosition(double newX, double newY, double newZ, double x, double y, double z)
        {
            var point = new Point(x, y, z);
            var newPoint = new EquirectangularProjector().ProjectPoint(point);

            Assert.AreEqual(newX, newPoint.X, 0.001);
            Assert.AreEqual(newY, newPoint.Y, 0.001);
            Assert.AreEqual(newZ, newPoint.Z, 0.001);
        }

        [Test]
        public void PhiIsEast()
        {
            AssertPushesToCorrectPosition(Math.Sqrt(2) / 2.0, Math.Sqrt(2) / 2.0, 0, 0.1, 0.1, 0);
            AssertPushesToCorrectPosition(Math.Sqrt(2) / 2.0, Math.Sqrt(2) / 2.0, 0, 0.2, 0.2, 0);
            AssertPushesToCorrectPosition(Math.Sqrt(2) / 2.0, Math.Sqrt(2) / 2.0, 0, 0.3, 0.3, 0);
            AssertPushesToCorrectPosition(Math.Sqrt(2) / 2.0, Math.Sqrt(2) / 2.0, 0, 0.4, 0.4, 0);
            AssertPushesToCorrectPosition(Math.Sqrt(2) / 2.0, Math.Sqrt(2) / 2.0, 0, 0.5, 0.5, 0);
            AssertPushesToCorrectPosition(Math.Sqrt(2) / 2.0, Math.Sqrt(2) / 2.0, 0, 0.6, 0.6, 0);
            AssertPushesToCorrectPosition(Math.Sqrt(2) / 2.0, Math.Sqrt(2) / 2.0, 0, 1.0, 1.0, 0);
            AssertPushesToCorrectPosition(Math.Sqrt(2) / 2.0, Math.Sqrt(2) / 2.0, 0, 2.0, 2.0, 0);
            AssertPushesToCorrectPosition(Math.Sqrt(2) / 2.0, Math.Sqrt(2) / 2.0, 0, 4.0, 4.0, 0);
            AssertPushesToCorrectPosition(Math.Sqrt(2) / 2.0, Math.Sqrt(2) / 2.0, 0, 100.0, 100.0, 0);
        }

        [Test]
        public void LongitudeLatitude()
        {
            var radians = Math.PI/360.0;

            AssertProjectsToCorrectPosition(0, 0, 0, 0, 0, 0);
            AssertProjectsToCorrectPosition(0, 0, 0, 0, 0, 100);
            AssertProjectsToCorrectPosition(0, 0, 0, 0, 100, 0);
            AssertProjectsToCorrectPosition(0, 0, 0, 100, 0, 0);
        }
    }
}
