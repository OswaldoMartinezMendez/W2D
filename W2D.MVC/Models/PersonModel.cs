using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace W2D.MVC.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "DocumentNumber is required !")]
        public string DocumentNumber { get; set; }
        [Required(ErrorMessage = "Name is required !")]
        public string Name { get; set; }
        [Required(ErrorMessage = "LastName is required !")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Phone is required !")]
        public string Phone { get; set; }
    }
}