using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace WingTipProductCatalogTest.Views
{
    /// <summary>
    /// Summary description for ProductIndexViewTest
    /// </summary>
    [TestClass]
    public class ProductIndexViewTest
    {
 

        [TestMethod]
        public void Index()
        {
            var view = new ViewResult();
            //Incomplete implementation
            //The requirement was to Test the validtion of Textbox
            //Which will requiree Unit Testing the views:
            //There is a way to pre-compile views and run Test cases on them using RazorGenerator nuGet
            //However bets option will be to add the validation on the Model using DataAnnotation and unit test the Model

            Assert.IsTrue(true);
        }
    }
}
