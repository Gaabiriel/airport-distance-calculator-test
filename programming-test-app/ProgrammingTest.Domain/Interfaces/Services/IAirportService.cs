using System.Threading.Tasks;
using ProgrammingTest.Domain.Entities;

namespace ProgrammingTest.Domain.Interfaces.Services
{
    public interface IAirportService
    {
        Task<Airport> GetByIataAsync(string iata);
    }
}