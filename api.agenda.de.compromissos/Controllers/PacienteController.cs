using api.agenda.de.compromissos.Interfaces.Repositories;
using api.agenda.de.compromissos.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace api.agenda.de.compromissos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {

        private readonly IPacienteRepository _pacienteRepository;

        public PacienteController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        // GET api/values
        [HttpGet]
        public string Get()
        {
            return JsonConvert.SerializeObject(_pacienteRepository.Buscar());
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] PacienteModel paciente)
        {
            _pacienteRepository.Incluir(paciente);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] PacienteModel paciente)
        {
            if (id == paciente.Id)
                _pacienteRepository.Alterar(paciente);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _pacienteRepository.Excluir(id);
        }
    }
}
