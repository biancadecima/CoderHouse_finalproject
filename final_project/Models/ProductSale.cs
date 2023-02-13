using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project
{
    public class ProductSale
    {
        public long Id { get; set; }
        public int Stock { get; set; }
        public long ProductId { get; set; }
        public long SaleId { get; set; }
    }
}
