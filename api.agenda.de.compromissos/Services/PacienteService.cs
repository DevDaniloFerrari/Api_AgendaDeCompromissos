using api.agenda.de.compromissos.Interfaces.Repositories;
using api.agenda.de.compromissos.Interfaces.Services;
using api.agenda.de.compromissos.Models;
using System.Collections.Generic;

namespace api.agenda.de.compromissos.Services
{
    public class PacienteService : IPacienteService
    {

        IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public void Alterar(PacienteModel paciente)
        {
            _pacienteRepository.Alterar(paciente);
        }

        public IEnumerable<PacienteModel> Buscar()
        {
            return _pacienteRepository.Buscar();
        }

        public void Excluir(int id)
        {
            _pacienteRepository.Excluir(id);
        }

        public void Incluir(PacienteModel paciente)
        {
            _pacienteRepository.Incluir(paciente);
        }
    }
}
