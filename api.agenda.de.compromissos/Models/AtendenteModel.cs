using api.agenda.de.compromissos.Models.Abstracts;
using System;

namespace api.agenda.de.compromissos.Models
{
    public class AtendenteModel : Pessoa
    {
        public AtendenteModel(string nome, DateTime nascimento) : base(nome, nascimento)
        {
        }
    }
}
