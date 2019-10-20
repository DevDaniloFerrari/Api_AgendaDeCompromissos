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

        public PacienteModel Alterar(PacienteModel paciente)
        {
            return _pacienteRepository.Alterar(paciente);
        }

        public IEnumerable<PacienteModel> Buscar()
        {
            return _pacienteRepository.Buscar();
        }

        public PacienteModel Buscar(int id)
        {
            return _pacienteRepository.Buscar(id);
        }

        public void Excluir(int id)
        {
            _pacienteRepository.Excluir(id);
        }

        public int Incluir(PacienteModel paciente)
        {
            return _pacienteRepository.Incluir(paciente);
        }
    }
}
