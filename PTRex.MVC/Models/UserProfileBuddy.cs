using System;
using System.ComponentModel.DataAnnotations;

namespace PTRex.MVC.Models
{
    [MetadataType(typeof(UserProfileBuddy))]
    public partial class UserProfile
    {
    }

    sealed class UserProfileBuddy
    {
        public int ID { get; set; }

        [Display(Name = "Username")]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> DateOfBirth { get; set; }

        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [StringLength(10, ErrorMessage = "Phone number cannot be longer than 10 characters.")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Photo")]
        public string Photo { get; set; }
    }
}