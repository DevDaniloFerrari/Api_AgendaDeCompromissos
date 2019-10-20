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
        public JsonResult ObterPacientes()
        {
            try
            {
                return new JsonResult(_pacienteService.Buscar()) { StatusCode = 200};
            }
            catch (NenhumPacienteCadastradoException exception)
            {
                return new JsonResult(exception.Message) { StatusCode = 406 };
            }
            catch (NaoFoiPossivelConectarNoBancoDeDadosException exception)
            {
                return new JsonResult(exception.Message) { StatusCode = 406 };
            }
            catch (Exception exception)
            {
                return new JsonResult(exception.Message) { StatusCode = 500 };
            }
        }

        [HttpGet("{id}")]
        public JsonResult ObterPaciente(int id)
        {
            try
            {
                return new JsonResult(_pacienteService.Buscar(id)) { StatusCode = 200};
            }
            catch (PacienteNaoExisteException exception)
            {
                return new JsonResult(exception.Message) { StatusCode = 406 };
            }
            catch (NaoFoiPossivelConectarNoBancoDeDadosException exception)
            {
                return new JsonResult(exception.Message) { StatusCode = 406 };
            }
            catch (Exception exception)
            {
                return new JsonResult(exception.Message) { StatusCode = 406 };
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
            catch (NaoFoiPossivelConectarNoBancoDeDadosException exception)
            {
                return new JsonResult(exception.Message) { StatusCode = 406 };
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
                catch (PacienteNaoExisteException exception)
                {
                    return new JsonResult(exception.Message) { StatusCode = 406 };
                }
                catch (NaoFoiPossivelConectarNoBancoDeDadosException exception)
                {
                    return new JsonResult(exception.Message) { StatusCode = 406 };
                }
                catch (Exception exception)
                {
                    return new JsonResult(exception.Message) { StatusCode = 500 };
                }
            else
                return new JsonResult("Id informado na URL não corresponde com o id passado no Body") { StatusCode = 406 };

        }

        [HttpDelete("{id}")]
        public JsonResult DeletarPaciente(int id)
        {
            try
            {
                _pacienteService.Buscar(id);

                _pacienteService.Excluir(id);
                return new JsonResult("Excluido com sucesso") { StatusCode = 200 };
            }
            catch (PacienteNaoExisteException exception)
            {
                return new JsonResult(exception.Message) { StatusCode = 406 };
            }
            catch (NaoFoiPossivelConectarNoBancoDeDadosException exception)
            {
                return new JsonResult(exception.Message) { StatusCode = 406 };
            }
            catch (Exception exception)
            {
                return new JsonResult(exception.Message) { StatusCode = 500 };
            }
        }
    }
}
