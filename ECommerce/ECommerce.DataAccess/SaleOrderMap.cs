using ECommerce.Model;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.DataAccess
{
    public class SaleOrderMap : EntityTypeConfiguration<SaleOrder>
    {
        public SaleOrderMap()
        {
            ToTable("SalesOrders");
            HasKey(x => x.ID);

            Property(x => x.DateTime).IsRequired();
            Ignore(x => x.Total);

            HasRequired(x => x.Client)
                .WithRequiredPrincipal();

            HasMany(x => x.Itens)                
                .WithMany()
                .Map(x=>x.MapRightKey("SaleOrderID")
                         .ToTable("ItensSalesOrders"));
        }
    }
}
