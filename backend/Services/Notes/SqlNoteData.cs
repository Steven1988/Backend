using System;
using System.Collections.Generic;
using System.Linq;
using fullstackApp.Data;
using fullstackApp.Models;

namespace fullstackApp.Services
{
    public class SqlNoteData : INotes
    {
        private MyWikiDbContext _context;

        public SqlNoteData(MyWikiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Note> GetAll()
        {
            return _context.Notes.OrderBy(n => n.Title);
        }
        public Note GetSingleNote(Guid id)
        {
            var note = _context.Notes.SingleOrDefault(n => n.Id == id);
            return note;
        }

        public Note AddNote(Note note)
        {
            _context.Notes.Add(note);

            var tags = note.NoteTags;
            note.NoteTags.AddRange(tags);

            if(note.NoteTags != null) {
                // _context.NoteTags.Add();
            } 
            _context.SaveChanges();
            return note;
        }

        public Note DeleteNote(Note note)
        {
            _context.Remove(note);
            _context.SaveChanges();
            return note;
        }
    }
}