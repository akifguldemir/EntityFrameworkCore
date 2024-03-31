using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.Data
{
    public class CourseRegistration
    {
        public int Id { get; set; }
        public int OgrenciId { get; set; }
        public int KursId { get; set; }
        public DateTime RegisterDate { get; set; }
    
    }
}