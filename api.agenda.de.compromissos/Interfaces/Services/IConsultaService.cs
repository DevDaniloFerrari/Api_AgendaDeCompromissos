using api.agenda.de.compromissos.Models;

namespace api.agenda.de.compromissos.Interfaces.Services
{
    public interface IConsultaService
    {
        void AgendarConsulta(ConsultaModel consulta);
        void FinalizarConsulta(int id);
        void CancelarConsulta(int id);
        bool ConsultaComDataFinalMenorQueDataInicial(ConsultaModel consulta);
        bool ConsultaNoMesmoPeriodo(ConsultaModel consulta);
    }
}
