using System.Data.Entity;

namespace Model.DataBaseModel
{
    public class UserContext: DbContext
    {
        public UserContext(): base("DbConnection")
        {
        }

        public DbSet<People> Peoples { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Goods> Goods { get; set; }
    }
}