using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using fullstackApp.ViewModel;

namespace fullstackApp.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<Note> Notes { get; set; }

    }
}