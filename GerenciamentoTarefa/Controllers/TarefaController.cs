using GerenciamentoTarefa.Excecoes;
using GerenciamentoTarefa.Models;
using GerenciamentoTarefa.Service;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoTarefa.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TarefaController : ControllerBase
    {

        private readonly TarefaImplService _tarefa;
        public TarefaController(TarefaImplService tarefa){

            _tarefa = tarefa;
        

        }



        [HttpGet]
        public IActionResult ListaTarefas()
        {
            var todasTarefas = _tarefa.listarTodasTarefas();

            return StatusCode(200,todasTarefas);   
        }


 //****************************************************************************//       

        [HttpPost]
        public IActionResult CriarTarefa([FromBody] Tarefa tarefa){
         
        try
        {
            var tarefaCriada = _tarefa.CriarTarefa(tarefa);

            return StatusCode(201, tarefaCriada);
        }
        catch (TituloTarefaInvalidoException ex)
        {
        var exceptionDetails =  new ExceptionDetails(
            ex.Message,
            DateTime.Now,
            StatusCodes.Status409Conflict);
        
        return StatusCode(409,exceptionDetails);
        }
        }


 //****************************************************************************//       


        [HttpPut("{id}")]
        public IActionResult AtualizarTarefa([FromRoute] int id,[FromBody]Tarefa tarefa){

            try{

                 _tarefa.AtualizarTarefa(id,tarefa);

                return StatusCode(201);

            }catch(TarefaInexistenteException ex){

                var exceptionDetails =  new ExceptionDetails(
                    ex.Message,
                    DateTime.Now,
                    StatusCodes.Status404NotFound
                );
                return StatusCode(404,exceptionDetails);
        }catch(TituloTarefaInvalidoException ex){

            var exceptionDetails =  new ExceptionDetails(
            ex.Message,
            DateTime.Now,
            StatusCodes.Status409Conflict);

            return StatusCode(409,exceptionDetails);
        }

        }


 //****************************************************************************//

        [HttpDelete("{id}")]
        public IActionResult DeletarTarefa([FromRoute] int id){

            try{

                _tarefa.DeletarTarefaId(id);

                return StatusCode(204);

            }catch(TarefaInexistenteException ex){

                var exceptionDetails =  new ExceptionDetails(
                    ex.Message,
                    DateTime.Now,
                    StatusCodes.Status404NotFound
                );

                return StatusCode(404,exceptionDetails);

            } }  


 //****************************************************************************//

        [HttpGet("{id}")]
        public IActionResult BuscarTarefaId([FromRoute] int id){

            try{

                var tarefa = _tarefa.obterTarefaPorId(id);
                return StatusCode(200,tarefa);
            }catch(TarefaInexistenteException ex){

                 var exceptionDetails =  new ExceptionDetails(
                    ex.Message,
                    DateTime.Now,
                    StatusCodes.Status404NotFound
                );

                return StatusCode(404,exceptionDetails);

            } }    


  
  
  
  
  
    }

}

