using System.ComponentModel.DataAnnotations;

namespace microservice1
{
    public class PlatformCreateDto
    {
        [Required]
        public string Name { get; set; }
        public string Publisher { get; set; }
        public decimal Cost { get; set; }
    }
}