using System.Threading.Tasks;
using ProgrammingTest.Domain.Entities;

namespace ProgrammingTest.Domain.Interfaces.Repositories
{
    public interface IAirportRepository
    {
        Task<Airport> GetByIataAsync(string iata);
    }
}
