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
        }

        public PacienteModel Paciente { get; private set; }
        public DateTime Inicio { get; private set; }
        public DateTime Fim { get; private set; }
        public String Observacoes { get; private set; }
    }
}
