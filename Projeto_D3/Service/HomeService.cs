using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using Projeto_D3.Interface;
using System;
using Projeto_D3.Models;
using System.Collections.Generic;

namespace Projeto_D3.Service
{
    public class HomeService : IHomeService
    {

        private readonly string _connectionDBString;
        public HomeService(IConfiguration _configuration)
        {
            _connectionDBString = _configuration.GetConnectionString("OracleDBConnection");

        }

        public void AddCadastro(string CRM, string Nome)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(_connectionDBString))
                {
                    con.Open();
                    
                    OracleCommand cmd = new OracleCommand("insert into lemuel.aplica" + 
                                                          "(TP_VAGA,TP_NIVEL) " +
                                                          "values('" + CRM + "','" + Nome + "')", con);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public IEnumerable<Cadastro> GetMonitorar()
        {
            List<Cadastro> Lista = new List<Cadastro>();
            using (OracleConnection con = new OracleConnection(_connectionDBString))
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("select * from lemuel.aplica", con);
                OracleDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Cadastro Vagas = new Cadastro
                    {
                        CRM = rdr["TP_VAGA"].ToString(),
                        Nome = rdr["TP_NIVEL"].ToString(),                       
                    };
                    Lista.Add(Vagas);

                }

                cmd.Dispose();
                con.Dispose();
            }
            return Lista;
        }


        public void Adicionar(string NomeCand, string Nivel, string Localizacao, string Telefone)
        {
            try
            {
                using (OracleConnection con = new OracleConnection(_connectionDBString))
                {
                    con.Open();

                    OracleCommand cmd = new OracleCommand("insert into lemuel.aplica_cad" +
                                                          "(NM_NOME,TP_NIVEL,LOCALIZACAO,TELEFONE) " +
                                                          "values('" + NomeCand + "','" + Nivel + "','" + Localizacao + "','" + Telefone + "')", con);
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
