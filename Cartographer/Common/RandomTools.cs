using System;
using System.Collections.Generic;

namespace Cartographer.Common
{
    public static class RandomTools
    {
        public static Random Random = new Random();

        public static double NextGaussian(double mean, double standardDeviation)
        {
            var a = Random.NextDouble();
            var b = Random.NextDouble();
            var standardNormal = Math.Sqrt(-2.0*Math.Log(a))*Math.Sin(2.0*Math.PI*b);
            return mean + standardDeviation*standardNormal;
        }

        public static bool Chance(double chance)
        {
            return Random.NextDouble() >= chance;
        }

        public static int NextInt(int inclusiveMin, int exclusiveMax)
        {
            return Random.Next(inclusiveMin, exclusiveMax);
        }

        public static T NextElement<T>(List<T> list)
        {
            return list[NextInt(0, list.Count)];
        }
    }
}
