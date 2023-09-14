using PaymentsByUserCore.DomainExceptions;
using PaymentsByUserCore.Entities;
using PaymentsByUserCore.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsByUserInfrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;
        public UserRepository(DataContext context)
        {
            _users = context.Users;
        }

        public User CreateUser(User user)
        {
            if (_users.Any(u => u.Id == user.Id)) 
                throw new DuplicatedUserException("Duplicated user");

            _users.Add(user);
            return user;
        }

        public User GetById(int id)
        {
            var user = _users.SingleOrDefault(u => u.Id == id);
            if (user == null) 
                throw new NotFoundException("User not found");

            return user;
        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public User UpdateUser(User user)
        {
            var userIndexAtList = _users.FindIndex(u => u.Id == user.Id);
            if(userIndexAtList == -1)
                throw new NotFoundException("User not found");

            _users[userIndexAtList] = user;
            return user;
        }
    }
}
