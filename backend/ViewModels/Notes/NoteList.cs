using System;
using fullstackApp.Models;

namespace fullstackApp.ViewModel {
    public class NoteList {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Created { get; set; }
        public VmUser User { get; set; }
    }
}