using Microsoft.EntityFrameworkCore;
using register_and_login.Models;

namespace register_and_login.Models
{
    public class Mycontext:DbContext
    {
        public Mycontext(DbContextOptions<Mycontext>options):base(options) { }

        public DbSet<Register> register{  get; set; }
        public DbSet<product> product1 { get; set; }
                
        public DbSet<category> category { get; set; }
        public DbSet<register_and_login.Models.login> login { get; set; } = default!;
    }
}
