using api.agenda.de.compromissos.Interfaces.Repositories;
using api.agenda.de.compromissos.Models;

namespace api.agenda.de.compromissos.Services
{
    public class ConsultaService
    {

        private readonly IConsultaRepository _consultaRepository;

        public ConsultaService(IConsultaRepository consultaRepository)
        {
            _consultaRepository = consultaRepository;
        }

        public void AgendarConsulta(ConsultaModel consulta)
        {
            _consultaRepository.AgendarConsulta(consulta);
        }
    }
}
