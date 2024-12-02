using System.ComponentModel.DataAnnotations;

namespace DotNetAssessment.Models
{
    public class Quentity
    {
        [Key]
        public int Id { get; set; }
        public string? value { get; set; }
    }
}
