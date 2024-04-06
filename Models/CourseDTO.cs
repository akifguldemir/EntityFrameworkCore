using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Data
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int TeacherId { get; set; }

        public ICollection<CourseRegistration> CourseRegistrations { get; set; } = new List<CourseRegistration>();

    }
}