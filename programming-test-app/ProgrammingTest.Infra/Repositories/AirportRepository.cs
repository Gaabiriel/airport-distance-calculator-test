using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProgrammingTest.Domain.Entities;
using ProgrammingTest.Domain.Interfaces.Repositories;

namespace ProgrammingTest.Infra.Data.Repositories
{
    public class AirportRepository : IAirportRepository
    {

        private readonly IHttpClientFactory httpClientFactory;
        public AirportRepository(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }
        public async Task<Airport> GetByIataAsync(string iata)
        {

            var request = new HttpRequestMessage(HttpMethod.Get,
                $"https://places-dev.cteleport.com/airports/{iata}");

            var client = httpClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Airport>(result);
            }
            return new Airport();
        }
    }
}
