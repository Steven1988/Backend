using System;
using System.Collections.Generic;
using System.Linq;
using fullstackApp.Data;
using fullstackApp.Models;

namespace fullstackApp.Services
{
    public class SqlTagData: ITags
    {
        private MyWikiDbContext _context;

        public SqlTagData(MyWikiDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Tag> Getall()
        {
            return _context.Tags.OrderBy(t => t.Name);
        }

        public Tag AddTag(Tag tag) {
            _context.Tags.Add(tag);
            _context.SaveChanges();
            return tag;
        }
    }
}