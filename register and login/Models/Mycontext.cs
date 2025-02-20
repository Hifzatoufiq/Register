using Microsoft.EntityFrameworkCore;
using register_and_login.Models;

namespace register_and_login.Models
{
    public class Mycontext:DbContext
    {
        public Mycontext(DbContextOptions<Mycontext>options):base(options) { }

        public DbSet<Register> register1 {  get; set; }
        public DbSet<register_and_login.Models.login> login { get; set; } = default!;
    }
}
