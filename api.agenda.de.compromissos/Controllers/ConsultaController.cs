using api.agenda.de.compromissos.Exceptions;
using api.agenda.de.compromissos.Interfaces.Services;
using api.agenda.de.compromissos.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace api.agenda.de.compromissos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {

        private readonly IConsultaService _consultaService;

        public ConsultaController(IConsultaService consultaService)
        {
            _consultaService = consultaService;
        }

        [HttpGet]
        public string ObterConsultas()
        {
            return JsonConvert.SerializeObject(_consultaService.Consultas());
        }

        [HttpPost]
        public IActionResult AgendarConsulta([FromBody] ConsultaModel consulta)
        {
            try
            {
                _consultaService.AgendarConsulta(consulta);
                return Ok();
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(ConsultasNoMesmoPeriodoException) || ex.GetType() == typeof(DataFinalMenorQueDataInicialException))
                    return StatusCode(406, ex.Message);
                else
                    return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("finalizar/{id}")]
        public IActionResult FinalizarConsulta(int id)
        {
            try
            {
                _consultaService.FinalizarConsulta(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("cancelar/{id}")]
        public IActionResult CancelarConsulta(int id)
        {
            try
            {
                _consultaService.CancelarConsulta(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
