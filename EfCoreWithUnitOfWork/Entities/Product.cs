using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreWithUnitOfWork.Entities
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public double UnitPrice { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
