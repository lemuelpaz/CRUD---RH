using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using Projeto_D3.Interface;
using System;

namespace Projeto_D3.Service
{
    public class CandService : ICandService
    {

        private readonly string _connectionDBString;
        public CandService(IConfiguration _configuration)
        {
            _connectionDBString = _configuration.GetConnectionString("OracleDBConnection");

        }

        public void Adicionar(string NomeCand, string Nivel, string Localizacao, string Telefone, string Tecnologia)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(_connectionDBString))
                {
                    con.Open();

                    OracleCommand cmd = new OracleCommand("insert into lemuel.aplica_cad" +
                                                          "(NM_NOME,TP_NIVEL,LOCALIZACAO,TELEFONE,TECNOLOGIA) " +
                                                          "values('" + NomeCand + "','" + Nivel + "','" + Localizacao + "','" + Telefone + "','" + Tecnologia + "')", con);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}
