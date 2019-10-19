using api.agenda.de.compromissos.Models;
using System.Collections.Generic;

namespace api.agenda.de.compromissos.Interfaces.Services
{
    public interface IConsultaService
    {
        void AgendarConsulta(ConsultaModel consulta);
        void FinalizarConsulta(int id);
        void CancelarConsulta(int id);
        bool ConsultaComDataFinalMenorQueDataInicial(ConsultaModel consulta);
        bool ConsultaNoMesmoPeriodo(ConsultaModel consulta);
        IList<ConsultaModel> Consultas();
    }
}
