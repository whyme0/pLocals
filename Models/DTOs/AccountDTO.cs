using System.ComponentModel.DataAnnotations;

namespace pLocals.Models.DTOs
{
    public class AccountDTO
    {
        public Note? Note { get; set; }
        
        [DataType(DataType.Text)]
        public string? Title { get; set; }
        
        [DataType(DataType.Text)]
        public string? Login { get; set; }
        
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
