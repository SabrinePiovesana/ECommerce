using ECommerce.Model;
using System.Data.Entity.ModelConfiguration;

namespace ECommerce.DataAccess
{
    public class ClientMap: EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            ToTable("Clients");
            HasKey(x => x.ID);
            Property(x => x.Name).IsRequired();
        }
    }
}
