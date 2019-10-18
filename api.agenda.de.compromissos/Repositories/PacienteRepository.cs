using api.agenda.de.compromissos.Interfaces.Repositories;
using api.agenda.de.compromissos.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace api.agenda.de.compromissos.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        public void Alterar(PacienteModel paciente)
        {
            using (var connection = new SqlConnection("Data Source=localhost;Initial Catalog=Clinica;Integrated Security=True"))
            {
                connection.Open();

                using (var command = new SqlCommand("alterarPaciente",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = paciente.Id;
                    command.Parameters.Add("@Nome", SqlDbType.VarChar, 50).Value = paciente.Nome;
                    command.Parameters.Add("@Nascimento", SqlDbType.Date).Value = paciente.Nascimento;

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public IEnumerable<PacienteModel> Buscar()
        {
            var pacientes = new List<PacienteModel>();

            using (var connection = new SqlConnection("Data Source=localhost;Initial Catalog=Clinica;Integrated Security=True"))
            {
                connection.Open();

                string query = "SELECT [id_paciente],[Nome],[Nascimento]FROM[dbo].[Paciente]";

                using (var command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pacientes.Add(new PacienteModel((int)reader["id_paciente"], (string)reader["Nome"], (DateTime)reader["Nascimento"]));
                        }
                    }
                }

                connection.Close();
            }

            return pacientes;
        }

        public void Excluir(int id)
        {
            using (var connection = new SqlConnection("Data Source=localhost;Initial Catalog=Clinica;Integrated Security=True"))
            {
                connection.Open();

                using (var command = new SqlCommand("excluirPaciente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public void Incluir(PacienteModel paciente)
        {
            using (var connection = new SqlConnection("Data Source=localhost;Initial Catalog=Clinica;Integrated Security=True"))
            {
                connection.Open();

                using (var command = new SqlCommand("incluirPaciente", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Nome", SqlDbType.VarChar, 50).Value = paciente.Nome;
                    command.Parameters.Add("@Nascimento", SqlDbType.Date).Value = paciente.Nascimento;

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
