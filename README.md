# Api Agenda De Compromissos

API feita em .NET Core 2.1 utilizando banco de dados SQL Server

## Funções

- **Cadastro de Paciente** <br>
  Requisição: [HttpPost] <br>
  Utilizar a URI: /api/paciente <br>
  Body: {
         "Nome":"",
         "Nascimento":"yyyy-mm-dd"
        }
        
- **Alteração de Paciente** <br>
  Requisição: [HttpPut] <br>
  Utilizar a URI: /api/paciente/{id} <br>
  Body: {
         "Id":,
         "Nome":"",
         "Nascimento":"yyyy-mm-dd"
        }
        
- **Deleção de Paciente** <br>
  Requisição: [HttpDelete] <br>
  Utilizar a URI: /api/paciente/{id} <br>
  
- **Obter lista de Pacientes** <br>
  Requisição: [HttpGet] <br>
  Utilizar a URI: /api/paciente
  
- **Agendar Consulta** <br>
  Requisição: [HttpPost] <br>
  Utilizar a URI: /api/consulta <br>
  Body: {
          "Paciente":{
           "Id":
          },
          "Inicio":"yyyy-mm-ddThh:mm:ss.mm",
          "Fim":"yyyy-mm-ddThh:mm:ss.mm",
          "Observacoes":""
        }
        
- **Finalizar Consulta** <br>
  Requisição: [HttpPut] <br>
  Utilizar a URI: /api/finalizar/consulta/{id}
  

- **Cancelar Consulta** <br>
  Requisição: [HttpPut] <br>
  Utilizar a URI: /api/cancelar/consulta/{id}
  
- **Obter lista de Consultas** <br>
  Requisição: [HttpGet] <br>
  Utilizar a URI: /api/consulta
