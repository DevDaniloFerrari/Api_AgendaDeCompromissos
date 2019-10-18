using System;
using System.ComponentModel.DataAnnotations;

namespace api.agenda.de.compromissos.Models.Abstracts
{
    [Serializable]
    public abstract class Pessoa
    {
        protected Pessoa(){}

        protected Pessoa(string nome, DateTime nascimento)
        {
            Nome = nome;
            Nascimento = nascimento;
        }

        public String Nome { get; set; }
        public DateTime Nascimento { get; set; }
    }
}
