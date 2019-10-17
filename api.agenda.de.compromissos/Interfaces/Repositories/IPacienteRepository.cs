using api.agenda.de.compromissos.Models;
using System.Collections.Generic;

namespace api.agenda.de.compromissos.Interfaces.Repositories
{
    public interface IPacienteRepository
    {
        void Incluir(PacienteModel paciente);
        void Alterar(PacienteModel paciente);
        void Excluir(int id);
        IList<PacienteModel> Buscar();
    }
}
