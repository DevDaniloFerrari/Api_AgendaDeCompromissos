using System;

namespace api.agenda.de.compromissos.Models
{
    [Serializable]
    public class SituacaoModel
    {
        public SituacaoModel()
        {
        }

        public SituacaoModel(bool finalizada, bool cancelada)
        {
            Finalizada = finalizada;
            Cancelada = cancelada;
        }

        public bool Finalizada { get; set; }
        public bool Cancelada { get; set; }
    }
}
