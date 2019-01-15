using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InnerMetrixWeb.ViewModels
{
    public class CandidateViewModel
    {
        [Display(Name = "FirstName", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Display(Name = "LastName", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email", ResourceType = typeof(Resources.Resources))]
        [Required(ErrorMessage = "Email Address is required")]
        [RegularExpression("^[A-Za-z0-9_\\+-]+(\\.[A-Za-z0-9_\\+-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*\\.([A-Za-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string EmailAddress { get; set; }
        public string Language { get; set; }
    }
}