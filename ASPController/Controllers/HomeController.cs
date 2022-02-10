using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace ASPController.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("Default");
        }

        [HttpPost]
        public async Task<string> Hello(string name)
        {
            string userNmae = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<string>(name));
            //TestData userNmae = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<TestData>(name));
            return await Task.Factory.StartNew(() => JsonConvert.SerializeObject($"Hello {userNmae}"));
        }
    }

    [Serializable]
    public class TestData
    {
        public string Name { get; set; }
    }
}