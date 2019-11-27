using Microsoft.AspNetCore.Mvc;
using fullstackApp.Models;
using System.Linq;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using fullstackApp.Services;
using fullstackApp.ViewModel;

namespace fullstackApp.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUsers _users;

        public UserController(IUsers users) {
            _users = users;
        }

        [HttpGet]
        public ActionResult<List<User>> GetUsers()
        {
            var users = _users.GetAll();
            return new ObjectResult(users);
        }

        [HttpGet("{id:guid}")]
        public ActionResult<User> GetSingleUser(Guid id) {
            User user = _users.GetSingleUser(id);
            return new ObjectResult(user);
        }

        [HttpPost]
        public IActionResult Create([FromBody] UserEdit model)
        {
            if (model is null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (ModelState.IsValid)
            {
                var newUser = new User();
                newUser.Id = new Guid();
                newUser.Name = model.Name;
                newUser.Email = model.Email;
                newUser = _users.AddUser(newUser);
                return new ObjectResult(newUser);
            }
            else
            {
                return NotFound();
            }
        }

        // private readonly FullAppContext _context;

        // public UserController(FullAppContext context)
        // {
        //     _context = context;

        //     if (_context.Users.Count() == 0)
        //     {
        //         _context.Users.Add(new User { Name = "New Name", Email = "test@test.com" });
        //         _context.Users.Add(new User { Name = "New Name2", Email = "test@test.com" });
        //         _context.SaveChanges();
        //     }

        // }


        // [HttpGet]
        // public ActionResult<List<User>> GetAllUsers()
        // {
        //     return _context.Users.ToList();
        // }
        // [HttpGet("{id}", Name = "GetTodo")]
        // public ActionResult<User> GetUserById(Guid id)
        // {
        //     var item = _context.Users.Find(id);

        //     return item;
        // }


    }
}