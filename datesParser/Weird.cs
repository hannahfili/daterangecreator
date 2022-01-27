using System;
using System.Collections.Generic;
using System.Text;

namespace datesParser
{
    public class Weird
    {
        public string Format { get; set; }
        public DateTime Date { get; set; }

        public Weird(string format, DateTime date)
        {
            Format = format;
            Date = date;
        }
    }
}
