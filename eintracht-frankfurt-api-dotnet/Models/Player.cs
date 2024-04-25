using System.ComponentModel.DataAnnotations;

namespace eintracht_frankfurt_api_dotnet.Models
{
    public class Player
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public int BirthYear { get; set; }
    }
}
