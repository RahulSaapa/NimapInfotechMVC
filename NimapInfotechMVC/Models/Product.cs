using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NimapInfotechMVC.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter ProductName"), MaxLength(30)]
        //[Display(Name = "ProductName")]
        public string ProductName { get; set; }

        public Nullable<int> CategoryId { get; set; }

    }
}