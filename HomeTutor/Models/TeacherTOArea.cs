using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeTutor.Models
{
    public class TeacherTOArea
    {

        public int Id { get; set; }

        public int TeacherId { get; set; }
        public int CityAreasId { get; set; }

       public virtual Teacher teacher { get; set; }
    
       public virtual CityAreas cityArea { get; set; }

       }
}