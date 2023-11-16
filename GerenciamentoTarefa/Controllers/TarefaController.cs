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

        [HttpPost]
      
        public IActionResult CriarTarefa([FromBody] Tarefa tarefa){

          {
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
        StatusCodes.Status409Conflict
        
        );
       
       
       
       return BadRequest(exceptionDetails);
    }

        }



    }

}
}
