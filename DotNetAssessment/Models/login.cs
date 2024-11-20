using System.ComponentModel.DataAnnotations;

namespace DotNetAssessment.Models
{
    public class login
    {
        [Key]
        public int id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
