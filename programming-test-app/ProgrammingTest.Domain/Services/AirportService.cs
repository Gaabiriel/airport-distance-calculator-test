using System.Threading.Tasks;
using ProgrammingTest.Domain.Entities;
using ProgrammingTest.Domain.Interfaces.Repositories;
using ProgrammingTest.Domain.Interfaces.Services;

namespace ProgrammingTest.Domain.Services
{
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository airportRepository;
        public AirportService(IAirportRepository airportRepository)
        {
            this.airportRepository = airportRepository;
        }

        public Task<Airport> GetByIataAsync(string iata)
        {
            return this.airportRepository.GetByIataAsync(iata);
        }
    }
}
