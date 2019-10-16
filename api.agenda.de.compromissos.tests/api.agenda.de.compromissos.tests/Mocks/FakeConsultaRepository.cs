using api.agenda.de.compromissos.Exceptions;
using api.agenda.de.compromissos.Interfaces.Repositories;
using api.agenda.de.compromissos.Models;
using System.Collections.Generic;
using System.Linq;

namespace api.agenda.de.compromissos.tests.Mocks
{
    class FakeConsultaRepository : IConsultaRepository
    {

        IList<ConsultaModel> consultas = new List<ConsultaModel>();

        public void AgendarConsulta(ConsultaModel consulta)
        {
            if (consultas.Any(c => (c.Inicio < consulta.Inicio && c.Fim > consulta.Fim)
                || (c.Inicio > consulta.Inicio && c.Fim < consulta.Fim)
                || (c.Inicio > consulta.Inicio && c.Fim > consulta.Fim)
                || (c.Inicio < consulta.Inicio && c.Fim < consulta.Fim)))
                throw new DuasConsultasNoMesmoPeriodoException();

            if (consulta.Fim < consulta.Inicio)
                throw new DataFinalMenorQueDataInicialException();

            consultas.Add(consulta);
        }
    }
}
