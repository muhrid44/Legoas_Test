using Legoas_Test.Models.ManyToMany;

namespace Legoas_Test.Models
{
    public class RegisterModel
    {
        public AkunModel Akun { get; set; }
        public PenggunaModel Pengguna { get; set; }
        public List<Kantor> Kantor { get; set; }
        public List<Layar> Layar { get; set; }
        public List<Peran> Peran { get; set; }
        //public Akun_Layar  Akun_Layar { get; set; }
        //public Akun_Peran Akun_Peran { get; set; }
        //public Pengguna_Kantor Pengguna_Kantor { get; set; }
    }
}
