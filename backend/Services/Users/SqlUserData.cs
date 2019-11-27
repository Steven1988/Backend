using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fullstackApp.Data;
using fullstackApp.Models;
using fullstackApp.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace fullstackApp.Services {
    public class SqlUserData : IUsers {
        private MyWikiDbContext _context;

        public SqlUserData(MyWikiDbContext context) {
            _context = context;
        } 

        public IEnumerable<User> GetAll()
        {
            return _context.Users.OrderBy(u => u.Name);
        }

        public User GetSingleUser(Guid id) {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);
            return user;
        }

        public User AddUser(User user) {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public async Task<User> FindByEmailAsync(string email) {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email);
            return user;
        }
    }
}