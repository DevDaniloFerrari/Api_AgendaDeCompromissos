using api.agenda.de.compromissos.Models;
using System;

namespace api.agenda.de.compromissos.Interfaces.Repositories
{
    public interface IConsultaRepository
    {
        void AgendarConsulta(ConsultaModel consulta);
        bool ConsultaNoMesmoPeriodo(ConsultaModel consulta);
        bool ConsultaComDataFinalMenorQueDataInicial(ConsultaModel consulta);
    }
}
