using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace NimapInfotechMVC.Models
{
    public class Category
    {
        public int CId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter CategoryName"), MaxLength(30)]
        public string CategoryName { get; set; }
    }
}