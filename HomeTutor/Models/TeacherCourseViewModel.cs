using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeTutor.Models
{
    public class TeacherCourseViewModel
    {
        public int id { get; set; }

        public string Name { get; set; }
        public int TeacherId { get; set; }

       // public string Name { get; set; }
        public List<CourseCheckboxVIewModel> Courses { get; set; }


    }
}