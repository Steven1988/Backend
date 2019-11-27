using System;

namespace fullstackApp.Models {
    public class NoteTags {
        public Guid NoteId { get; set; }
        public Note Note { get; set; }
        public Guid TagId { get; set; }
        public Tag Tag { get; set; }

    }
}