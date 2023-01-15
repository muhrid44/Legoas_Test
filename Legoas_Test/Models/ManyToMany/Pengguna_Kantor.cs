namespace Legoas_Test.Models.ManyToMany
{
    public class Pengguna_Kantor
    {
        public int Id { get; set; }
        public int Pengguna_Id { get; set; }
        public int Kantor_Id { get; set; }
    }
}
