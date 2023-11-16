using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciamentoTarefa.Excecoes
{
    public class ExceptionDetails
    {
        public string title{get;set;}
        public DateTime dateTime{get;set;}

        public int status{get;set;}

       //public string exception{get;set;}

       // public  Dictionary<string, string> details{get;set;}



        public ExceptionDetails(string title, DateTime dateTime,int status)
        {
            this.title = title;
            this.dateTime = dateTime;
            this.status = status;
         
        } 
    }
}