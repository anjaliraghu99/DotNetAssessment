using System.ComponentModel.DataAnnotations;

namespace DotNetAssessment.Models
{
    public class login
    {
        [Key]
        public int id { get; set; }
        public string Email { get; set; }
        public string password { get; set; }
        public string Name { get; set; }
        public string phoneNumber { get; set; }
    }
}
