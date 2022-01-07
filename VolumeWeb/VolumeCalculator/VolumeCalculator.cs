﻿using System;
using System.Text.Json.Serialization;

namespace VolumeWeb.VolumeCalculator
{
    public class VolumeCalculator
    {
        [JsonPropertyName("r")]
        public double R { get; set; }
        [JsonPropertyName("h")]
        public double H { get; set; }
        public VolumeCalculator (double r, double h)
        {
            this.R = r;
            this.H = h;
        }

        public double CalculateVolumeCylinder()
        {
            return Math.PI * Math.Pow(R, 2) * H;
        }

        public double CalculateVolumeCone()
        {
            return (double)1 / 3 * Math.Pow(R, 2) * Math.PI * H;
        }
    }
}