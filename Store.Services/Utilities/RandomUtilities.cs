using System;
namespace Store.Services.Utilities
{
    public static class RandomUtilities
    {
        public static double GetDoubleInRange(double minNumber, double maxNumber)
        {
            return new Random().NextDouble() * (maxNumber - minNumber) + minNumber;
        }
    }
}

