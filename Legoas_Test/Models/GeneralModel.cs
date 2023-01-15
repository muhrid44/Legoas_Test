using System.ComponentModel.DataAnnotations;

namespace Legoas_Test.Models
{
    public class GeneralModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public int Id_Pengguna { get; set; }
        public PenggunaModel Pengguna { get; set; }
        public List<Peran> Peran { get; set; }
        public List<Peran> Layar { get; set; }
        public List<Peran> Kantor { get; set; }
    }
}
