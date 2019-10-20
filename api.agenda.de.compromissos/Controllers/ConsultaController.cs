using api.agenda.de.compromissos.Exceptions;
using api.agenda.de.compromissos.Interfaces.Services;
using api.agenda.de.compromissos.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace api.agenda.de.compromissos.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {

        private readonly IConsultaService _consultaService;
        private readonly IPacienteService _pacienteService;

        public ConsultaController(
            IConsultaService consultaService
            ,IPacienteService pacienteService)
        {
            _consultaService = consultaService;
            _pacienteService = pacienteService;
        }

        [HttpGet("consultas")]
        public JsonResult ObterConsultas()
        {
            try
            {
                return new JsonResult(_consultaService.Consultas()) { StatusCode = 200};
            }
            catch(NenhumaConsultaCadastradaException exception)
            {
                return new JsonResult(exception.Message) { StatusCode = 406};
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

        [HttpGet("consultas/{id_consulta}")]
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

        [HttpPost("pacientes/{id_paciente}/consultas")]
        public JsonResult AgendarConsulta([FromBody] ConsultaModel consulta, int id_paciente)
        {
            if(id_paciente == consulta.Paciente.Id)
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
            else
                return new JsonResult("Id informado na URL não corresponde com o id passado no Body") { StatusCode = 406 };
        }

        [HttpDelete("pacientes/{id_paciente}/consultas/{id_consulta}/finaliza")]
        public JsonResult FinalizarConsulta(int id_consulta, int id_paciente)
        {
            try
            {
                _pacienteService.Buscar(id_paciente);

                ConsultaModel consultaFinalizada = _consultaService.Consulta(id_consulta);

                if (id_paciente != consultaFinalizada.Paciente.Id)
                    throw new PacienteNaoCorrespondeAEstaConsultaException();

                _consultaService.FinalizarConsulta(id_consulta);
                return new JsonResult("Consulta finalizada com sucesso") { StatusCode = 200 };
            }
            catch(PacienteNaoExisteException exception)
            {
                return new JsonResult(exception.Message) { StatusCode = 406 };
            }
            catch(PacienteNaoCorrespondeAEstaConsultaException exception)
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

        [HttpDelete("pacientes/{id_paciente}/consultas/{id_consulta}/cancela")]
        public JsonResult CancelarConsulta(int id_consulta, int id_paciente)
        {
            try
            {
                _pacienteService.Buscar(id_paciente);

                ConsultaModel consultaCancelada = _consultaService.Consulta(id_consulta);

                if (id_paciente != consultaCancelada.Paciente.Id)
                    throw new PacienteNaoCorrespondeAEstaConsultaException();

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
