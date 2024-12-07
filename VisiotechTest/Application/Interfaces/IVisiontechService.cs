using VisiotechTest.Domain.Entities;

namespace VisiotechTest.Application.Interfaces
{
    public interface IVisiontechService
    {
        Task<IEnumerable<int>> GetManagersIds();

        Task<IEnumerable<string>> GetManagersTaxnumbersOrderByManagerName();

        Task<IEnumerable<GrapeArea>> GetGrapesArea();

        Task<IEnumerable<ManagerArea>> GetManagerTotalArea();

        Task<IEnumerable<VineyardsByManagerDto>> GetVineyardsByManeger();
    }
}
