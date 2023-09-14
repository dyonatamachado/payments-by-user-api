using PaymentsByUserCore.DTOs;
using PaymentsByUserCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsByUserCore.Interfaces.Application
{
    public interface IUserService
    {
        public User CreateUser(User user);
        public void UpdateUserGrid(int userId, GridDTO grid);
        User GetById(int id);
        List<User> GetUsers();
    }
}
