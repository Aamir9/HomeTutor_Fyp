using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HomeTutor.Models
{
    public class TeacherViewModelDemo
    {
      
        public int Id { get; set; }
       


       // public int[] CityAreas_id { get; set; }

       //public int CityId { get; set; }

       // [ForeignKey("CityId")]
       // public virtual City city { get; set; }

        public int TeacherId { get; set; }


        public string LevelOfTaught { get; set; }
        public string ImagePath { get; set; }
       
        public HttpPostedFileBase ImageFile { get; set; }

        [Display(Name = "Email address :", Prompt = "Email is required")]
        // [Remote("Create", "Customers", ErrorMessage = "Email already exists!")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Required name")]
        [Display(Name = "Full Name :")]
        [StringLength(16, ErrorMessage = "Must be between 3 and 16 characters", MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password :")]
        public string Password { get; set; }





        [Required(ErrorMessage = "Highest Qualification requird")]
        [Display(Name = "Highest Qualification :")]

        [DataType(DataType.Text)]
        public string Qualification { get; set; }


        [Required(ErrorMessage = "Institute: requird")]
        [Display(Name = "Institute :")]

        [DataType(DataType.Text)]
        public string Institute { get; set; }



        [Required(ErrorMessage = "Institute: requird")]
        [Display(Name = "Second highest Qualification :")]

        [DataType(DataType.Text)]
        public string SecondQualification { get; set; }



        [Display(Name = "Institute :")]
        [DataType(DataType.Text)]
        public string SecondInstitute { get; set; }


        [Required(ErrorMessage = "Institute: requird")]
        [Display(Name = "About me :")]
        [DataType(DataType.MultilineText)]
        public string AboutMe { get; set; }




        [Required(ErrorMessage = "Tutoring Type  requird")]
        [Display(Name = "Tutoring Type :")]
        [DataType(DataType.Text)]
        public string TutoringType { get; set; }




        [Display(Name = "Skype ID(Optional) :")]
        [DataType(DataType.Text)]
        public string SkypId { get; set; }


        
        public string Phone { get; set; }

      
       
        public string Expertise { get; set; }



       // public List<CityAreaVewModel>  cityAreaVewModels { get; set; }

        


    }
}