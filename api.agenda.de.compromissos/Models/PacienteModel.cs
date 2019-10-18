using api.agenda.de.compromissos.Models.Abstracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace api.agenda.de.compromissos.Models
{
    [Serializable]
    public class PacienteModel : Pessoa
    {
        public PacienteModel() : base(){}

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
