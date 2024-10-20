using Fin.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace financemanagement.Controllers
{
    public class ChartOfAccountsController : Controller
    {
        // GET: ChartOfAccounts
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create(VmAccountsHead model)
        {
            return View();
        }

        [HttpPost]
        [Route("create")]
        public ActionResult CoaSetup(VmAccountsHead model)
        {
            return View();
        }
    }
}