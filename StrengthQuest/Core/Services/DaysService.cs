using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class DaysService
    {
        public int DaysToIntegers(string day)
        {
            return day switch
            {
                "Sunday" => 1,
                "Monday" => 2,
                "Tuesday" => 3,
                "Wednesday" => 4,
                "Thursday" => 5,
                "Friday" => 6,
                "Saturday" => 7,
                _ => 0,
            };
            /*
             *switch(day)
              {
                case "Sunday":
                    return 1;
                case "Monday":
                    return 2;
                case "Tuesday":
                    return 3;
                case "Wednesday":
                    return 4;
                case "Thursday":
                    return 5;
                case "Friday":
                    return 6;
                case "Saturday":
                    return 7;
                default:
                    return 0;
              }
             */
        }
    }
}
