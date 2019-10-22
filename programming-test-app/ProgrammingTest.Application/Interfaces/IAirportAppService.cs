using System.Threading.Tasks;
using ProgrammingTest.Domain.Entities;

namespace ProgrammingTest.Application.Interfaces
{
    public interface IAirportAppService
    {
        Task<Airport> GetByIataAsync(string iata);
    }
}
