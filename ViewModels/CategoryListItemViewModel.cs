using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GardenArt.ViewModels
{
    public class CategoryListItemViewModel
    {
        [Display(Name = "ID")]
        public Int32 CategoryID { get; set; }

        [Required(ErrorMessage = "Kategori måste fyllas i")]
        [DataType(DataType.Text)]
        [Display(Name = "Kategori")]
        public String Name { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Beskrivning")]
        public String Description { get; set; }
    }
}