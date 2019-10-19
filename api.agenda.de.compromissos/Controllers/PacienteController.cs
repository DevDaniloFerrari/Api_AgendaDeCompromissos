using api.agenda.de.compromissos.Interfaces.Services;
using api.agenda.de.compromissos.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace api.agenda.de.compromissos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {

        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet]
        public string ObterPacientes()
        {
            return JsonConvert.SerializeObject(_pacienteService.Buscar());
        }

        [HttpPost]
        public IActionResult IncuirPaciente([FromBody] PacienteModel paciente)
        {
            try
            {
                _pacienteService.Incluir(paciente);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult AlterarPaciente(int id, [FromBody] PacienteModel paciente)
        {
            if (id == paciente.Id)
                try
                {
                    _pacienteService.Alterar(paciente);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return StatusCode(500, ex.Message);
                }
            else
                return StatusCode(406, "Id informado na URL não corresponde com o id passado no body");

        }

        [HttpDelete("{id}")]
        public IActionResult DeletarPaciente(int id)
        {
            try
            {
                _pacienteService.Excluir(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
