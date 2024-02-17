namespace pLocals.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public int AccountId { get; set; }
        public virtual Account? Account { get; set; }
        
        public string? Text { get; set; }
    }
}
