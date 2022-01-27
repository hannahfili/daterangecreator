using System;
using System.Collections.Generic;
using System.Globalization;

namespace datesParser
{
    class Program
    {

        static void Main(string[] args)
        {
            //CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
            while (true)
            {
                Console.WriteLine(DateRange.GenerateDateRange(Console.ReadLine()));
            }
        }

    }
}

