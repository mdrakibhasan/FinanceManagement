using Fin.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace financemanagement.Controllers
{
    public class JournalController : Controller
    {
        // GET: Journsl
        public ActionResult Create()
        {
            var data = new VmAccountTransactionMst();
            return View();
        }
        
        public ActionResult Index()
        {
            return View();
        }

    }
}