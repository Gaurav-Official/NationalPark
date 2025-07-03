using System.Runtime.CompilerServices;
using WebApp_NP.Models;
using WebApp_NP.Repository.IRepository;

namespace WebApp_NP.Repository
{
    public class NationalParkRepository:Repository<NationalPark>,INationalParkRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public NationalParkRepository(IHttpClientFactory httpClientFactory)
            :base(httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory;            
        }
    }
}
