using api.agenda.de.compromissos.Models;
using System.Collections.Generic;

namespace api.agenda.de.compromissos.Interfaces.Repositories
{
    public interface IConsultaRepository
    {
        void AgendarConsulta(ConsultaModel consulta);
        void FinalizarConsulta(int id);
        void CancelarConsulta(int id);
        IList<ConsultaModel> Consultas();
    }
}
