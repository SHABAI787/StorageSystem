using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using CommonData;
using System.Data.Entity;

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
        public async Task<string> DelProducts(string data)
        {
            string error = string.Empty;
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    List<Product> delItems = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<Product>>(data));
                    foreach (var delItem in delItems)
                    {
                        context.Products.Remove(context.Products.FirstOrDefault(o => o.Id == delItem.Id));
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return await Task.Run(() => JsonConvert.SerializeObject(error));
        }

        [HttpPost]
        public async Task<string> GetOrders(string data)
        {
            (List<Order> Orders, string Error) res = (new List<Order>(), "");
            try
            {
                using (ContextBD context = new ContextBD())
                {
                   res.Orders = context.Order.Include("State").Include("Person").Include("Person.Post").
                        Include("Product").Include("Product.State").Include("Product.Store").
                        Include("Product.Provider").ToList();
                }
            }
            catch (Exception ex)
            {
                res.Error = ex.Message;
            }

            return await Task.Run(() => JsonConvert.SerializeObject(res));
        }

        [HttpPost]
        public async Task<string> DelOrders(string data)
        {
            string error = string.Empty;
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    List<Order> delItems = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<Order>>(data));
                    foreach (var delItem in delItems)
                    {
                        context.Order.Remove(context.Order.FirstOrDefault(o => o.Id == delItem.Id));
                    }
                    
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return await Task.Run(() => JsonConvert.SerializeObject(error));
        }

        [HttpPost]
        public async Task<string> GetPersons(string data)
        {
            (List<Person> List, string Error) res = (new List<Person>(), "");
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    res.List = context.Persons.Include("Post").ToList();
                }
            }
            catch (Exception ex)
            {
                res.Error = ex.Message;
            }

            return await Task.Run(() => JsonConvert.SerializeObject(res));
        }

        [HttpPost]
        public async Task<string> DelPersons(string data)
        {
            string error = string.Empty;
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    List<Person> delItems = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<Person>>(data));
                    foreach (var delItem in delItems)
                    {
                        context.Persons.Remove(context.Persons.FirstOrDefault(o => o.Id == delItem.Id));
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return await Task.Run(() => JsonConvert.SerializeObject(error));
        }

        [HttpPost]
        public async Task<string> GetPosts(string data)
        {
            (List<Post> List, string Error) res = (new List<Post>(), "");
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    res.List = context.Posts.ToList();
                }
            }
            catch (Exception ex)
            {
                res.Error = ex.Message;
            }

            return await Task.Run(() => JsonConvert.SerializeObject(res));
        }

        [HttpPost]
        public async Task<string> DelPosts(string data)
        {
            string error = string.Empty;
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    List<Post> delItems = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<Post>>(data));
                    foreach (var delItem in delItems)
                    {
                        context.Posts.Remove(context.Posts.FirstOrDefault(o => o.Id == delItem.Id));
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return await Task.Run(() => JsonConvert.SerializeObject(error));
        }

        [HttpPost]
        public async Task<string> GetProviders(string data)
        {
            (List<Provider> List, string Error) res = (new List<Provider>(), "");
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    res.List = context.Providers.Include("Responsible").Include("Responsible.Post").ToList();
                }
            }
            catch (Exception ex)
            {
                res.Error = ex.Message;
            }

            return await Task.Run(() => JsonConvert.SerializeObject(res));
        }

        [HttpPost]
        public async Task<string> DelProviders(string data)
        {
            string error = string.Empty;
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    List<Provider> delItems = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<Provider>>(data));
                    foreach (var delItem in delItems)
                    {
                        context.Providers.Remove(context.Providers.FirstOrDefault(o => o.Id == delItem.Id));
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return await Task.Run(() => JsonConvert.SerializeObject(error));
        }

        [HttpPost]
        public async Task<string> GetStores(string data)
        {
            (List<Store> List, string Error) res = (new List<Store>(), "");
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    res.List = context.Stores.ToList();
                }
            }
            catch (Exception ex)
            {
                res.Error = ex.Message;
            }

            return await Task.Run(() => JsonConvert.SerializeObject(res));
        }

        [HttpPost]
        public async Task<string> DelStores(string data)
        {
            string error = string.Empty;
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    List<Store> delItems = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<Store>>(data));
                    foreach (var delItem in delItems)
                    {
                        context.Stores.Remove(context.Stores.FirstOrDefault(o => o.Id == delItem.Id));
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return await Task.Run(() => JsonConvert.SerializeObject(error));
        }

        [HttpPost]
        public async Task<string> GetUsersBD(string data)
        {
            (List<UserBD> List, string Error) res = (new List<UserBD>(), "");
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    res.List = context.UsersBD.Include("Person").Include("Person.Post").ToList();
                }
            }
            catch (Exception ex)
            {
                res.Error = ex.Message;
            }

            return await Task.Run(() => JsonConvert.SerializeObject(res));
        }

        [HttpPost]
        public async Task<string> DelUsersBD(string data)
        {
            string error = string.Empty;
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    List<UserBD> delItems = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<UserBD>>(data));
                    foreach (var delItem in delItems)
                    {
                        context.UsersBD.Remove(context.UsersBD.FirstOrDefault(o => o.Login == delItem.Login));
                    }

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return await Task.Run(() => JsonConvert.SerializeObject(error));
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