using System;
using System.Collections.Generic;

namespace fullstackApp.Models
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<NoteTags> NoteTags { get; set; }
    }
}
