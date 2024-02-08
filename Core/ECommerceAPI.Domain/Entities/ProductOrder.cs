using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Domain.Entities
{
    public class ProductOrder
    {
        public Guid ProductId { get; set; }
        public Guid OrderId{ get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}
