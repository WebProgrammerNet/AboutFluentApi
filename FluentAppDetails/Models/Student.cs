using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FluentAppDetails.Models
{
    [Table("Student")]
    public class Student
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PK { get; set; }

       // public int PK_1 { get; set; }

        [Required(ErrorMessage = "It is not allowed how null as value"),
            MinLength(2,ErrorMessage ="Length enaugh"),
            MaxLength(200,ErrorMessage ="More Length 200"),
            Column("StudentName",Order = 2,TypeName ="char(25)")
            ]
        public string Name { get; set; }

        [Range(0.0d,4.0d,ErrorMessage ="Error Mister")]
        [DefaultValue(2.2f)]//,Column("StudentGPA", Order = 2, TypeName = "float")
        public float GPA { get; set; } // = 2.2f

        [DataType(DataType.EmailAddress),Display(Name="E-mail Address")]
        public string Email { get; set; }

        public IEnumerable<Course> Courses { get; set; }
    }
}
