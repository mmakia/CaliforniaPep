using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaliforniaPep.Models
{
    public class ProductCategory
    {
        public int ProductCategoryId { get; set; }
        
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}