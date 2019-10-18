using api.agenda.de.compromissos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace api.agenda.de.compromissos.Repositories
{
    public class ConsultaRepository : Interfaces.Repositories.IConsultaRepository
    {
        public void AgendarConsulta(ConsultaModel consulta)
        {
            using (var connection = new SqlConnection("Data Source=localhost;Initial Catalog=Clinica;Integrated Security=True"))
            {
                connection.Open();

                using (var command = new SqlCommand("incluirConsulta", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@id_paciente", SqlDbType.Int).Value = consulta.Paciente.Id;
                    command.Parameters.Add("@Inicio", SqlDbType.Date).Value = consulta.Inicio;
                    command.Parameters.Add("@Fim", SqlDbType.Date).Value = consulta.Fim;
                    command.Parameters.Add("@Observacoes", SqlDbType.VarChar).Value = consulta.Observacoes;

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void FinalizarConsulta(int id)
        {
            using (var connection = new SqlConnection("Data Source=localhost;Initial Catalog=Clinica;Integrated Security=True"))
            {
                connection.Open();

                using (var command = new SqlCommand("finalizarConsulta", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void CancelarConsulta(int id)
        {
            using (var connection = new SqlConnection("Data Source=localhost;Initial Catalog=Clinica;Integrated Security=True"))
            {
                connection.Open();

                using (var command = new SqlCommand("cancelarConsulta", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public IList<ConsultaModel> ConsultasNoPeriodo(ConsultaModel consulta)
        {
            var consultas = new List<ConsultaModel>();

            using (var connection = new SqlConnection("Data Source=localhost;Initial Catalog=Clinica;Integrated Security=True"))
            {
                connection.Open();

                string query = "SELECT [id_consulta]" +
"      , Paciente.[id_paciente]" +
"	  , Paciente.Nome" +
"	  , Paciente.Nascimento" +
"      ,[Inicio]" +
"      ,[Fim]" +
"      ,[Observacoes]" +
"      ,[Finalizada]" +
"      ,[Cancelada]" +
"  FROM [dbo].[Consulta]" +
"  INNER JOIN Paciente ON Paciente.id_paciente = Consulta.id_paciente" +
"  WHERE" +
$"	Inicio <= {consulta.Inicio.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
"	AND" +
$"	Fim >= {consulta.Fim.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
"GO";

                using (var command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        consultas.Add(new ConsultaModel(
                                                        (int)reader["id_consulta"],
                                                        new PacienteModel( 
                                                                            (int)reader["id_paciente"],
                                                                            (string)reader["Nome"],
                                                                            (DateTime)reader["Nascimento"]),
                                                        (DateTime)reader["Inicio"],
                                                        (DateTime)reader["Fim"],
                                                        (string)reader["Observacoes"],
                                                        (bool)reader["Finalizada"],
                                                        (bool)reader["Cancelada"]
                                                       ));
                    }
                }

                connection.Close();
            }

            return consultas;
        }

    }
}
