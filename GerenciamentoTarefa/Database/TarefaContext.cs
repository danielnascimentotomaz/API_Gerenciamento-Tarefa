
using GerenciamentoTarefa.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoTarefa.Database
{
    public class TarefaContext:DbContext
    {




        public TarefaContext(DbContextOptions<TarefaContext> options):base(options) {
        
        
        }


        public DbSet<Tarefa> tarefas { get; set; }




    }
}
