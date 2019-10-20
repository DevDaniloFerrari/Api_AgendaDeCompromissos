using api.agenda.de.compromissos.Exceptions;
using api.agenda.de.compromissos.Interfaces.Services;
using api.agenda.de.compromissos.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace api.agenda.de.compromissos.Controllers
{
    [Route("api/pacientes")]
    [ApiController]
    public class PacienteController : ControllerBase
    {

        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpGet()]
        public string ObterPacientes()
        {
            try
            {
                return JsonConvert.SerializeObject(_pacienteService.Buscar());
            }
            catch (NenhumPacienteCadastradoException exception)
            {
                return exception.Message;
            }
            catch (NaoFoiPossivelConectarNoBancoDeDadosException exception)
            {
                return exception.Message;
            }
        }

        [HttpGet("{id}")]
        public string ObterPaciente(int id)
        {
            try
            {
                return JsonConvert.SerializeObject(_pacienteService.Buscar(id));
            }
            catch (PacienteNaoExisteException exception)
            {
                return exception.Message;
            }
            catch (NaoFoiPossivelConectarNoBancoDeDadosException exception)
            {
                return exception.Message;
            }
        }

        [HttpPost()]
        public JsonResult IncuirPaciente([FromBody] PacienteModel paciente)
        {
            try
            {
                int id = _pacienteService.Incluir(paciente);

                Response.Headers.Add("Location", $"api/pacientes/{id}");

                return new JsonResult("Paciente incluido com sucesso") { StatusCode = 201 };
            }
            catch (Exception exception)
            {
                return new JsonResult(exception.Message) { StatusCode = 500 };
            }
        }

        [HttpPut("{id}")]
        public JsonResult AlterarPaciente(int id, [FromBody] PacienteModel paciente)
        {
            if (id == paciente.Id)
                try
                {
                    PacienteModel pacienteAlterado = _pacienteService.Alterar(paciente);

                    return new JsonResult(pacienteAlterado) { StatusCode = 201 };
                }
                catch (Exception exception)
                {
                    return new JsonResult(exception.Message) { StatusCode = 500 };
                }
            else
                return new JsonResult("Id informado na URL não corresponde com o id passado no body") { StatusCode = 406 };

        }

        [HttpDelete("{id}")]
        public JsonResult DeletarPaciente(int id)
        {
            try
            {
                _pacienteService.Excluir(id);
                return new JsonResult("Excluido com sucesso") { StatusCode = 200 };
            }
            catch (Exception exception)
            {
                return new JsonResult(exception.Message) { StatusCode = 500 };
            }
        }
    }
}
