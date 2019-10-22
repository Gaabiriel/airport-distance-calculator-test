using System.Net.Http;
using AutoFixture;
using AutoMapper;
using Moq;
using ProgrammingTest.Application.AppServices;
using ProgrammingTest.Application.Interfaces;
using ProgrammingTest.Controllers;
using ProgrammingTest.Domain.Entities;
using ProgrammingTest.Domain.Interfaces.Repositories;
using ProgrammingTest.Domain.Interfaces.Services;
using ProgrammingTest.Domain.Services;
using ProgrammingTest.Infra.Data.Repositories;
using ProgrammingTest.Web.AutoMapper;
using Xunit;

namespace ProgrammingTest.Tests
{

    public class AirportControllerTest
    {
        private readonly Fixture fixture;

        private readonly AirportController airportController;
        private readonly AirportAppService airportAppService;
        private readonly AirportService airportService;
        private readonly AirportRepository airportRepository;

        private readonly Mock<IAirportAppService> airportAppServiceMock;
        private readonly Mock<IAirportService> airportServiceMock;
        private readonly Mock<IAirportRepository> airportRepositoryMock;

        private readonly Mock<IMapper> imapperMock;
        private readonly Mock<IHttpClientFactory> ihttpClientMock;
        public AirportControllerTest()
        {
            this.fixture = new Fixture();
            this.airportAppServiceMock = new Mock<IAirportAppService>();
            this.airportServiceMock = new Mock<IAirportService>();
            this.airportRepositoryMock = new Mock<IAirportRepository>();
            this.imapperMock = new Mock<IMapper>();
            this.ihttpClientMock = new Mock<IHttpClientFactory>();

            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfig());
            });
            var mapper = mockMapper.CreateMapper();

            this.airportController = new AirportController(
               this.airportAppServiceMock.Object,
               mapper: mapper);

            this.airportAppService = new AirportAppService(
               this.airportServiceMock.Object);

            this.airportService = new AirportService(
               this.airportRepositoryMock.Object);

            this.airportRepository = new AirportRepository(
                           this.ihttpClientMock.Object);
        }

        [Fact]
        public async System.Threading.Tasks.Task Test_CalculateDistance_ShouldReturnDistanceInMilesAsync()
        {
            // 1. Arrange
            var firstAirportIata = "CWB";
            var firstAirport = new Airport
            {
                City = "Curitiba",
                Country = "Brazil",
                Location = new Location
                {
                    Lat = -25.535763,
                    Lon = -49.173298
                }
            };

            var secondAirportIata = "OPO";
            var secondAirport = new Airport
            {

                City = "Porto",
                Country = "Portugal",
                Location = new Location
                {
                    Lat = 41.237774,
                    Lon = -8.670272
                }
            };

            this.airportAppServiceMock
                .Setup(c => c.GetByIataAsync(firstAirportIata))
                .ReturnsAsync(firstAirport);

            this.airportAppServiceMock
              .Setup(c => c.GetByIataAsync(secondAirportIata))
              .ReturnsAsync(secondAirport);

            // 2. Act 
            var result = await this.airportController.CalculateDistance(firstAirportIata, secondAirportIata);

            // 3. Assert 
            Assert.NotNull(result.Value);
        }

        [Fact]
        public async System.Threading.Tasks.Task Test_CalculateDistance_WithoutOneAirport_ShouldReturnZeroAsync()
        {
            // 1. Arrange
            var firstAirportIata = "CWB";
            var firstAirport = new Airport
            {
                City = "Curitiba",
                Country = "Brazil",
                Location = new Location
                {
                    Lat = -25.535763,
                    Lon = -49.173298
                }
            };

            var secondAirportIata = "";

            this.airportAppServiceMock
              .Setup(c => c.GetByIataAsync(firstAirportIata))
              .ReturnsAsync(firstAirport);

            this.airportAppServiceMock
              .Setup(c => c.GetByIataAsync(secondAirportIata))
              .ReturnsAsync(new Airport());

            // 2. Act 
            var result = await this.airportController.CalculateDistance(firstAirportIata, secondAirportIata);

            // 3. Assert 
            Assert.False((double)result.Value > 0);
        }
    }
}
