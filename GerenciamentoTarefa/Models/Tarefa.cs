using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciamentoTarefa.Models
{
    [Table(name:"tarefas")]
    public class Tarefa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        
        [StringLength(100)]
       // [Required(ErrorMessage = "O campo Título é obrigatório.")] vou tra essa exeção nanuamente
        public string Titulo { get; set; }
        
       
        public  String Descricao { get; set; } 

        public bool Concluida { get; set; } 

        public Tarefa() { }

        public Tarefa(int id,string titulo, string descricao,bool concluida) { 

            this.Id = id;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Concluida = concluida;
        }



    }
}
