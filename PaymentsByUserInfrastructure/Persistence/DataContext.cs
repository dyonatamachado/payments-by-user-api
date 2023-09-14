using PaymentsByUserCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsByUserInfrastructure.Persistence
{
    public class DataContext
    {
        public DataContext()
        {
            Users = new List<User>();
            Payments = new List<Payment>();
        }

        public List<User> Users { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
