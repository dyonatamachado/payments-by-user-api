using PaymentsByUserCore.DTOs;
using PaymentsByUserCore.Entities;
using PaymentsByUserCore.Interfaces.Application;
using PaymentsByUserCore.Interfaces.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsByUserApplication
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User CreateUser(User user)
        {
            return _userRepository.CreateUser(user);
        }

        public User GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public List<User> GetUsers()
        {
            return _userRepository.GetUsers();
        }

        public void UpdateUserGrid(int userId, GridDTO grid)
        {
            var user = _userRepository.GetById(userId);
            user.UpdateGrid(grid.GridA, grid.GridB, grid.GridC);
            _userRepository.UpdateUser(user);
        }
    }
}
