using System;

namespace api.agenda.de.compromissos.Models.Abstracts
{
    public abstract class Pessoa
    {
        protected Pessoa(string nome, DateTime nascimento)
        {
            Nome = nome;
            Nascimento = nascimento;
        }

        public String Nome { get; private set; }
        public DateTime Nascimento { get; private set; }
    }
}
