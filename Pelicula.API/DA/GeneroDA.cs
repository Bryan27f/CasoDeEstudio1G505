using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Microsoft.Data.SqlClient;
using Dapper;

namespace DA
{
    public class GeneroDA : IGeneroDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;


        public GeneroDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        #region Operaciones

        public async Task<IEnumerable<GeneroResponse>> Obtener()
        {
            string query = @"ObtenerVehiculos";
            var resultadoConsulta = await  _sqlConnection.QueryAsync<GeneroResponse>(query);
            return resultadoConsulta;
        }
        #endregion

        #region Helpers

        #endregion
    }
}