
namespace ECommerce.Model
{
    public class ItemSaleOrder
    {
        public int ID { get; set; }

        public int SaleOrderID { get; set; }

        public SaleOrder SaleOrder { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }

        public double TotalItem => this.Quantity * (this.Product?.Price ??0);
    }
}
