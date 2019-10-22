using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProgrammingTest.Application.Interfaces;
using ProgrammingTest.Infra.CrossCutting;
using ProgrammingTest.Web.Model;

namespace ProgrammingTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly IAirportAppService airportAppService;
        private readonly IMapper mapper;
        public AirportController(IAirportAppService airportService, IMapper mapper)
        {
            this.airportAppService = airportService;
            this.mapper = mapper;
        }

        // GET: api/Airport/CalculateDistance/
        [HttpGet("CalculateDistance")]
        public async Task<JsonResult> CalculateDistance(string firstIata, string secondIata)
        {
            var resultFirstAirport = await airportAppService.GetByIataAsync(firstIata);
            AirportModel firstAirportModel = mapper.Map<AirportModel>(resultFirstAirport);

            var resultSecondAirport = await airportAppService.GetByIataAsync(secondIata);
            AirportModel secondAirportModel = mapper.Map<AirportModel>(resultSecondAirport);

            return new JsonResult(ValidateAirportDistanceResult(firstAirportModel, secondAirportModel));
        }

        private double ValidateAirportDistanceResult(AirportModel firstAirportModel, AirportModel secondAirportModel)
        {
            var distance = 0.0;

            if (firstAirportModel.Lat != 0
               && firstAirportModel.Lon != 0
               && secondAirportModel.Lat != 0
               && secondAirportModel.Lon != 0)
            {

                distance = DistanceCalculator.GetDistanceFromLatLonInMl(firstAirportModel.Lat, firstAirportModel.Lon, secondAirportModel.Lat, secondAirportModel.Lon);
                return distance;
            }
            return distance;
        }
    }
}
