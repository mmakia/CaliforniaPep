using CaliforniaPep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CaliforniaPep
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Product> GetProduct([QueryString("productID")] int? productId)
        {
            var _db = new CaliforniaPep.Models.ProductContext();
            if (productId.HasValue && productId > 0)
            {
                IQueryable<Product> query1 = _db.Products.Where(en => en.ProductId == productId);
                return query1;
            }
            else
            {
                IQueryable<Product> query2 = _db.Products;
                return query2;
            }

            //var _db = new CaliforniaPep.Models.ProductContext();
            //IQueryable<Product> query = _db.Products;
            //if (productId.HasValue && productId > 0)
            //{
            //    query = query.Where(p => p.ProductID == productId);
            //}
            //else
            //{
            //    query = null;
            //}
            //return query;
        }

        public IQueryable<Category> GetCategories2([QueryString("ProductID")] int? productId)
        {
            var _db = new CaliforniaPep.Models.ProductContext();            
            if (productId == null)
            {
                return null;
            }
            else
            {
                IQueryable<Category> query = _db.ProductCategories.Where(en => en.ProductId == productId).Select( s => s.Category);
                return query;
            }
            
            
        }
    }
}