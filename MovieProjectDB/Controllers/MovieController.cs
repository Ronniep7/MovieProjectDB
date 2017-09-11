using MovieProjectDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieProjectDB.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            List<Movie> mov = DAL.MovieTableHelper.GetMovies();

            return View(mov);

            
        }
        public ActionResult New()
        {

            return View();
        }
        [HttpPost]
        public ActionResult MovieSave(string Moviename, string CatName)
        {
            bool isvalid = Moviename == "" || CatName == "";
            if (isvalid)
            {

                if (Moviename == "")
                {
                    ViewBag.NameERROR = "Please Enter A Movie Name(SERVER)";
                    return View("New");
                }
                ViewBag.ERROR = "Please Fill In All The Details(server)";

                return View("New");
            }
            else
            {
                bool Exist = DAL.MovieTableHelper.MovExist(Moviename);

                if (Exist)
                {
                    ViewBag.ERROR = "Movie Already Exist(server)";
                    return View("New");
                }
                else
                {

                    int RowsAffected = DAL.MovieTableHelper.Insert(Moviename, CatName);
                    if (RowsAffected != 1)
                    {
                        ViewBag.ERROR = "Insert Failed";
                        return View("New");

                    }
                    ViewBag.ERROR = "Movie Added Successfully";
                }


            }
             return RedirectToAction("Index");

        }
    }
}