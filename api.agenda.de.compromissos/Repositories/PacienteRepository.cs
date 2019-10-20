using api.agenda.de.compromissos.Exceptions;
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
        public PacienteModel Alterar(PacienteModel paciente)
        {
            PacienteModel pacienteAlterado;

            using (var connection = new SqlConnection(Configuration.getConnectionString()))
            {
                connection.Open();

                using (var command = new SqlCommand("alterarPaciente",connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("@Id", SqlDbType.Int).Value = paciente.Id;
                    command.Parameters.Add("@Nome", SqlDbType.VarChar, 50).Value = paciente.Nome;
                    command.Parameters.Add("@Nascimento", SqlDbType.Date).Value = paciente.Nascimento;

                    command.ExecuteNonQuery();

                    pacienteAlterado = this.Buscar(paciente.Id);
                }

                connection.Close();
            }

            return pacienteAlterado;
        }

        public IEnumerable<PacienteModel> Buscar()
        {
            var pacientes = new List<PacienteModel>();

            using (var connection = new SqlConnection(Configuration.getConnectionString()))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT [id_paciente],[Nome],[Nascimento]FROM[vw].[Paciente]";

                    using (var command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (!reader.HasRows)
                                throw new NenhumPacienteCadastradoException();

                            while (reader.Read())
                            {
                                pacientes.Add(new PacienteModel((int)reader["id_paciente"], (string)reader["Nome"], (DateTime)reader["Nascimento"]));
                            }
                        }
                    }
                }catch(SqlException)
                {
                    throw new NaoFoiPossivelConectarNoBancoDeDadosException();
                }
                finally
                {
                    connection.Close();
                }
            }

            return pacientes;
        }

        public PacienteModel Buscar(int id)
        {
            PacienteModel paciente;
            using (var connection = new SqlConnection(Configuration.getConnectionString()))
            {
                try
                {
                    connection.Open();

                    string query = $"SELECT [id_paciente],[Nome],[Nascimento]FROM[vw].[Paciente]WHERE[id_paciente]={id}";

                    using (var command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();

                            if (!reader.HasRows)
                                throw new PacienteNaoExisteException();

                            paciente = new PacienteModel((int)reader["id_paciente"], (string)reader["Nome"], (DateTime)reader["Nascimento"]);
                        }
                    }
                }
                catch (SqlException)
                {
                    throw new NaoFoiPossivelConectarNoBancoDeDadosException();
                }
                finally
                {
                    connection.Close();
                }
            }

            return paciente;
        }

        public void Excluir(int id)
        {
            using (var connection = new SqlConnection(Configuration.getConnectionString()))
            {
                try
                {
                    connection.Open();

                    using (var command = new SqlCommand("excluirPaciente", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                        command.ExecuteNonQuery();
                    }
                }
                catch (SqlException)
                {
                    throw new NaoFoiPossivelConectarNoBancoDeDadosException();
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        public int Incluir(PacienteModel paciente)
        {
            int idPaciente;

            using (var connection = new SqlConnection(Configuration.getConnectionString()))
            {
                try
                {
                    connection.Open();

                    using (var command = new SqlCommand("incluirPaciente", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@Nome", SqlDbType.VarChar, 50).Value = paciente.Nome;
                        command.Parameters.Add("@Nascimento", SqlDbType.Date).Value = paciente.Nascimento;

                        idPaciente = (int)command.ExecuteScalar();
                    }
                }
                catch (SqlException)
                {
                    throw new NaoFoiPossivelConectarNoBancoDeDadosException();
                }
                finally
                {
                    connection.Close();
                }
            }

            return idPaciente;
        }
    }
}
