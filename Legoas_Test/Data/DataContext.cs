using Legoas_Test.Models;
using Legoas_Test.Models.ManyToMany;
using Microsoft.EntityFrameworkCore;

namespace Legoas_Test.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<AkunModel> Akun { get; set; }
        public DbSet<PenggunaModel> Pengguna { get; set; }
        public DbSet<Peran> Peran { get; set; }
        public DbSet<Akun_Layar> Akun_Layar { get; set; }
        public DbSet<Akun_Peran> Akun_Peran { get; set; }
        public DbSet<Pengguna_Kantor> Pengguna_Kantor { get; set; }


    }
}
