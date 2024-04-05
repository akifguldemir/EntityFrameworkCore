using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Data
{
    public class Teacher
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime AugurationDate { get; set; }

        public ICollection<Course> CourseRegistrations { get; set; } = new List<Course>();

    }
}