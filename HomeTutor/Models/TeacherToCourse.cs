using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeTutor.Models
{
    public class TeacherToCourse
    {

        public int Id { get; set; }

        public int CourseId { get; set; }

        public int TeacherId { get; set; }
        public virtual  Course Course { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}