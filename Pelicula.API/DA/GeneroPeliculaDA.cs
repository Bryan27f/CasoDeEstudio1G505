using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Microsoft.Data.SqlClient;
using Dapper;

namespace DA
{
    public class GeneroPeliculaDA : IGeneroPeliculaDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;


        public GeneroPeliculaDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = _repositorioDapper.ObtenerRepositorio();
        }

        #region Operaciones

        public async Task<IEnumerable<GeneroPeliculaResponse>> Obtener()
        {
            string query = @"ObtenerVehiculos";
            var resultadoConsulta = await  _sqlConnection.QueryAsync<GeneroPeliculaResponse>(query);
            return resultadoConsulta;
        }
        #endregion

        #region Helpers

        #endregion
    }
}