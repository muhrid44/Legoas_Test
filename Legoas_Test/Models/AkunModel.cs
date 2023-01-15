using System.ComponentModel.DataAnnotations;

namespace Legoas_Test.Models
{
    public class AkunModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public int Id_Pengguna { get; set; }
    }
}
