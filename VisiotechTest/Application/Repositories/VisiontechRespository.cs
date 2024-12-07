using Dapper;
using Microsoft.Data.SqlClient;
using VisiotechTest.Application.Interfaces;
using VisiotechTest.Domain.Entities;

namespace VisiotechTest.Application.Repositories
{
    public class VisiontechRespository(IConfiguration configuration) : IVisiontechRespository
    {
        private readonly string _connectionString = configuration.GetConnectionString("sqlserver");

        public async Task<IEnumerable<int>> GetManagersIds()
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = "SELECT Id FROM dbo.Managers WITH(NOLOCK)";

            return await connection.QueryAsync<int>(sql);
        }

        public async Task<IEnumerable<string>> GetManagersTaxnumbersOrderByManagerName()
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = "SELECT TaxNumber FROM dbo.Managers WITH(NOLOCK) Order by Name";

            return await connection.QueryAsync<string>(sql);
        }

        public async Task<IEnumerable<GrapeArea>> GetGrapesArea()
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = "SELECT gp.[Name] GrapeName, SUM(pc.area) TotalArea " +
                " FROM dbo.Parcels pc WITH(NOLOCK)" +
                " INNER JOIN dbo.Grapes gp WITH(NOLOCK)" +
                " ON gp.ID = pc.GrapeId " +
                " GROUP BY gp.[Name]";

            return await connection.QueryAsync<GrapeArea>(sql);
        }

        public async Task<IEnumerable<ManagerArea>> GetManagerTotalArea()
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = "SELECT mn.[Name] ManagerName, SUM(pc.area) TotalArea" +
                " FROM dbo.Parcels pc WITH(NOLOCK)" +
                " INNER JOIN dbo.Managers mn WITH(NOLOCK)" +
                " ON mn.ID = pc.ManagerId" +
                " GROUP BY mn.[Name]";

            return await connection.QueryAsync<ManagerArea>(sql);
        }

        public async Task<IEnumerable<VineyardsByManager>> GetVineyardsByManeger()
        {
            using var connection = new SqlConnection(_connectionString);

            var sql = "SELECT vn.[Name] VineyardsName, mn.[Name] ManagerName " +
                " FROM dbo.Parcels pc  WITH(NOLOCK)" +
                " INNER JOIN dbo.Managers mn WITH(NOLOCK)" +
                " ON mn.ID = pc.ManagerId" +
                " INNER JOIN dbo.Vineyards vn" +
                " ON vn.Id = pc.VineyarId" +
                " ORDER BY  vn.[Name], mn.[Name] ASC";

            return await connection.QueryAsync<VineyardsByManager>(sql);
        }   
    }
}
