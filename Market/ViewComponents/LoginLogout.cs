using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Market.ViewComponents
{
    public class LoginLogout: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
