using api.agenda.de.compromissos.Models;
using System.Collections.Generic;

namespace api.agenda.de.compromissos.Interfaces.Repositories
{
    public interface IPacienteRepository
    {
        int Incluir(PacienteModel paciente);
        PacienteModel Alterar(PacienteModel paciente);
        void Excluir(int id);
        IEnumerable<PacienteModel> Buscar();
        PacienteModel Buscar(int id);
    }
}
