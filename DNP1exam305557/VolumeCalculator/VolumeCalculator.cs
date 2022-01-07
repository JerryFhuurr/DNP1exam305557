using System;
using System.Text.Json.Serialization;

namespace VolumeWebService.VolumeCalculator
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

        public static double CalculateVolumeCylinder2(double r, double h)
        {
            return Math.PI * Math.Pow(r, 2) * h;
        }

        public static double CalculateVolumeCone2(double r, double h)
        {
            return (double)1 / 3 * Math.Pow(r, 2) * Math.PI * h;
        }
    }
}
