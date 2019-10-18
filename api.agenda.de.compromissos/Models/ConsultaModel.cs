using System;

namespace api.agenda.de.compromissos.Models
{
    public class ConsultaModel
    {
        public ConsultaModel(PacienteModel paciente, DateTime inicio, DateTime fim, string observacoes)
        {
            Paciente = paciente;
            Inicio = inicio;
            Fim = fim;
            Observacoes = observacoes;
            Finalizada = false;
            Cancelada = false;
        }

        public ConsultaModel(int id, PacienteModel paciente, DateTime inicio, DateTime fim, string observacoes, bool finalizada, bool cancelada)
        {
            Id = id;
            Paciente = paciente;
            Inicio = inicio;
            Fim = fim;
            Observacoes = observacoes;
            Finalizada = finalizada;
            Cancelada = cancelada;
        }

        public int Id { get; set; }
        public PacienteModel Paciente { get; private set; }
        public DateTime Inicio { get; private set; }
        public DateTime Fim { get; private set; }
        public String Observacoes { get; private set; }
        public bool Finalizada { get; set; }
        public bool Cancelada { get; set; }
    }
}
