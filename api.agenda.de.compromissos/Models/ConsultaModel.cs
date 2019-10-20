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
            Situacao = new SituacaoModel { Finalizada = false, Cancelada = false };
        }

        public ConsultaModel(int id, PacienteModel paciente, SituacaoModel situacao, DateTime inicio, DateTime fim, string observacoes)
        {
            Id = id;
            Paciente = paciente;
            Situacao = situacao;
            Inicio = inicio;
            Fim = fim;
            Observacoes = observacoes;
        }

        public int Id { get; set; }
        public PacienteModel Paciente { get; set; }
        public SituacaoModel Situacao { get; set; }
        public DateTime Inicio { get; set; }
        public DateTime Fim { get; set; }
        public String Observacoes { get; set; }

    }
}
