using PaymentsByUserCore.DomainExceptions;
using PaymentsByUserCore.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsByUserCore.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public PaymentTypeEnum GridA { get; private set; }
        public PaymentTypeEnum GridB { get; private set; }
        public PaymentTypeEnum GridC { get; private set; }

        public User(int id, string name, PaymentTypeEnum gridA, PaymentTypeEnum gridB, PaymentTypeEnum gridC)
        {
            ValidateGrid(gridA, gridB, gridC);

            Id = id;
            Name = name;
            GridA = gridA;
            GridB = gridB;
            GridC = gridC;
        }

        public void UpdateGrid(PaymentTypeEnum gridA, PaymentTypeEnum gridB, PaymentTypeEnum gridC)
        {
            ValidateGrid(gridA, gridB, gridC);

            GridA = gridA;
            GridB = gridB;
            GridC = gridC;
        }

        public void ValidateGrid(PaymentTypeEnum gridA, PaymentTypeEnum gridB, PaymentTypeEnum gridC)
        {
            if (gridA == gridB || gridA == gridC || gridB == gridC)
                throw new DuplicatedGridException("Duplicated grid values");
        }
    }
}
