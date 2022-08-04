using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeTutor.Models
{
    public class InfoViewModel
    {
        public  IEnumerable<Teacher> Teachers { get; set; }

        public List<CityAreas> CityAreas { get; set; }
    }
}