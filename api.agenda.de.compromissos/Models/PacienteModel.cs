using api.agenda.de.compromissos.Models.Abstracts;
using System;

namespace api.agenda.de.compromissos.Models
{
    public class PacienteModel : Pessoa
    {
        public PacienteModel(string nome, DateTime nascimento) : base(nome, nascimento)
        {
        }
    }
}
