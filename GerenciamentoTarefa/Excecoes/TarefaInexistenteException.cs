using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoTarefa.Excecoes
{
    public class TarefaInexistenteException:Exception
    {
        public TarefaInexistenteException(string mensagem):base(mensagem)
        {
            
        }
    
    
        
    }
}