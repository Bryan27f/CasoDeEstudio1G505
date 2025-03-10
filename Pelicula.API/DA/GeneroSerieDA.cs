using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Microsoft.Data.SqlClient;
using Dapper;

namespace DA
{
    public class GeneroSerieDA : IGeneroSerieDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;


        public GeneroSerieDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        #region Operaciones

        public async Task<IEnumerable<GeneroSerieResponse>> Obtener()
        {
            string query = @"ObtenerSeries";
            var resultadoConsulta = await  _sqlConnection.QueryAsync<GeneroSerieResponse>(query);
            return resultadoConsulta;
        }
        #endregion

        #region Helpers

        #endregion
    }
}