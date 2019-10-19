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

        public void FinalizarConsulta(int id)
        {
            throw new System.NotImplementedException();
        }

        public void CancelarConsulta(int id)
        {
            throw new System.NotImplementedException();
        }

        public IList<ConsultaModel> Consultas()
        {
            return consultas;
        }
    }
}
