using System;
using System.Collections.Generic;

namespace fullstackApp.Models
{
    public class Note
    {
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Body { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public Guid UserId { get; set; }
        // public User User {get; set; }
        public List<NoteTags> NoteTags { get; set;}
    }
}