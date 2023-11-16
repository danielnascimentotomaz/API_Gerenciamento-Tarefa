using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoTarefa.Models;


namespace GerenciamentoTarefa.Service
{
    public interface ITararefaService
    {

        List<Tarefa> listarTodasTarefas();

        Tarefa CriarTarefa(Tarefa tarefa);

        Tarefa obterTarefaPorId(int id);

         void AtualizarTarefa(int id, Tarefa tarefa);

         void DeletarTarefaId(int id);
       
    }
}