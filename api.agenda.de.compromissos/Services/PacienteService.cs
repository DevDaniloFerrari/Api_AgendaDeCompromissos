using api.agenda.de.compromissos.Interfaces.Services;
using api.agenda.de.compromissos.Models;
using System.Collections.Generic;

namespace api.agenda.de.compromissos.Services
{
    public class PacienteService : IPacienteService
    {

        IPacienteService _pacienteService;

        public PacienteService(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        public void Alterar(PacienteModel paciente)
        {
            _pacienteService.Alterar(paciente);
        }

        public IList<PacienteModel> Buscar()
        {
            return _pacienteService.Buscar();
        }

        public void Excluir(int id)
        {
            _pacienteService.Excluir(id);
        }

        public void Incluir(PacienteModel paciente)
        {
            _pacienteService.Incluir(paciente);
        }
    }
}
