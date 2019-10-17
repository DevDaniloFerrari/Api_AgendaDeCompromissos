using api.agenda.de.compromissos.Models.Abstracts;
using System;

namespace api.agenda.de.compromissos.Models
{
    public class PacienteModel : Pessoa
    {
        public PacienteModel(string nome, DateTime nascimento) : base(nome, nascimento)
        {
        }

        public PacienteModel(int id,string nome, DateTime nascimento) : base(nome, nascimento)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
