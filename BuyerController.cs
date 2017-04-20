using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject123.Models;
using MyProject123.ViewModels;

using System.Data;
using System.Data.Entity;

using System.Net;


using MyProject123.DAL;
using log4net;

namespace MyProject123.Controllers
{
    public class BuyerController : Controller
    {
        //
        // GET: /Buyer/
        MyProject123.DAL.MyContextClass db = new MyProject123.DAL.MyContextClass();
        public ActionResult BIndex()
        {
            BuyerAndBookAndSellerViewModel bb = new BuyerAndBookAndSellerViewModel();
            bb.BookAndSellerMapDisplays = getBookAndSellers();
            bb.SliderContents = getSlider();

            return View(bb);
        }

        public List<SliderContent> getSlider()
        {                 
            var list = db.SliderContents.OrderBy(x => x.SliderContentId).ToList();
            return list;
        }


        public List<BookAndSellerMapDisplay> getBookAndSellers()
        {

         
            var bookandsellermapsprop = db.BookAndSellerMapDisplays.Include(b => b.BookAndSellerMap.Book).Include(b => b.BookAndSellerMap.BookFormat).Include(b => b.BookAndSellerMap.Language).Include(b => b.BookAndSellerMap.Seller).OrderByDescending(n => n.BookAndSellerMap.CreatedOn);
            return bookandsellermapsprop.ToList();
        }



    }
}

       