using ECommerce.Model;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.DataAccess
{
    public class ItemSaleOrderMap : EntityTypeConfiguration<ItemSaleOrder>
    {
        public ItemSaleOrderMap()
        {
            ToTable("ItensSalesOrders");
            HasKey(x => x.ID);

            Property(x => x.Quantity).IsRequired();
            Ignore(x => x.TotalItem);

            HasRequired(x => x.Product)
                .WithRequiredPrincipal();
        }    
    }
}
