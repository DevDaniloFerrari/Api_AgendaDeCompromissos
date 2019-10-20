using api.agenda.de.compromissos.Exceptions;
using api.agenda.de.compromissos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace api.agenda.de.compromissos.Repositories
{
    public class ConsultaRepository : Interfaces.Repositories.IConsultaRepository
    {
        public ConsultaModel AgendarConsulta(ConsultaModel consulta)
        {
            ConsultaModel consultaAgendada;

            using (var connection = new SqlConnection(Configuration.getConnectionString()))
            {
                try
                {
                    connection.Open();

                    using (var command = new SqlCommand("incluirConsulta", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@id_paciente", SqlDbType.Int).Value = consulta.Paciente.Id;
                        command.Parameters.Add("@Inicio", SqlDbType.Date).Value = consulta.Inicio;
                        command.Parameters.Add("@Fim", SqlDbType.Date).Value = consulta.Fim;
                        command.Parameters.Add("@Observacoes", SqlDbType.VarChar).Value = consulta.Observacoes;

                        int id = (int)command.ExecuteScalar();

                        consultaAgendada = this.Consulta(id);
                    }
                }
                catch(SqlException)
                {
                    throw new NaoFoiPossivelConectarNoBancoDeDadosException();
                }
                finally
                {
                    connection.Close();
                }
            }

            return consultaAgendada;
        }

        public void FinalizarConsulta(int id)
        {

            using (var connection = new SqlConnection(Configuration.getConnectionString()))
            {
                try
                {
                    connection.Open();

                    using (var command = new SqlCommand("finalizarConsulta", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                        command.ExecuteNonQuery();

                    }
                }
                catch(SqlException)
                {
                    throw new NaoFoiPossivelConectarNoBancoDeDadosException();
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        public void CancelarConsulta(int id)
        {

            using (var connection = new SqlConnection(Configuration.getConnectionString()))
            {
                try
                {
                    connection.Open();

                    using (var command = new SqlCommand("cancelarConsulta", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                        command.ExecuteNonQuery();
                    }
                }
                catch(SqlException)
                {
                    throw new NaoFoiPossivelConectarNoBancoDeDadosException();
                }
                finally
                {
                    connection.Close();
                }
            }

        }

        public IList<ConsultaModel> Consultas()
        {
            var consultas = new List<ConsultaModel>();

            using (var connection = new SqlConnection(Configuration.getConnectionString()))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT [id_consulta]" +
                                    "      ,[id_paciente]" +
                                    "	   ,[Nome]" +
                                    "	   ,[Nascimento]" +
                                    "      ,[Inicio]" +
                                    "      ,[Fim]" +
                                    "      ,[Observacoes]" +
                                    "      ,[Finalizada]" +
                                    "      ,[Cancelada]" +
                                    "  FROM [vw].[Consulta]";

                    using (var command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (!reader.HasRows)
                                throw new NenhumaConsultaCadastradaException();

                            while (reader.Read())
                            {
                                consultas.Add(new ConsultaModel(
                                                                (int)reader["id_consulta"],
                                                                new PacienteModel(
                                                                                    (int)reader["id_paciente"],
                                                                                    (string)reader["Nome"],
                                                                                    (DateTime)reader["Nascimento"]),
                                                                new SituacaoModel(
                                                                                    (bool)reader["Finalizada"],
                                                                                    (bool)reader["Cancelada"]
                                                                                    ),
                                                                (DateTime)reader["Inicio"],
                                                                (DateTime)reader["Fim"],
                                                                (string)reader["Observacoes"]
                                                               ));
                            }
                        }
                    }
                }
                catch(SqlException)
                {
                    throw new NaoFoiPossivelConectarNoBancoDeDadosException();
                }
                finally
                {
                    connection.Close();
                }
            }

            return consultas;
        }

        public ConsultaModel Consulta(int id)
        {
            ConsultaModel consulta;

            using (var connection = new SqlConnection(Configuration.getConnectionString()))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT [id_consulta]" +
                                    "      ,[id_paciente]" +
                                    "	   ,[Nome]" +
                                    "	   ,[Nascimento]" +
                                    "      ,[Inicio]" +
                                    "      ,[Fim]" +
                                    "      ,[Observacoes]" +
                                    "      ,[Finalizada]" +
                                    "      ,[Cancelada]" +
                                    $"  FROM [vw].[Consulta] WHERE [id_consulta]={id}";

                    using (var command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (!reader.HasRows)
                                throw new ConsultaNaoExisteException();

                            reader.Read();

                            consulta = new ConsultaModel(
                                                        (int)reader["id_consulta"],
                                                        new PacienteModel(
                                                                            (int)reader["id_paciente"],
                                                                            (string)reader["Nome"],
                                                                            (DateTime)reader["Nascimento"]),
                                                        new SituacaoModel(
                                                                        (bool)reader["Finalizada"],
                                                                        (bool)reader["Cancelada"]
                                                                        ),
                                                        (DateTime)reader["Inicio"],
                                                        (DateTime)reader["Fim"],
                                                        (string)reader["Observacoes"]
                                                        );

                        }
                    }
                }
                catch(SqlException)
                {
                    throw new NaoFoiPossivelConectarNoBancoDeDadosException();
                }
                finally
                {
                    connection.Close();
                }
            }

            return consulta;
        }
    }
}
