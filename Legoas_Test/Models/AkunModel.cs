using System.ComponentModel.DataAnnotations;

namespace Legoas_Test.Models
{
    public class AkunModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }

        //[DataType(DataType.Date)]
        //public DateTime createddate { get; set; }
        public int id_pengguna { get; set; }
    }
}
