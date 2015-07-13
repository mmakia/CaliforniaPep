using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CaliforniaPep.Models
{
    public enum Unit
    {
        mg
    }

    public class Product
    {


        [ScaffoldColumn(false)]
        public int ProductId { get; set; }

        [Required, StringLength(100), Display(Name = "Name")]
        public string ProductName { get; set; }

        public string Sequence { get; set; }

        public double MolecularWeight { get; set; }

        public string CatalogNumber { get; set; }

        public double Amount { get; set; }

        public Unit Unit { get; set; }

        [Display(Name = "Price")]
        public decimal UnitPrice { get; set; }

        public string ImagePath { get; set; }

        [StringLength(10000), Display(Name = "Product Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}