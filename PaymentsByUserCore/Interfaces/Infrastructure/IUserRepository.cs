using PaymentsByUserCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsByUserCore.Interfaces.Infrastructure
{
    public interface IUserRepository
    {
        User GetById(int id);
        User CreateUser(User user);
        User UpdateUser(User user);
        List<User> GetUsers();
    }
}
