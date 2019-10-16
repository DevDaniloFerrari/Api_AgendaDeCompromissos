using api.agenda.de.compromissos.Exceptions;
using api.agenda.de.compromissos.Models;
using api.agenda.de.compromissos.Services;
using api.agenda.de.compromissos.tests.Mocks;
using System;
using Xunit;

namespace api.agenda.de.compromissos.tests
{
    public class AgendaDeCompromissosTests
    {

        private readonly ConsultaService _consultaService;

        public AgendaDeCompromissosTests()
        {
            _consultaService = new ConsultaService(new FakeConsultaRepository());
        }

        [Fact]
        public void TestAgendarConsultaSemErro()
        {
            PacienteModel paciente = new PacienteModel("Danilo", new DateTime(2000, 6, 18));
            ConsultaModel consulta = new ConsultaModel(paciente, new DateTime(2019, 10, 16, 12, 0, 0), new DateTime(2019, 10, 16, 16, 0, 0), "");

            _consultaService.AgendarConsulta(consulta);
        }

        [Fact]
        public void TestAgendarConsultaDentroDeUmMesmoPeriodo()
        {
            PacienteModel paciente = new PacienteModel("Danilo", new DateTime(2000, 6, 18));
            ConsultaModel consulta1 = new ConsultaModel(paciente, new DateTime(2019, 10, 16, 12, 0, 0), new DateTime(2019, 10, 16, 16, 0, 0), "");
            ConsultaModel consulta2 = new ConsultaModel(paciente, new DateTime(2019, 10, 16, 13, 0, 0), new DateTime(2019, 10, 16, 15, 0, 0), "");

            _consultaService.AgendarConsulta(consulta1);

            Assert.Throws<DuasConsultasNoMesmoPeriodoException>(() => _consultaService.AgendarConsulta(consulta2));
        }

        [Fact]
        public void TestAgendarConsultaComecandoAntesETerminandoDepoisDeUmPeriodoExistente()
        {
            PacienteModel paciente = new PacienteModel("Danilo", new DateTime(2000, 6, 18));
            ConsultaModel consulta1 = new ConsultaModel(paciente, new DateTime(2019, 10, 16, 12, 0, 0), new DateTime(2019, 10, 16, 16, 0, 0), "");
            ConsultaModel consulta2 = new ConsultaModel(paciente, new DateTime(2019, 10, 16, 11, 0, 0), new DateTime(2019, 10, 16, 17, 0, 0), "");

            _consultaService.AgendarConsulta(consulta1);

            Assert.Throws<DuasConsultasNoMesmoPeriodoException>(() => _consultaService.AgendarConsulta(consulta2));
        }

        [Fact]
        public void TestAgendarConsultaComInicioEmUmPeriodoExistente()
        {
            PacienteModel paciente = new PacienteModel("Danilo", new DateTime(2000, 6, 18));
            ConsultaModel consulta1 = new ConsultaModel(paciente, new DateTime(2019, 10, 16, 12, 0, 0), new DateTime(2019, 10, 16, 16, 0, 0), "");
            ConsultaModel consulta2 = new ConsultaModel(paciente, new DateTime(2019, 10, 16, 13, 0, 0), new DateTime(2019, 10, 16, 17, 0, 0), "");

            _consultaService.AgendarConsulta(consulta1);

            Assert.Throws<DuasConsultasNoMesmoPeriodoException>(() => _consultaService.AgendarConsulta(consulta2));
        }

        [Fact]
        public void TestAgendarConsultaComFimEmUmPeriodoExistente()
        {
            PacienteModel paciente = new PacienteModel("Danilo", new DateTime(2000, 6, 18));
            ConsultaModel consulta1 = new ConsultaModel(paciente, new DateTime(2019, 10, 16, 12, 0, 0), new DateTime(2019, 10, 16, 16, 0, 0), "");
            ConsultaModel consulta2 = new ConsultaModel(paciente, new DateTime(2019, 10, 16, 11, 0, 0), new DateTime(2019, 10, 16, 15, 0, 0), "");

            _consultaService.AgendarConsulta(consulta1);

            Assert.Throws<DuasConsultasNoMesmoPeriodoException>(() => _consultaService.AgendarConsulta(consulta2));
        }

        [Fact]
        public void TestAgendarConsultaComDataFinalMenorQueDataInicial()
        {
            PacienteModel paciente = new PacienteModel("Danilo", new DateTime(2000, 6, 18));
            ConsultaModel consulta = new ConsultaModel(paciente, new DateTime(2019, 10, 16, 12, 0, 0), new DateTime(2019, 10, 16, 11, 0, 0), "");

            Assert.Throws<DataFinalMenorQueDataInicialException>(() => _consultaService.AgendarConsulta(consulta));
        }
    }
}
