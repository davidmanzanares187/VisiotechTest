using VisiotechTest.Application.Interfaces;
using VisiotechTest.Domain.Entities;

namespace VisiotechTest.Application.Services
{
    public class VisiotechService: IVisiontechService
    {        
        private readonly IVisiontechRespository _repository;
        private readonly ILogger<VisiotechService> _logger;

        public VisiotechService(IVisiontechRespository repository, ILogger<VisiotechService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<GrapeArea>> GetGrapesArea()
        {
            try
            {
                return await _repository.GetGrapesArea();
            }
            catch (Exception ex)
            {
                _logger.LogError($" GetGrapesArea Error: {ex.Message }"); 
                
                return Enumerable.Empty<GrapeArea>();
            }            
        }

        public async Task<IEnumerable<int>> GetManagersIds()
        {
            try
            {
                return await _repository.GetManagersIds();
            }
            catch (Exception ex)
            {
                _logger.LogError($" GetManagersIds Error: {ex.Message}");

                return Enumerable.Empty<int>();
            }
        }

        public async Task<IEnumerable<string>> GetManagersTaxnumbersOrderByManagerName()
        {
            try
            {
                return await _repository.GetManagersTaxnumbersOrderByManagerName();
            }
            catch (Exception ex)
            {
                _logger.LogError($" GetManagersTaxnumbersOrderByManagerName Error: {ex.Message}");

                return Enumerable.Empty<string>();
            }
        }

        public async Task<IEnumerable<ManagerArea>> GetManagerTotalArea()
        {
            try
            {
                return await _repository.GetManagerTotalArea();
            }
            catch (Exception ex)
            {
                _logger.LogError($" GetGrapesArea Error: {ex.Message}");

                return Enumerable.Empty<ManagerArea>();
            }
        }

        public async Task<IEnumerable<VineyardsByManagerDto>> GetVineyardsByManeger()
        {
            try
            {
                var vineyardsWithDuplicated = await _repository.GetVineyardsByManeger();

                var vineyardsWithManagers = vineyardsWithDuplicated
                    .GroupBy(vineyard => vineyard.VineyardsName)
                    .Select(group => new VineyardsByManagerDto()
                    {
                        VineyardsName = group.Key,
                        ManagerNames = group.Select(manager => manager.ManagerName).ToList()
                    });

                return vineyardsWithManagers;
            }
            catch (Exception ex)
            {
                _logger.LogError($" GetVineyardsByManeger Error: {ex.Message}");

                return Enumerable.Empty<VineyardsByManagerDto>();
            }
        }
    }
}
