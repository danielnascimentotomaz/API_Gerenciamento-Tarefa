using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoTarefa.Dto;
using GerenciamentoTarefa.Models;


namespace GerenciamentoTarefa.Service
{
    public interface ITararefaService
    {

        List<Tarefa> listarTodasTarefas(int page);

        Tarefa CriarTarefa(TarefaDto tarefa);

        Tarefa obterTarefaPorId(int id);

         void AtualizarTarefa(int id, TarefaDto tarefa);

         void DeletarTarefaId(int id);
       
    }
}