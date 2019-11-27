using System;
using System.Collections.Generic;

namespace fullstackApp.ViewModel {
    public class VmUser {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<NoteList> NoteList { get; set; }

    }
}