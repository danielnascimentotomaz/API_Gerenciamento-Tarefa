using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciamentoTarefa.Models;

namespace GerenciamentoTarefa.Dto
{
    public class TarefaDto
    {
        public string Titulo { get; set; }      
        public  String Descricao { get; set; } 

        public bool Concluida { get; set; }


        public Tarefa toEntity(){
            return new Tarefa{

                Titulo = this.Titulo,
                Descricao = this.Descricao,
                Concluida = this.Concluida  



            };
    




        }
    }
}