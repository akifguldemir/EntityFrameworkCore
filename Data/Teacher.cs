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

        public string NameSurname
        {
            get{
                return this.Name + ' ' + this.SurName;
            }
        }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AugurationDate { get; set; }

        public ICollection<Course> CourseRegistrations { get; set; } = new List<Course>();

    }
}