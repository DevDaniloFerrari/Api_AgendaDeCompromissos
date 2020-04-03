using api.agenda.de.compromissos.Exceptions;
using api.agenda.de.compromissos.Interfaces.Services;
using api.agenda.de.compromissos.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace api.agenda.de.compromissos.Controllers
{
    [Route("api/consultas/")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {

        private readonly IConsultaService _consultaService;
        private readonly IPacienteService _pacienteService;

        public ConsultaController(
            IConsultaService consultaService
            , IPacienteService pacienteService)
        {
            _consultaService = consultaService;
            _pacienteService = pacienteService;
        }

        [HttpGet]
        public JsonResult ObterConsultas()
        {
            try
            {
                return new JsonResult(_consultaService.Consultas()) { StatusCode = 200 };
            }
            catch (NenhumaConsultaCadastradaException exception)
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

        [HttpGet("{id_consulta}")]
        public JsonResult ObterConsulta(int id_consulta)
        {
            try
            {
                return new JsonResult(_consultaService.Consulta(id_consulta)) { StatusCode = 200 };
            }
            catch (ConsultaNaoExisteException exception)
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

        [HttpGet("pacientes/{id_paciente}")]
        public JsonResult ObterConsultaPorPaciente(int id_paciente)
        {
            try
            {
                return new JsonResult(_consultaService.ConsultaPorPaciente(id_paciente)) { StatusCode = 200 };
            }
            catch (ConsultaNaoExisteException exception)
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

        [HttpPost()]
        public JsonResult AgendarConsulta([FromBody] ConsultaModel consulta)
        {
            try
            {
                _pacienteService.Buscar(consulta.Paciente.Id);

                ConsultaModel consultaAgendada = _consultaService.AgendarConsulta(consulta);

                Response.Headers.Add("Location", $"api/consultas/{consultaAgendada.Id}");

                return new JsonResult("Consulta incluida com sucesso") { StatusCode = 201 };
            }
            catch (PacienteNaoExisteException exception)
            {
                return new JsonResult(exception.Message) { StatusCode = 406 };
            }
            catch (ConsultasNoMesmoPeriodoException exception)
            {
                return new JsonResult(exception.Message) { StatusCode = 406 };
            }
            catch (DataFinalMenorQueDataInicialException exception)
            {
                return new JsonResult(exception.Message) { StatusCode = 406 };
            }
            catch (ConsultaNaoExisteException exception)
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

        [HttpDelete("finalizacao/{id_consulta}")]
        public JsonResult FinalizarConsulta(int id_consulta)
        {
            try
            {
                _consultaService.FinalizarConsulta(id_consulta);
                return new JsonResult("Consulta finalizada com sucesso") { StatusCode = 200 };
            }
            catch (PacienteNaoExisteException exception)
            {
                return new JsonResult(exception.Message) { StatusCode = 406 };
            }
            catch (PacienteNaoCorrespondeAEstaConsultaException exception)
            {
                return new JsonResult(exception.Message) { StatusCode = 406 };
            }
            catch (ConsultaNaoExisteException exception)
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

        [HttpDelete("cancelamento/{id_consulta}")]
        public JsonResult CancelarConsulta(int id_consulta)
        {
            try
            {
                _consultaService.CancelarConsulta(id_consulta);
                return new JsonResult("Consulta cancelada com sucesso") { StatusCode = 200 };
            }
            catch (PacienteNaoExisteException exception)
            {
                return new JsonResult(exception.Message) { StatusCode = 406 };
            }
            catch (PacienteNaoCorrespondeAEstaConsultaException exception)
            {
                return new JsonResult(exception.Message) { StatusCode = 406 };
            }
            catch (ConsultaNaoExisteException exception)
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
