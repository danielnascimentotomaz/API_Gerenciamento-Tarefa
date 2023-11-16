using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoTarefa.Database;
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
        public Tarefa CriarTarefa(Tarefa tarefa)
        {

            if (string.IsNullOrEmpty(tarefa.Titulo))
        {
            throw new TituloTarefaInvalidoException();
        }


            _context.tarefas.Add(tarefa);
            _context.SaveChanges();
            return tarefa;    
        }

 //****************************************************************************//       

        public List<Tarefa> listarTodasTarefas()
        {

            var listarTarefasBD = _context.tarefas.ToList();
            return listarTarefasBD;    
        }

        public Tarefa obterTarefaPorId(int id)
        {
            throw new NotImplementedException();
        }
//****************************************************************************//

        public void AtualizarTarefa(int id, Tarefa tarefa)
        {

            var tarefaBD  = _context.tarefas.Find(id);

            if(tarefaBD == null){

                throw new TarefaInexistenteException($"Tarefa com ID {id} não existem no banco de dados");
            }

            if (string.IsNullOrEmpty(tarefa.Titulo))
           {
            throw new TituloTarefaInvalidoException();
            }

            tarefaBD.Id = tarefa.Id;
            tarefaBD.Titulo = tarefa.Titulo;
            tarefaBD.Descricao= tarefa.Descricao;
            tarefaBD.Concluida = tarefa.Concluida;

            _context.Update(tarefaBD);
            _context.SaveChanges();
    
        }






    }

    
}