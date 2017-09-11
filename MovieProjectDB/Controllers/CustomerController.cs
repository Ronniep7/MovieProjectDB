using MovieProjectDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieProjectDB.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> Cuslis = DAL.CustomerTableHelper.GetCustomers();

            return View(Cuslis);
        }
        public ActionResult New()
        {

            return View();
        }
        public ActionResult CustomersSave(string CustomerName, string SubName, string CustomerAge)
        {
            bool isvalid = CustomerName == "" || SubName == "" || CustomerAge == "";

            if (isvalid)
            {
                if (CustomerName == null || CustomerName == "")
                {
                    ViewBag.NameEror = "Please Enter A Name(SERVER)";
                    return View("New");
                }
                if (SubName == null || SubName == "Select")
                {
                    ViewBag.SelectEror = "Please Select A Subscribe Type (SERVER)";
                    return View("New");
                }
                if (CustomerAge == null || CustomerAge == "")
                {
                    ViewBag.Eror = "Please Enter Your Age (SERVER)";
                    return View("New");
                }
              

                ViewBag.Eror = "Please Fill In All The Details(server)";
                return View("New");
            }
            else
            {
                int parseage = int.Parse(CustomerAge);
                if (parseage < 18)
                {
                    ViewBag.Eror = "Age Must Be Greater Then 18(server)";
                    return View("New");
                }

                bool Existcustomer = DAL.CustomerTableHelper.CustomerExist(CustomerName);

                if (Existcustomer)
                {
                    ViewBag.EROR = "Customer Already Exist";
                    return View("New");

                }
                else
                {
                    int RowsAffected = DAL.CustomerTableHelper.Insert(CustomerName, SubName, CustomerAge);
                    if (RowsAffected != 1)
                    {
                        ViewBag.EROR = "Insert Failed";
                        return View("New");

                    }
                    return RedirectToAction("Index");

                }
            }
             RedirectToAction("Index");

        }

    }
}