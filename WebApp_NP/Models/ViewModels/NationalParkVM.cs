namespace WebApp_NP.Models.ViewModels
{
    public class NationalParkVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public byte[] Picture { get; set; }
        public DateTime Established { get; set; }
    }
}
