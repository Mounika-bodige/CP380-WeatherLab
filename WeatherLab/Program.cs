using System;
using System.Linq;
using System.Collections.Generic;


namespace WeatherLab
{
    class Program
    {
        static string dbfile = @".\data\climate.db";

        static void Main(string[] args)
        {
            var measurements = new WeatherSqliteContext(dbfile).Weather;

            var total_2020_precipitation = measurements.Where(s => s.year > 2019)
                              .Where(st => st.precipitation > 0.0)
                              .Select(s => s.precipitation);
            double total = 0.0;
            foreach (var name in total_2020_precipitation)
            {
                total = (double)(total + name);
            }

            Console.WriteLine($"Total precipitation in 2020: {total} mm\n");

            IQueryable<Weather> hdd = (IQueryable<Weather>)measurements.Where(s => s.year > 2015)
                              .Where(st => st.meantemp < 18)
                              .Select(s => new Weather { dateh = (s.year).ToString(), hddv = (s.meantemp - ((s.mintemp + s.maxtemp) / 2)) });

            IQueryable<Weather> cdd = (IQueryable<Weather>)measurements.Where(s => s.year > 2015)
                              .Where(st => st.meantemp >= 18)
                              .Select(s => new Weather { abc = (s.year).ToString(), cde = (((s.mintemp + s.maxtemp) / 2) - s.meantemp) });
            double c6 = 0, c7 = 0, c8 = 0, c9 = 0, c0 = 0;
            foreach (var h in hdd)
            {
                if (h.dateh == "2016")
                {
                    c6 = c6+ h.hd;
                }
                else if (h.dateh == "2017")
                {
                    c7 = c7 + h.hd;
                }
                else if (h.dateh == "2018")
                {
                    c8 = c8 + h.hd;
                }
                else if (h.dateh == "2019")
                {
                    c9 = c9 + h.hd;
                }
                else
                {
                    c0 = c0 + h.hd;
                }
            }
            double[] hddarr = { c6, c7, c8, c9, c0 };
            double d16 = 0, d17 = 0, d18 = 0, d19 = 0, d20 = 0;
            foreach (var h in cdd)
            {
                if (h.datec == "2016")
                {
                    d16 = d16 + h.cv;
                }
                else if (h.datec == "2017")
                {
                    d17 = d17 + h.cv;
                }
                else if (h.datec == "2018")
                {
                    d18 = d18 + h.cv;
                }
                else if (h.datec == "2019")
                {
                    d19 = d19 + h.cv;
                }
                else
                {
                    d20 = d20 + h.cv;
                }
            }
            double[] cddarr = { d16, d17, d18, d19, d20 };
           
            Console.WriteLine("Year\tHDD\t\t\tCDD");
            for (int a = 0, year = 2016; a < 5; a++, year++)
            {
                Console.WriteLine(year + "\t" + hddarr[a] + "\t" + cddarr[a]);
            }

            var variable_d = measurements.Where(s => s.year > 2015)
                              .OrderByDescending(s => (s.maxtemp - s.mintemp))
                              .Select(s => s.year + "**" + s.month + "**" + s.day + "\t" + (s.maxtemp - s.mintemp));

            Console.WriteLine("\nTop 5 Most Variable Days");
            Console.WriteLine("YYYY-MM-DD\tDelta");
            int m = 0;
            foreach (var t in variable_d)
            {
                Console.WriteLine(t);
                m++;
                if (m > 4)
                {
                    break;
                }
            }
        }
    }
}
