using Sisbg.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sisbg.Controllers
{
    public class BaseController : Controller
    {
        protected ISisbgData data;

        public BaseController(ISisbgData data)
        {
            this.data = data;
        }
    }
}