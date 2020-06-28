using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace FluentAppDetails.Models
{
   public class Course
    {
        [Key]
        public int Code { get; set; }
        public string Name { get; set; }

        public int StudentFK { get; set; }

        [ForeignKey(nameof(StudentFK))]
        public Student Student { get; set; }

    }
}
