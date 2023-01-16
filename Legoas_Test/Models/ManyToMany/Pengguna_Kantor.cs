namespace Legoas_Test.Models.ManyToMany
{
    public class Pengguna_Kantor
    {
        public int id { get; set; }
        public int pengguna_id { get; set; }
        public int kantor_id { get; set; }
    }
}
