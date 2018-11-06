using ECommerce.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ECommerce.DataAccess
{
    public class DataContext: DbContext
    {
        public DataContext()
                    : base("DataContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SaleOrder> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            /*Definimos usando reflexão que toda propriedade que contenha
            "Id", seja dada como chave primária, caso não tenha sido especificado*/
            modelBuilder.Properties()
                   .Where(p => p.Name == "Id")
                   .Configure(p => p.IsKey());

            /*Toda propriedade do tipo string na entidade POCO seja configurado como VARCHAR no SQL Server*/
            modelBuilder.Properties<string>()
                   .Configure(p => p.HasColumnType("varchar"));

            /*Toda propriedade do tipo string na entidade POCO seja configurado como VARCHAR (100) no banco de dados */
            modelBuilder.Properties<string>()
                  .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new ProductMap());
            //modelBuilder.Configurations.Add(new SaleOrderMap());
            //modelBuilder.Configurations.Add(new ItemSaleOrderMap());

        }
    }
}
