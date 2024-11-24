using System.ComponentModel.DataAnnotations;

namespace DotNetAssessment.Models
{
    public class Product
    {
        [Key]
        public string Id {  get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public string ProductDescription { get; set; }

    }
}
