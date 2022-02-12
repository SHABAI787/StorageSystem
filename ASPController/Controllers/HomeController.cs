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
          
            return await Task.Run(() => JsonConvert.SerializeObject(res));
        }

        [HttpPost]
        public async Task<string> GetProducts(string data)
        {
            (List<Product> Products, string Error) res = (new List<Product>(), "");
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    res.Products = context.Products.Include("State").Include("Store").Include("Provider").ToList();
                }
            }
            catch (Exception ex)
            {
                res.Error = ex.Message;
            }

            return await Task.Run(() => JsonConvert.SerializeObject(res));
        }

        [HttpPost]
        public async Task<(string Products, string Error)> AddProducts(string data)
        {
            (string Products, string Error) res = ("", "");
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    var products = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<Product>>(data));
                    context.Products.AddRange(products);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                res.Error = ex.Message;
            }

            return res;
        }


        /// <summary>
        /// Авторизация. Возвращает кортеж (логин, имя, описание ошибки)
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
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
                    UserBD user = context.UsersBD.FirstOrDefault(u => u.Login == parameters.Login && u.Password == parameters.Password && u.Enabled);
                    if(user == null)
                        res = await Task.Factory.StartNew(() => JsonConvert.SerializeObject((string.Empty, string.Empty, "Не верный логин или пароль")));
                    else
                        res = await Task.Factory.StartNew(() => JsonConvert.SerializeObject((user.Login, user.Person?.Name, string.Empty)));
                }
            }
            catch (Exception ex)
            {
                res = await Task.Factory.StartNew(() => JsonConvert.SerializeObject((string.Empty, string.Empty, ex.Message)));
            }

            return res;
        }

    }
}