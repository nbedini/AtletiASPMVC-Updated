using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AtletiASPMVC.Models
{
    public class AthleteSearch
    {
        [Required]
        public string Name { get; set; }
    }
}