using System;
using System.Collections.Generic;
using fullstackApp.Models;

namespace fullstackApp.ViewModel
{
    public class NoteEdit
    {

        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public Guid UserId { get; set; }
        public List<string> Tags { get; set; }

    }
}