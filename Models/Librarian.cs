using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace biblioteca_trabalho.Models
{
    public class Librarian
    {
        [Key]
        public int? Id {get; set;}

        [Display(Name= "Nome")]
        public string? Name {get; set;}

        [Display(Name = "Endereço")]
        public string? Adrdress {get; set;}
        public int? Mobileno {get; set;}
        public List<Member> Members {get;} = new();

        public int? AlertId {get; set;}
        public Alert? Alert {get; set;}

        public void UpdateInfo(string adrdress, string name, int? mobileno){
            Adrdress = adrdress;
            Name = name;
            Mobileno = mobileno;
        }
        public int? IssueBooks(){
            return AlertId;
        }
        public string MemberInfo(){
            List<string> memberInfoList = Members.Select(member => member.Mname).ToList();

            string memberInfo = string.Join(", ", memberInfoList);

            return memberInfo;
        }
        public void SearchBook(){}
        public string ReturnBook(){
            if(Mobileno == 0){
                return "Livro Entregue";
            }
            return "Livro a ser entregue";
        }
    }
}