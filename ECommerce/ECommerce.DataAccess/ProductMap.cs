using ECommerce.Model;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.DataAccess
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Products");
            HasKey(x => x.ID);
            Property(x => x.Name).IsRequired();
            Property(x => x.Price).IsRequired();
        }
    }
}
