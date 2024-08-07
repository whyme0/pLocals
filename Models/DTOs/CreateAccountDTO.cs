﻿using System.ComponentModel.DataAnnotations;

namespace pLocals.Models.DTOs
{
    public class CreateAccountDTO
    {
        [DataType(DataType.MultilineText)]
        public string? NoteText { get; set; }

        [DataType(DataType.Text)]
        [Required]
        public string Title { get; set; }
        
        [DataType(DataType.Text)]
        [Required]
        public string Login { get; set; }
        
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
    }
}
