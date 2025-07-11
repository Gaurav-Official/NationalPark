﻿using Newtonsoft.Json;
using System.Text;
using WebApp_NP.Repository.IRepository;

namespace WebApp_NP.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public Repository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;            
        }
        public async Task<bool> CreateAsync(string url, T objToCreate)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url);
            if(objToCreate != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(objToCreate)
                    , Encoding.UTF8, "application/json");
            }
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage httpResponseMessage=await client.SendAsync(request);
            if(httpResponseMessage.StatusCode == System.Net.HttpStatusCode.Created)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteAsync(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Delete,
                url + "/" + id.ToString());
            
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage httpResponseMessage = await client.SendAsync(request);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<T>> GetAllAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage httpResponseMessage= await client.SendAsync(request);
            if(httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonstring = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<T>>(jsonstring);
            }
            return null;

        }

        public async Task<T> GetAsync(string url, int id)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, 
                url + "/" + id.ToString());
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage httpResponseMessage = await client.SendAsync(request);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var jsonstring = await httpResponseMessage.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(jsonstring);
            }
            return null;
        }

        public async Task<bool> UpdateAsync(string url, T objToUpdate)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, url);
            if (objToUpdate != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(objToUpdate)
                    , Encoding.UTF8, "application/json");
            }
            var client = _httpClientFactory.CreateClient();
            HttpResponseMessage httpResponseMessage = await client.SendAsync(request);
            if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }
            return false;
        }
    }
}
