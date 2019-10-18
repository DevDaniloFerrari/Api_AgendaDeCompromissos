using api.agenda.de.compromissos.Models;
using System.Collections.Generic;

namespace api.agenda.de.compromissos.Interfaces.Services
{
    public interface IPacienteService
    {
        void Incluir(PacienteModel paciente);
        void Alterar(PacienteModel paciente);
        void Excluir(int id);
        IEnumerable<PacienteModel> Buscar();
    }
}
