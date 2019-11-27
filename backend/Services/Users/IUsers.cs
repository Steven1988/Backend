using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using fullstackApp.Models;
using fullstackApp.ViewModel;

namespace fullstackApp.Services {
    public interface IUsers {
        IEnumerable<User> GetAll();

        User GetSingleUser(Guid id);

        User AddUser(User user);

        Task<User> FindByEmailAsync(string email);
    }
}