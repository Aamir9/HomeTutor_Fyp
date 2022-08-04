using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HomeTutor.Models
{
    public class CityAreas
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CityId { get; set; }

        [ForeignKey("CityId")]
        public City city { get; set; }

        public virtual ICollection<TeacherTOArea> TeacherTOAreas { get; set; }
    }
}