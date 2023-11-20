using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace biblioteca_trabalho.Models
{
    public class Alert
    {
        [Key]
        public int? Id {get; set;}

        [Display(Name = "Data do Problema")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime IssueDate {get; set;}

        [Display(Name = "Nome do Livro")]
        public string? BookName {get; set;}

        [Display(Name = "Data do Retorno")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ReturnDate {get; set;}

        [Display(Name = "Deu certo?")]
        public int? Fine {get; set;}
        
        public int? LibrarianId {get; set;}
        public Librarian? Librarian {get; set;}

        public string FineCall(){
            if(Fine == 1){
                return "Ok.";
            }
            return string.Empty;
        }
        public string ViewAlert(){
            if(ReturnDate > DateTime.Now){
                return "Data de Entrega passou do prazo";
            }
            return string.Empty;
        }
        public string SendToLibrarian(){
            if(ReturnDate == ReturnDate){
                return "Dia para devolver o Livro é hoje.";
            }
            return string.Empty;
        }
        public void DeleteaLrbyNo(){

        }
    }
}