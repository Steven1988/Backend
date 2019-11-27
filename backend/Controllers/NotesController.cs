
using System;
using System.Collections.Generic;
using System.Linq;
using fullstackApp.Models;
using fullstackApp.Services;
using fullstackApp.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace fullstackApp.Controllers
{
    // [ApiController]
    [Route("api/notes")]
    public class NotesController : ControllerBase
    {
        // private readonly FullAppContext _context;
        private INotes _notes;
        private ITags _tags;

        public NotesController(INotes notes, ITags tags)
        {
            _notes = notes;
            // _users = users;
            // _tags = tags
        }

        // Get all notes
        [HttpGet]
        public ActionResult<List<Note>> GetNotes()
        {
            var notes = _notes.GetAll();
            // var user = _users.GetSingleUser();

            return new ObjectResult(notes);
        }

        // Get a specific note
        // GET api/notes/{id}
        [HttpGet("{id:guid}")]
        public ActionResult GetSingleNote(Guid id)
        {
            Note note = _notes.GetSingleNote(id);
            return new ObjectResult(note);
        }

        // Create a new note
        [HttpPost]
        public IActionResult Create([FromBody] NoteEdit model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (ModelState.IsValid)
            {
                // var user = _users.GetSingleUser(model.UserId);

                var tags = new List<Tag>();
                var existingTags = _tags.Getall();
                

                foreach(var t in model.Tags) {
                    Console.WriteLine(t);
                    // existingTags.FirstOrDefault(n => n.Name =);
                }

                var newNote = new Note();
                newNote.Id = new Guid();
                newNote.Title = model.Title;
                newNote.Body = model.Body;
                newNote.Created = model.Created;
                newNote.UserId = model.UserId;
                // newNote.NoteTags = model.Tags;
                newNote = _notes.AddNote(newNote);
                return new ObjectResult(newNote);
            }
            else
            {
                return NotFound();
            }
        }

        // Delete method for deleting a note
        [Route("notes{id}")]
        [HttpDelete("{id}")]
        public ActionResult<Note> Delete(Guid id)
        {
            Console.WriteLine(id);
            if (ModelState.IsValid)
            {
                Note note = _notes.GetSingleNote(id);
                _notes.DeleteNote(note);
                return new StatusCodeResult(200);
            }
            else
            {
                return NotFound();
            }
        }
    }
}