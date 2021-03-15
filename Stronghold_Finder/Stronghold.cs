using System;

namespace Stronghold_Finder
{
    class Stronghold
    {
        public static double distanceBetweenTwoPoints(double firstCoordinateX, double firstCoordinateZ, double secondCoordinateX, double secondCoordinateZ)
        {
            if(secondCoordinateX == -1 && secondCoordinateZ == -1)
            {
                return -1;
            }
            return Math.Sqrt((Math.Pow(firstCoordinateX - secondCoordinateX, 2) + Math.Pow(firstCoordinateZ - secondCoordinateZ, 2)));
        }


        public static double[] getStrongholdCoords(double[] firstValues, double[] secondValues)
        {
            double angleFirstValues = firstValues[2] % 360;
            double angleSecondValues = secondValues[2] % 360;

            if (angleFirstValues >= 0)
            {
                angleFirstValues = (angleFirstValues + 90) % 360;
            }
            else
            {
                angleFirstValues = (angleFirstValues - 270) % 360;
            }

            if (angleSecondValues >= 0)
            {
                angleSecondValues = (angleSecondValues + 90) % 360;
            }
            else
            {
                angleSecondValues = (angleSecondValues - 270) % 360;
            }

            double a0 = Math.Tan(angleFirstValues * Math.PI / 180);
            double a1 = Math.Tan(angleSecondValues * Math.PI / 180);

            double b0 = firstValues[1] - (firstValues[0] * a0);
            double b1 = secondValues[1] - (secondValues[0] * a1);

            double strongHoldPositionX = (b1 - b0) / (a0 - a1);
            double strongHoldPositionZ = (strongHoldPositionX * a0) + b0;

            return new double[] { strongHoldPositionX, strongHoldPositionZ };
        }

    }
}
