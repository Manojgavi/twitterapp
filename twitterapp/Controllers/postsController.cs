using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

using System.Net;
using System.Web;
using System.Web.Mvc;
using twitterapp.Models;

namespace twitterapp.Controllers
{
    
    public class postsController : Controller
    {
        private Model1 db = new Model1();
        // GET: posts
        public ActionResult Index()
        {
            var newposts = db.newposts.Include(n => n.user);
            return View(newposts.ToList());
        }
    }
}