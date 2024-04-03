using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Data
{
    public class CourseRegistration
    {
        [Key]
        public int Id { get; set; }
        public int StudentId { get; set; }

        public Student Student { get; set; } = null!;
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;

        public DateTime RegisterDate { get; set; }
    
    }
}