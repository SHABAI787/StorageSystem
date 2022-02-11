using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using CommonData;

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

        [HttpPost]
        public async Task<string> AddUserBD(string userBD)
        {
            string res = string.Empty;
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    UserBD user = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<UserBD>(userBD));
                    context.UsersBD.Add(user);
                    context.SaveChanges();
                }
                res = "Добавлено";
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }
          
            return await Task.Factory.StartNew(() => JsonConvert.SerializeObject(res));
        }

        [HttpPost]
        public async Task<string> Authorization(string data)
        {
            string res = string.Empty;
            var parameters = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<(string Login, string Password)>(data));
            parameters.Password = string.IsNullOrEmpty(parameters.Password) ? null : parameters.Password;
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    if (!context.UsersBD.Any(u => u.Login == parameters.Login && u.Password == parameters.Password))
                        res = "Не верный логин или пароль";
                }
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }

            return res;
        }

    }
}