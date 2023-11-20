using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace biblioteca_trabalho.Models
{
    public class Member
    {
        [Key]
        public int? Id {get; set;}

        [Display(Name = "Nome")]
        public string? Mname {get; set;}

        [Display(Name = "Endereço")]
        public string? Maddress {get; set;}

        [Display(Name = "É membro?")]
        public int? Mno {get;set;}
        public List<Librarian> Librarians {get;} = new();

        public List<Books> Books {get;} = new List<Books>();

        public void MrequestforBook(){}
        public string MreturnBook(){
            if (Mno == 0){
                return "Livro Devolvido";
            }
            return string.Empty;
        }
    }
}