using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace biblioteca_trabalho.Models
{
    public class Catalog
    {
        [Key]
        public int? Id {get; set;}

        [Display(Name = "Nome do Autor")]
        public string? AuthorName {get; set;}

        [Display(Name = "Estoque cópias")]
        public int? NoofCopies {get; set;}
        public ICollection<Books> Book {get;} = new List<Books>();

        public void UpdateInfo(string authorName, int? noOfCopies){
            AuthorName = authorName;
            NoofCopies = noOfCopies;
        }
        public void Searching(string authorName){
           
        }

    }
}