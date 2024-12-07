using Microsoft.Extensions.Logging;
using Moq;
using VisiotechTest.Application.Interfaces;
using VisiotechTest.Application.Services;
using VisiotechTest.Domain.Entities;

namespace Visiotech.Test
{
    public class UnitVisiotechServicesTest
    {
        [Fact]
        public async Task GetManagersIdsAsync_ReturnIDs()
        {
            var mockVisiotechRepository = new Mock<IVisiontechRespository>();
            var idsExpect = new List<int>() { 1, 2, 3 };
            var mockIds = new List<int>() { 1, 2, 3 };
            var mockLogging = new Mock<ILogger<VisiotechService>>();
            mockVisiotechRepository.Setup(repo => repo.GetManagersIds())
                .ReturnsAsync(idsExpect);                

            var service = new VisiotechService(mockVisiotechRepository.Object, mockLogging.Object);

            var result = await service.GetManagersIds();
            Assert.NotNull(result);
            Assert.Equal(idsExpect, result);
            Assert.Equal(idsExpect.Count(), result.Count());
        }

        [Fact]
        public async Task GetManagersTaxNumbersAsync_ReturnTaxNumbers()
        {
            var mockVisiotechRepository = new Mock<IVisiontechRespository>();
            var taxNumbersExpect = new List<string>() { "11","22", "33" };
            var mockTaxNumber = new List<string>() { "11", "22", "33" };
            var mockLogging = new Mock<ILogger<VisiotechService>>();
            mockVisiotechRepository.Setup(repo => repo.GetManagersTaxnumbersOrderByManagerName())
                .ReturnsAsync(taxNumbersExpect);

            var service = new VisiotechService(mockVisiotechRepository.Object, mockLogging.Object);

            var result = await service.GetManagersTaxnumbersOrderByManagerName();
            Assert.NotNull(result);
            Assert.Equal(taxNumbersExpect, result);
            Assert.Equal(taxNumbersExpect.Count(), result.Count());
        }

        [Fact]
        public async Task GetGreapesAreaAsync_ReturnGreapesArea()
        {
            var mockVisiotechRepository = new Mock<IVisiontechRespository>();
            var taxNumbersExpect = new List<GrapeArea>() 
            { 
               new() { GrapeName = "GrapeName1", TotalArea = 100 },
               new() { GrapeName = "GrapeName2", TotalArea = 200 }
            };
            var mockTaxNumber = new List<GrapeArea>()
            {
                new() { GrapeName = "GrapeName1", TotalArea = 100 },
                new() { GrapeName = "GrapeName2", TotalArea = 200 }
            };

            var mockLogging = new Mock<ILogger<VisiotechService>>();
            mockVisiotechRepository.Setup(repo => repo.GetGrapesArea())
                .ReturnsAsync(taxNumbersExpect);

            var service = new VisiotechService(mockVisiotechRepository.Object, mockLogging.Object);

            var result = await service.GetGrapesArea();
            Assert.NotNull(result);
            Assert.Equal(taxNumbersExpect, result);
            Assert.Equal(taxNumbersExpect.Count(), result.Count());
        }

        [Fact]
        public async Task GetManagersTotalAreaAsync_ReturnManagersTotalArea()
        {
            var mockVisiotechRepository = new Mock<IVisiontechRespository>();
            var taxNumbersExpect = new List<ManagerArea>()
            {
               new() { ManagerName = "Manager1", TotalArea = 100 },
               new() { ManagerName = "Manager2", TotalArea = 200 }
            };
            var mockTaxNumber = new List<ManagerArea>()
            {
                new() { ManagerName = "Manager1", TotalArea = 100 },
                new() { ManagerName = "Manager2", TotalArea = 200 }
            };

            var mockLogging = new Mock<ILogger<VisiotechService>>();
            mockVisiotechRepository.Setup(repo => repo.GetManagerTotalArea())
                .ReturnsAsync(taxNumbersExpect);

            var service = new VisiotechService(mockVisiotechRepository.Object, mockLogging.Object);

            var result = await service.GetManagerTotalArea();
            Assert.NotNull(result);
            Assert.Equal(taxNumbersExpect, result);
            Assert.Equal(taxNumbersExpect.Count(), result.Count());
        }

        [Fact]
        public async Task GetVineyardsManagersAsync_ReturnManagersVineyardsDto()
        {
            var mockVisiotechRepository = new Mock<IVisiontechRespository>();
            var vineyardsExpectDto = new List<VineyardsByManagerDto>()
            {
                new()
                {
                    VineyardsName = "Vineyards1",
                    ManagerNames = ["Manager1", "Manager2"]
                },
                new()
                {
                    VineyardsName = "Vineyards2",
                    ManagerNames = ["Manager3"]
                },
            };

            var vineyardsExpect = new List<VineyardsByManager>()
            {
                new()
                {
                    ManagerName = "Manager1",
                    VineyardsName = "Vineyards1"
                },
                new()
                {
                    ManagerName = "Manager2",
                    VineyardsName = "Vineyards1"
                },
                new()
                {
                    ManagerName = "Manager3",
                    VineyardsName = "Vineyards2"
                }
            };
            var mockLogging = new Mock<ILogger<VisiotechService>>();

            mockVisiotechRepository.Setup(repo => repo.GetVineyardsByManeger())
                .ReturnsAsync(vineyardsExpect);

            var service = new VisiotechService(mockVisiotechRepository.Object, mockLogging.Object);
            
            var result = await service.GetVineyardsByManeger();
            Assert.NotNull(result);
            Assert.Equal(vineyardsExpectDto[0].VineyardsName, result.ToList()[0].VineyardsName);
            Assert.Equal(vineyardsExpectDto.Count, result.ToList().Count);
            Assert.Equal(vineyardsExpectDto[0].ManagerNames.Count, result.ToList()[0].ManagerNames.Count);
        }
    }
}