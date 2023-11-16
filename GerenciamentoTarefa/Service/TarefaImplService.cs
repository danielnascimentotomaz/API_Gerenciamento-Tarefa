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

        public List<Tarefa> listarTodasTarefas()
        {

            var listarTarefasBD = _context.tarefas.ToList();
            return listarTarefasBD;    
        }

        public Tarefa obterTarefaPorId(int id)
        {
            throw new NotImplementedException();
        }
    }

    
}