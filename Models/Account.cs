namespace pLocals.Models
{
    public class Account
    {
        public Account()
        {
            Notes = new HashSet<Note>();
        }
        
        public int AccountId { get; set; }
        public virtual ICollection<Note> Notes { get; set; } = new HashSet<Note>();
        
        public string? Title { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }

    }
}
