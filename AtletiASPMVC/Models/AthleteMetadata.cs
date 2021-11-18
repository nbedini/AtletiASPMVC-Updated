using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AtletiASPMVC.Models
{
    public class AthleteMetadata
    {
        [Required(ErrorMessage = "Inserire qualcosa in questo campo")]
        [MinLength(1)]
        [MaxLength(5,ErrorMessage = "Massimo 5 caratteri")]
        [Key]
        [Display(Name = "Sesso")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Il nome non può essere vuoto")]
        public string Name { get; set; }
    }

    [MetadataType(typeof(AthleteMetadata))]
    public partial class Athlete
    { }
}