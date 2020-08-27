using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WingTipProductCalatog.Services;

namespace WingTipProductCalatog.Controllers
{
    public class ProductsController : Controller
    {

        int? category = ProductServices.GetProductCategoryID("Cars");

        // GET: Products
        public ActionResult Index()
        {
            try
            {
                var products = ProductServices.GetAllProducts(category);

                if (products == null)
                {
                    return HttpNotFound();
                }
                return View(products.ToList());
            }
            catch (Exception e)
            {

                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            /*To utilize the hidden field we can add the code  
            string hdnField = collection["[0].ProductID"]; // replace 0 with the required index to get the id value
            */
            string txtSearch = collection["txtSearch"].Trim().ToString();

            if (txtSearch == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            try
            {
                var product = ProductServices.GetAllProductsBasedOnSerach(txtSearch, category);

                if (product == null)
                {
                    return HttpNotFound();
                }
                return View(product.ToList());
            }
            catch (Exception e)
            {
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, e.Message);

            }

        }


    }
}
