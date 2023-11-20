using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection;

namespace biblioteca_trabalho.Models
{
    [Table("Student")]
    public class Student: Member
    {
        [Display(Name = "Nome")]
        public string? Sname {get; set;}

        public string? StudentColl {get; set;}

        public void CheckOutBook(){}
        public void  ReturnBook(){}
    }
}