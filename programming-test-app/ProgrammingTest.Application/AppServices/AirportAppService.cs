using System.Threading.Tasks;
using ProgrammingTest.Application.Interfaces;
using ProgrammingTest.Domain.Entities;
using ProgrammingTest.Domain.Interfaces.Services;

namespace ProgrammingTest.Application.AppServices
{
    public class AirportAppService : IAirportAppService
    {
        private readonly IAirportService airportService;
        public AirportAppService(IAirportService airportService)
        {
            this.airportService = airportService;
        }

        public Task<Airport> GetByIataAsync(string iata)
        {
            return this.airportService.GetByIataAsync(iata);
        }
    }
}
