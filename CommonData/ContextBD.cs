using System.Data.Entity;

namespace CommonData
{
    public class ContextBD : DbContext
    {
        public ContextBD() : base("DbConnectionString")
        {
        }
        public DbSet<UserBD> UsersBD { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductState> ProductStates { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}
