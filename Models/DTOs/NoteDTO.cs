using System.ComponentModel.DataAnnotations;

namespace pLocals.Models.DTOs
{
    public class NoteDTO
    {
        public int AccountId { get; set; }
        
        [DataType(DataType.MultilineText)]
        [Required]
        public string Text { get; set; }
    }
}
