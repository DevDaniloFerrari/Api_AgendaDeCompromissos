using api.agenda.de.compromissos.Exceptions;
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
            if (_consultaRepository.ConsultaNoMesmoPeriodo(consulta))
                throw new ConsultasNoMesmoPeriodoException();

            if (_consultaRepository.ConsultaComDataFinalMenorQueDataInicial(consulta))
                throw new DataFinalMenorQueDataInicialException();

            _consultaRepository.AgendarConsulta(consulta);
        }
    }
}
