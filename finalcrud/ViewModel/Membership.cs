using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace finalcrud.ViewModel
{
    public class Membership
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please Enter UserName")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public int Password { get; set; }
    }
}