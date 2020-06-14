using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions
{
    public static class MaxLiftCalculations
    {
        public static double OneRepMax(double weight, int reps)
        {
            if (weight < 0)
            {
                return 0.0;
            }

            if (reps == 1)
            {
                return weight;
            }

            var max = (100 * weight) / (48.8 + (53.8 * Math.Pow(Math.E, -0.075 * reps)));
            return Math.Round(max);
        }

        public static double TrainingMax(double weight, bool weightMetric = true)
        {
            if (weightMetric)
            {
                return Math.Ceiling((weight * 0.9) / 5) * 5;
            }

            return Math.Ceiling((weight * 0.9) / 2.5) * 2.5;
        }
    }
}