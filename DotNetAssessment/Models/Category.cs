using System.ComponentModel.DataAnnotations;

namespace DotNetAssessment.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string? CategoryName { get; set; }
    }
}
