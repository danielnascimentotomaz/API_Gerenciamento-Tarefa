using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoTarefa.Database;
using GerenciamentoTarefa.Dto;
using GerenciamentoTarefa.Excecoes;
using GerenciamentoTarefa.Models;


namespace GerenciamentoTarefa.Service
{
    public class TarefaImplService: ITararefaService
    {

        private readonly TarefaContext _context;

        public TarefaImplService(TarefaContext tarefa){
            _context = tarefa;
        
        }
     
//****************************************************************************//
        public Tarefa CriarTarefa(TarefaDto tarefa)
        {

            if (string.IsNullOrEmpty(tarefa.Titulo))
        {
            throw new TituloTarefaInvalidoException();
        }

          var tarefaEntity = tarefa.toEntity(); // Convertendo o DTO para a entidade


           var tarefaSalva = _context.tarefas.Add(tarefaEntity);
            _context.SaveChanges();
            return tarefaEntity;   
        }

 //****************************************************************************//       

        public List<Tarefa> listarTodasTarefas(int page)
        {

            // Verifica se o número da página é menor que 1 e, se for, o ajusta para 1
            if(page < 1) page = 1;

            // Define o limite de tarefas por página como 10
            int limit = 10;
           
            // Calcula o deslocamento com base no número da página e no limite
            int offset = (page - 1) * limit;


            // Consulta o contexto do banco de dados para obter as tarefas, 
           // pulando as tarefas anteriores ao deslocamento e pegando até o limite definido
            var listarTarefasBD = _context.tarefas.Skip(offset).Take(limit).ToList();
            return listarTarefasBD;    
        }

        
//****************************************************************************//

        public void AtualizarTarefa(int id, TarefaDto tarefa)
        {

            var tarefaBD  = _context.tarefas.Find(id);

            if(tarefaBD == null){

                throw new TarefaInexistenteException($"Tarefa com ID {id} não existem no banco de dados");
            }

            if (string.IsNullOrEmpty(tarefa.Titulo))
           {
            throw new TituloTarefaInvalidoException();
            }

           
            tarefaBD.Titulo = tarefa.Titulo;
            tarefaBD.Descricao= tarefa.Descricao;
            tarefaBD.Concluida = tarefa.Concluida;

            _context.Update(tarefaBD);
            _context.SaveChanges();
    
        }

//****************************************************************************//

       public Tarefa obterTarefaPorId(int id)
        {
            var tarefaBD = _context.tarefas.Find(id);
            if(tarefaBD == null){
                throw new TarefaInexistenteException($"Tarefa com ID {id} não existem no banco de dados");
            
            }
            return tarefaBD;
        }


//****************************************************************************//
        public void DeletarTarefaId(int id)
        {
             var tarefaBD = _context.tarefas.Find(id);
            if(tarefaBD == null){
                throw new TarefaInexistenteException($"Tarefa com ID {id} não existem no banco de dados");
            }

            _context.tarefas.Remove(tarefaBD);
            _context.SaveChanges();
        }
    
    
}}