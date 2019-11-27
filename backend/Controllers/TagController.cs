
using System;
using System.Collections.Generic;
using fullstackApp.Models;
using fullstackApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace fullstackApp.Controllers {
    [Route("api/tags")]

    public class TagController : ControllerBase {
        private ITags _tags;

        public TagController(ITags tags) {
            _tags = tags;
        }

        [HttpGet]
        public ActionResult<List<Tag>> GetTags() {
            var tags = _tags.Getall();
            return new ObjectResult(tags);
        }

        [HttpPost]
        public ActionResult Create() {
            var newTag = new Tag();
            newTag.Id = new Guid();
            newTag.Name = "Html";
            newTag = _tags.AddTag(newTag);

            return new ObjectResult(newTag);
        }
    }
}