using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CaliforniaPep.Models
{
    public class ProductDatabaseInitializer : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));
            GetProductCategories().ForEach(n => context.ProductCategories.Add(n));
        }

        private static List<Category> GetCategories()
        {
            var categories = new List<Category> {
                new Category
                {
                    CategoryID = 1,
                    CategoryName = " Alzheimer's"
                },
                new Category
                {
                    CategoryID = 2,
                    CategoryName = " Central Nervous System"
                },
                new Category
                {
                    CategoryID = 3,
                    CategoryName = "Human"
                },
                new Category
                {
                    CategoryID = 4,
                    CategoryName = "Neuropeptides & Hormones"
                },
                new Category
                {
                    CategoryID = 5,
                    CategoryName = "Cardiovascular"
                },
            };

            return categories;
        }

        private static List<Product> GetProducts()
        {
            var products = new List<Product> {
                new Product
                {
                    ProductId = 1,
                    ProductName = "Angiotensin Fragment ( 1-7 ) Acetate Car",
                    Sequence = "Asp-Arg-Val-Tyr-Ile-His-Pro-OH",
                    MolecularWeight = 898.48,
                    CatalogNumber = "131-41",
                    Amount = 5.0,
                    Unit = Unit.mg,
                    UnitPrice = 55.00m
                    
               },
                new Product
                {
                    ProductId = 2,
                    ProductName = "Acetyl Beta Amyloid (25-35)",
                    Sequence = "Acetyl-Gly-Ser-Asn-Lys-Gly-Ala-Ile-Ile-Gly-Leu-Met-OH",
                    MolecularWeight = 1101.59,
                    CatalogNumber = "641-59",
                    Amount = 1.0,
                    Unit = Unit.mg,
                    UnitPrice = 55.00m
                    
               }                                       
            };

            return products;
        }

        private static List<ProductCategory> GetProductCategories()
        {
            var productCategories = new List<ProductCategory> {
                new ProductCategory
                {
                    ProductCategoryId = 1,
                    ProductId = 1,
                    CategoryId = 5                    
               },
               new ProductCategory
                {
                    ProductCategoryId = 2,
                    ProductId = 1,
                    CategoryId = 4
                    
               },
               new ProductCategory
                {
                    ProductCategoryId = 3,
                    ProductId = 2,
                    CategoryId = 1                    
               },
               new ProductCategory
                {
                    ProductCategoryId = 4,
                    ProductId = 2,
                    CategoryId = 2                    
               },
               new ProductCategory
                {
                    ProductCategoryId = 5,
                    ProductId = 2,
                    CategoryId = 3                    
               },
               new ProductCategory
                {
                    ProductCategoryId = 6,
                    ProductId = 2,
                    CategoryId = 4                    
               }

            };
            return productCategories;
        }
    }
}
