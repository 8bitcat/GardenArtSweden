using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GardenArt.ViewModels
{
    public class MaterialListItemViewModel
    {
        [Display(Name = "ID")]
        public Int32 MaterialID { get; set; }

        [Required(ErrorMessage = "Material måste fyllas i")]
        [DataType(DataType.Text)]
        [Display(Name = "Material")]
        public String Name { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Beskrivning")]
        public String Description { get; set; }
    }
}