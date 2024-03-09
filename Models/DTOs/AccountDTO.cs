using System.ComponentModel.DataAnnotations;

namespace pLocals.Models.DTOs
{
    public class AccountDTO
    {
        public Note? Note { get; set; }
        
        [DataType(DataType.Text)]
        [Required]
        public string? Title { get; set; }
        
        [DataType(DataType.Text)]
        [Required]
        public string? Login { get; set; }
        
        [DataType(DataType.Password)]
        [Required]
        public string? Password { get; set; }
    }
}
