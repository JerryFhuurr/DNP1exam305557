using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace VolumeWeb.VolumeCalculator
{
    public class VolumeResult
    {
        [Required, Range(0, int.MaxValue)]
        [JsonPropertyName("id"), Key]
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("height")]
        public double Height { get; set; }
        [JsonPropertyName("radius")]
        public double Radius { get; set; }
        [JsonPropertyName("volume")]
        public double Volume { get; set; }

    }
}
