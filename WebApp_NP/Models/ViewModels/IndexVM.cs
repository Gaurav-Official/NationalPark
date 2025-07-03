namespace WebApp_NP.Models.ViewModels
{
    public class IndexVM
    {
        public IEnumerable<NationalPark> nationalParkList { get; set; }
        public IEnumerable<Trail> TrailList { get; set; }

    }
}
