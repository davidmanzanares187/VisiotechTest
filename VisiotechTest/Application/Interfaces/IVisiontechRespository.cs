using VisiotechTest.Domain.Entities;

namespace VisiotechTest.Application.Interfaces
{
    public interface IVisiontechRespository
    {
        Task<IEnumerable<int>> GetManagersIds();

        Task<IEnumerable<string>> GetManagersTaxnumbersOrderByManagerName();

        Task<IEnumerable<GrapeArea>> GetGrapesArea();

        Task<IEnumerable<ManagerArea>> GetManagerTotalArea();

        Task<IEnumerable<VineyardsByManager>> GetVineyardsByManeger();
    }
}
