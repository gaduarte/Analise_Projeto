using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace biblioteca_trabalho.Models
{
    [Table("FacultyMember")]
    public class FacultyMember: Member
    {
        [Display(Name = "Nome")]
        public string? Fname {get; set;}
        public string? FacultyColl {get; set;}

        public void CheckOutBook(){}
    }
}