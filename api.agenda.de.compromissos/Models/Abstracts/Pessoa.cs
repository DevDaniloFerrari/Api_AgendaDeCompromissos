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

        protected String Nome { get; set; }
        protected DateTime Nascimento { get; set; }
    }
}
