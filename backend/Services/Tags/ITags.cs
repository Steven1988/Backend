using System;
using System.Collections.Generic;
using fullstackApp.Models;

namespace fullstackApp.Services
{
    public interface ITags
    {
        IEnumerable<Tag> Getall();

        Tag AddTag(Tag tag);
    }

}