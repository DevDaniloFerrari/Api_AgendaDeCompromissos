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
            consultas.Add(consulta);
        }
        public bool ConsultaNoMesmoPeriodo(ConsultaModel consulta)
        {
            if (consultas.Any(c => (c.Inicio < consulta.Inicio && c.Fim > consulta.Fim)
                || (c.Inicio > consulta.Inicio && c.Fim < consulta.Fim)
                || (c.Inicio > consulta.Inicio && c.Fim > consulta.Fim)
                || (c.Inicio < consulta.Inicio && c.Fim < consulta.Fim)))
                return true;
            return false;
        }
        public bool ConsultaComDataFinalMenorQueDataInicial(ConsultaModel consulta)
        {
            if (consulta.Fim < consulta.Inicio)
                return true;
            return false;
        }

        
    }
}
