using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonData
{
    public class ContextBD: DbContext
    {
        public ContextBD() : base("DbConnectionString")
        {
        }
        public DbSet<UserBD> UsersBD { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
