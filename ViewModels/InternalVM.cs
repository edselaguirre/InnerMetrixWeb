using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace InnerMetrixWeb.ViewModels
{
    public class InternalVM
    {
        [Required(ErrorMessage ="User Id is required.")]
        [Display(Name = "User Id")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Password is required.")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required(ErrorMessage ="Oracle Id is required.")]
        [Display(Name = "Oracle Id")]
        public string OracleId { get; set; }
        public string EmailAddress { get; set; }
    }
}