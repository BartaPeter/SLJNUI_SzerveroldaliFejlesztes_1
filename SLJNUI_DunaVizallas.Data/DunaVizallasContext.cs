using Microsoft.EntityFrameworkCore;
using SLJNUI_DunaVizallas.Entities.Entity;

namespace SLJNUI_DunaVizallas.Data
{
    public class DunaVizallasContext : DbContext
    {
        public DbSet<Vizallas> Vizallas { get; set; }

        public DunaVizallasContext(DbContextOptions<DunaVizallasContext> opt) : base(opt) 
        {
            Database.EnsureCreated();
        }
    }
}
