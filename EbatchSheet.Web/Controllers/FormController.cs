using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace EbatchSheet.Web.Controllers
{
    [Authorize]
    public class FormController : Controller
    {
        [Route ("form")]
        public IActionResult AppForm()
        {
            return View();
        }
    }
}
