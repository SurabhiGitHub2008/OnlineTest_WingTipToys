using System;
using System.Data.Entity;
using System.Linq;
using WingTipProductCalatog.Models;

namespace WingTipProductCalatog.Services
{
    public class ProductServices :IDisposable
    {
        private static TecSys_WINGTIPTOYSEntities db = new TecSys_WINGTIPTOYSEntities();

        public static int GetProductCategoryID(string categoryName)
        {
            int categoryID;
            try
            {
                var category = db.Categories.Where(x => x.CategoryName.Equals(categoryName));
                categoryID=category.ToList()[0].CategoryID;
            }
            catch (Exception e)
            {

                throw e;
            }
            

            return categoryID;
            // This can be more generalized to return a category based on input.
            //However as the Category was hardcoded to be Car in this isntance

        }
        public static IQueryable<Product> GetAllProducts(int? category = 1)
        {
            IQueryable<Product> products;
            try
            {
                products = db.Products.Include(p => p.Category);

                products = products.Where(x => x.CategoryID == category);
            }
            catch (Exception e)
            {

                throw e;
            }

            
            return products;
        }

        public static IQueryable<Product> GetAllProductsBasedOnSerach(string txtSearch, int? category)
        {
            IQueryable<Product> products;

            try
            {
                products = db.Products.Where(x => (x.ProductName.Contains(txtSearch)
                                             || x.Description.Contains(txtSearch))
                                             && x.CategoryID == category);
            }
            catch (Exception e)
            {

                throw e;
            }
            
            return products;
        }
        public void Dispose()
        {
            if (db!=null)
            {
                db.Dispose();
                db = null;
            }
        }
        
    }
}