using System.ComponentModel.DataAnnotations;

namespace DotNetAssessment.Models
{
    public class Product
    {
        [Key]
        public int Id {  get; set; }
        public string? ProductName { get; set; }
        public int Price { get; set; }
        public string? ProductDescription { get; set; }

        public string? ProductCategory { get; set;}
        public string? ProductValue { get; set; }

    }
}
