using CaliforniaPep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;

namespace CaliforniaPep
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Product> GetProducts([QueryString("id")] int? categoryId)
        {
            var _db = new CaliforniaPep.Models.ProductContext();            
            if (categoryId.HasValue && categoryId > 0)
            {
                IQueryable<Product> query1 = _db.ProductCategories.Where(en => en.CategoryId == categoryId).Select(w => w.Product);
                return query1;
            }
            else
            {
                IQueryable<Product> query2 = _db.Products;
                return query2;
            }
            
        }
    }
}