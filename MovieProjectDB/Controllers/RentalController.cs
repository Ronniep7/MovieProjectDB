using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieProjectDB.Controllers
{
    public class RentalController : Controller
    {
        // GET: Rental
        public ActionResult New()
        {


            return View();
        }
        [HttpPost]
        public ActionResult CreateNewRentals(string CustomerName, string MovieName)
        {
            bool isfree = true;
            string Messege = "";
            if (CustomerName == "")
            {
                Messege = "Please Enter A Customer(Server)";
                isfree = false;
            }
            else if (MovieName == "")
            {
                Messege = "Please Enter A Movie(Server)";
                isfree = false;
            }
            else
            {
                bool movExist = DAL.MovieTableHelper.MovExist(MovieName);
                bool cusExist = DAL.CustomerTableHelper.CustomerExist(CustomerName);
                if (movExist == false)
                {
                    Messege = "Movie NOT Exist";
                    isfree = false;
                }
                if (cusExist == false)
                {
                    Messege = "customer NOT Exist";
                    isfree = false;

                }
                if (movExist==true && cusExist == true)
                {
                    
                    int movResult = DAL.RentalTableHelper.getID("MovieTable", MovieName);

                    bool ex = DAL.RentalTableHelper.RentalExist(movResult);

                    if (ex)
                    {
                        Messege = "Movie Already Rented";
                        isfree = false;

                    }
                    else
                    {
                     int cusResult = DAL.RentalTableHelper.getID("CustomerTable", CustomerName);

                    int InsertResult = DAL.RentalTableHelper.Insert(movResult,cusResult);
                        Messege = "Movie Rented successfully";

                    }


                }
            }

            var obj = new { Messege1 = Messege, isfree1 = isfree };

            return Json(obj);
        }
    }
}