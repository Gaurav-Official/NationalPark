using WebApp_NP.Models;
using WebApp_NP.Repository.IRepository;

namespace WebApp_NP.Repository
{
    public class TrailRepository:Repository<Trail>,ITrailRepository
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TrailRepository(IHttpClientFactory httpClientFactory):base(httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory;
            
        }
    }
}
