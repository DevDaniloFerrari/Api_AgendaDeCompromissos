# Api Agenda De Compromissos

API feita em .NET Core 2.1 utilizando banco de dados SQL Server

## Funções

- **Cadastro de Paciente** <br>
  Requisição: [HttpPost] <br>
  Utilizar a URI: /api/pacientes <br>
  Body: {
         "Nome":"",
         "Nascimento":"yyyy-mm-dd"
        }
        
- **Alteração de Paciente** <br>
  Requisição: [HttpPut] <br>
  Utilizar a URI: /api/pacientes/{id} <br>
  Body: {
         "Id":,
         "Nome":"",
         "Nascimento":"yyyy-mm-dd"
        }
        
- **Deleção de Paciente** <br>
  Requisição: [HttpDelete] <br>
  Utilizar a URI: /api/pacientes/{id} <br>
  
- **Obter lista de Pacientes** <br>
  Requisição: [HttpGet] <br>
  Utilizar a URI: /api/pacientes
  
- **Obter Paciente** <br>
  Requisição: [HttpGet] <br>
  Utilizar a URI: /api/pacientes/{id}  
  
- **Agendar Consulta** <br>
  Requisição: [HttpPost] <br>
  Utilizar a URI: /api/pacientes/{id}/consultas <br>
  Body: {
          "Paciente":{
           "Id":
          },
          "Inicio":"yyyy-mm-ddThh:mm:ss.mm",
          "Fim":"yyyy-mm-ddThh:mm:ss.mm",
          "Observacoes":""
        }
        
- **Finalizar Consulta** <br>
  Requisição: [HttpDelete] <br>
  Utilizar a URI: /api/pacientes/{id_paciente}/consultas/{id_consulta}/finaliza
  

- **Cancelar Consulta** <br>
  Requisição: [HttpDelete] <br>
  Utilizar a URI: /api/pacientes/{id_paciente}/consultas/{id_consulta}/cancela
  
- **Obter lista de Consultas** <br>
  Requisição: [HttpGet] <br>
  Utilizar a URI: /api/consultas
  
- **Obter Consulta** <br>
  Requisição: [HttpGet] <br>
  Utilizar a URI: /api/consultas/{id}  
