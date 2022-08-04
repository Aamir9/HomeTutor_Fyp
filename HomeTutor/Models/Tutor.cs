using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeTutor.Models
{
    public class Tutor
    {

        public int TutorId { get; set; }

        public string ImagePath { get; set; }
        [NotMapped]
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



        //[Required(ErrorMessage = "City  requird")]
        //[Display(Name = "Select Your City :")]
        //[DataType(DataType.Text)]
        //public string City { get; set; }

          
        public int CityId { get; set; }

       [ForeignKey("CityId")]
        public  City city { get; set; }


        public int CityAreas_id { get; set; }

        [ForeignKey("CityAreas_id")]
        public CityAreas Areas { get; set; }


        [Required(ErrorMessage = "Tutoring Type  requird")]
        [Display(Name = "Tutoring Type :")]
        [DataType(DataType.Text)]
        public string TutoringType { get; set; }



       
        [Display(Name = "Skype ID(Optional) :")]
        [DataType(DataType.Text)]
        public string SkypId { get; set; }


        [Required(ErrorMessage = "Phone number is requires")]
        [DisplayName("Phone :")]
        [MaxLength(11)]
        //[MinLength(10)]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression("^[0-9]*$", ErrorMessage = "please enter the valid phone number")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }
         
        [Required]
        [DisplayName("Expertise in :")]
        public string Expertise { get; set; }

    }
}