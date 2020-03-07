using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions
{
    public static class RepCalculations
    {
        public static double CalculateReps(double max, double percent, bool weightMetric = true)
        {
            if(weightMetric)
            {
                return Math.Round((max * percent) / 5) * 5;

            }
            return Math.Round(max * percent / 2.5) * 2.5;

        }
    }
}
