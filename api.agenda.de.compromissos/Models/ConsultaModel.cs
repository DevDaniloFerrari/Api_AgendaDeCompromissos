using System;

namespace api.agenda.de.compromissos.Models
{
    [Serializable]
    public class ConsultaModel
    {
        public ConsultaModel() { }
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
        public PacienteModel Paciente { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public String Observacoes { get; set; }
        public bool Finalizada { get; set; }
        public bool Cancelada { get; set; }
    }
}
