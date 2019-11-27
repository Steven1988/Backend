using System;
using System.Collections.Generic;
using fullstackApp.Models;

namespace fullstackApp.Services
{
    public interface INotes
    {
        IEnumerable<Note> GetAll();
        Note GetSingleNote(Guid id);
        Note AddNote(Note note);
        Note DeleteNote(Note note);
    }
}