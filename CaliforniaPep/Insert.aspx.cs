using CaliforniaPep.Models;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CaliforniaPep
{
    public partial class Insert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void InsertFromUrl_Click(object sender, EventArgs e)
        {
            string myPageString = TextBox1.Text;

            //string result;
            //using (WebClient wc = new WebClient())
            //    result = wc.DownloadString("http://www.californiapeptide.com/peptide_catalog_table?page=2");

            //HtmlWeb hw = new HtmlWeb();
            string x = InsertFromUrl(myPageString);
            //HtmlDocument doc = hw.Load(@"http://www.californiapeptide.com/peptide_catalog_table?page=2");
            //StringBuilder sb = new StringBuilder();

            //List<string> lstHref = new List<string>();

            //foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]").Distinct())
            //{
            //    string curHref = link.Attributes["href"].Value;

            //    if (!lstHref.Contains(curHref))
            //        lstHref.Add(curHref);

            //}
            //foreach (string str in lstHref)
            //{
            //    sb.Append(str + "<br />");
            //}

            //Response.Write(sb.ToString());

            Label1.Text = x;
            TextBox1.Text = "";

        }



        protected void InsertFromPageSource_Click(object sender, EventArgs e)
        {
            string myPageHtml = TextBox1.Text;
            bool Result = iterProducts(myPageHtml);
            if (Result)
            {
                Label1.Text = "Ok";
                TextBox1.Text = "";
            }
            else
            {
                Label1.Text = "Error";
                TextBox1.Text = "";
            }

        }

        public bool iterProducts (string origHtml)
        {
            string strtBody = getBetween(origHtml, "<tbody>", "</tbody>").Trim();
            string[] split_text = strtBody.Split(' ');
            string myUrl;
            bool isOk = true;
            
            foreach (string ss in split_text)
            {
                if (ss.Contains("href="))
                {
                    myUrl = getBetween(ss, "href=\"", "\"><strong>");
                    if (InsertFromUrl("http://www.californiapeptide.com/" + myUrl) == "Error")
                        isOk = false;
                }                
            }
            return isOk;
            //WebClient client = new WebClient();
            //string downloadString = client.DownloadString(b);
            //string Result =InsertFromUrl(downloadString);            
                                    
        }

        public string InsertFromUrl(string b)///////////////////////
        {
            //StringReader strReader = new StringReader(myString);
            WebClient client = new WebClient();
            string a = client.DownloadString(b);

            string ProductName = getBetween(a, "<div class=\"field field-title\"><h2>", "</h2></div></div><div class=\"nd-region-middle-wrapper").Trim(); //a.Substring(0, a.IndexOf(Environment.NewLine)).Trim();

            string Sequence = getBetween(a, "Sequence:&nbsp;</div>", "</div>").Trim();

            string strMolecularWeight = getBetween(a, "Molecular Weight:&nbsp;</div>", "</div>").Trim();
            double MolecularWeight = 0.00;
            if (strMolecularWeight != "")
            {
                MolecularWeight = Convert.ToDouble(strMolecularWeight);
            }

            string CatalogNumber = getBetween(a, "Catalog Number:&nbsp;</div>", "</div>").Trim();

            string Categories = "";//to return
            if (a.Contains("Categories"))
            {                
                Categories = getBetween(a, "Categories</em>: </div><a href=\"", "Peptide Image").Trim();
            }
            

            string strAmount = (getBetween(a, "<span class=\"field-content\">", "mg for").Trim());
            double Amount = 0.00;
            if (strAmount != "")
            {
                Amount = Convert.ToDouble(strAmount);
            }
            

            string strUnitPrice = (getBetween(a, "mg for <span class=\"uc-price-product uc-price-sell_price uc-price\">", "</span></span>").Trim());
            decimal UnitPrice = 0.00m;
            if (strUnitPrice != "")
            {
                UnitPrice = Convert.ToDecimal(strUnitPrice.TrimStart('$'));
            }

            //string strDescription = getBetween(a, "Peptide Image", "PURCHASE THIS PRODUCT").Trim();

            using (ProductContext db = new ProductContext())
            {
                var newProduct = new Product();

                newProduct.ProductName = ProductName;
                newProduct.Sequence = Sequence;
                newProduct.MolecularWeight = MolecularWeight;
                newProduct.CatalogNumber = CatalogNumber;
                newProduct.Amount = Amount;
                newProduct.Unit = 0;
                newProduct.UnitPrice = UnitPrice;
                newProduct.ImagePath = "productimage.png";
                newProduct.Description = "";

                db.Products.Add(newProduct);

                if (Categories != "")
                {
                    if (Categories.Contains("Alzheimer&#039;s"))//1
                    {
                        var newProductcategory = new ProductCategory();
                        newProductcategory.ProductId = newProduct.ProductId;
                        newProductcategory.CategoryId = 1;
                        db.ProductCategories.Add(newProductcategory);
                        //db.SaveChanges();
                    }

                    if (Categories.Contains("Cardiovascular"))//2
                    {
                        var newProductcategory = new ProductCategory();
                        newProductcategory.ProductId = newProduct.ProductId;
                        newProductcategory.CategoryId = 2;
                        db.ProductCategories.Add(newProductcategory);
                        //db.SaveChanges();
                    }

                    if (Categories.Contains("Caspase"))//3
                    {
                        var newProductcategory = new ProductCategory();
                        newProductcategory.ProductId = newProduct.ProductId;
                        newProductcategory.CategoryId = 3;
                        db.ProductCategories.Add(newProductcategory);
                        //db.SaveChanges();
                    }

                    if (Categories.Contains("Central Nervous System"))//4
                    {
                        var newProductcategory = new ProductCategory();
                        newProductcategory.ProductId = newProduct.ProductId;
                        newProductcategory.CategoryId = 4;
                        db.ProductCategories.Add(newProductcategory);
                        //db.SaveChanges();
                    }

                    if (Categories.Contains("Enzyme Substrates"))//5
                    {
                        var newProductcategory = new ProductCategory();
                        newProductcategory.ProductId = newProduct.ProductId;
                        newProductcategory.CategoryId = 5;
                        db.ProductCategories.Add(newProductcategory);
                        //db.SaveChanges();
                    }

                    if (Categories.Contains("Gastrointestinal"))//6
                    {
                        var newProductcategory = new ProductCategory();
                        newProductcategory.ProductId = newProduct.ProductId;
                        newProductcategory.CategoryId = 6;
                        db.ProductCategories.Add(newProductcategory);
                        //db.SaveChanges();
                    }

                    if (Categories.Contains("Metabolic / Diabetes"))//7
                    {
                        var newProductcategory = new ProductCategory();
                        newProductcategory.ProductId = newProduct.ProductId;
                        newProductcategory.CategoryId = 7;
                        db.ProductCategories.Add(newProductcategory);
                        //db.SaveChanges();
                    }

                    if (Categories.Contains("Neuropeptides &amp; Hormones"))//8
                    {
                        var newProductcategory = new ProductCategory();
                        newProductcategory.ProductId = newProduct.ProductId;
                        newProductcategory.CategoryId = 8;
                        db.ProductCategories.Add(newProductcategory);
                        //db.SaveChanges();
                    }

                    if (Categories.Contains("Obesity"))//9
                    {
                        var newProductcategory = new ProductCategory();
                        newProductcategory.ProductId = newProduct.ProductId;
                        newProductcategory.CategoryId = 9;
                        db.ProductCategories.Add(newProductcategory);
                        //db.SaveChanges();
                    }

                    if (Categories.Contains("Human"))//10
                    {
                        var newProductcategory = new ProductCategory();
                        newProductcategory.ProductId = newProduct.ProductId;
                        newProductcategory.CategoryId = 10;
                        db.ProductCategories.Add(newProductcategory);
                        //db.SaveChanges();
                    }

                    if (Categories.Contains("Featured Products"))//11
                    {
                        var newProductcategory = new ProductCategory();
                        newProductcategory.ProductId = newProduct.ProductId;
                        newProductcategory.CategoryId = 11;
                        db.ProductCategories.Add(newProductcategory);
                        //db.SaveChanges();
                    }

                }
                try
                {
                    db.SaveChanges();
                    return " Ok! " + ProductName + " for " + UnitPrice;
                }
                catch
                {
                    return "Error!";
                }
                
            }

            
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            int Start, End;
            if (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = strSource.IndexOf(strStart, 0) + strStart.Length;
                End = strSource.IndexOf(strEnd, Start);
                return strSource.Substring(Start, End - Start);
            }
            else
            {
                return "";
            }
        }

        //protected string GetWebString(string url)
        //{
        //    string appURL = url;
        //    HttpWebRequest wrWebRequest = WebRequest.Create(appURL) as HttpWebRequest;
        //    HttpWebResponse hwrWebResponse = (HttpWebResponse)wrWebRequest.GetResponse();

        //    StreamReader srResponseReader = new StreamReader(hwrWebResponse.GetResponseStream());
        //    string strResponseData = srResponseReader.ReadToEnd();
        //    srResponseReader.Close();
        //    return strResponseData;
        //}
    }
}