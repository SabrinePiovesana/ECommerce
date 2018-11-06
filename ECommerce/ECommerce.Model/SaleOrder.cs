
using System;
using System.Collections.Generic;
using System.Linq;

namespace ECommerce.Model
{
    public class SaleOrder
    {
        public int ID { get; set; }

        public Client Client { get; set; }

        public DateTime DateTime { get; set; }

        public double Total => this.Itens.Sum(x=>x.TotalItem);

        public IList<ItemSaleOrder> Itens { get; set; }

        public SaleOrder()
        {
            this.Itens = new List<ItemSaleOrder>();
        }
    }
}
