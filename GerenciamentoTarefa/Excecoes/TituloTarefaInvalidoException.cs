using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoTarefa.Excecoes
{
    public class TituloTarefaInvalidoException:Exception
    {
       

        public TituloTarefaInvalidoException():base("O título da tarefa não pode ser nulo ou vazio.")
        {
            
        }

        
        
        
    }
}