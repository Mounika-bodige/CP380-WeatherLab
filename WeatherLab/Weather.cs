﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WeatherLab
{
    public class Weather
    {
         public string dateh;
        public double? hddv;
        public string datec;
        public double hd;
        public double cv;
        public string abc;
        public double? cde;
        [Key]
        [Column("id")]
        public int WeatherId { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public int day { get; set; }
        public double? maxtemp { get; set; }
        public double? mintemp { get; set; }
        public double? meantemp { get; set; }
        public double? precipitation { get; set; }

    }
}
