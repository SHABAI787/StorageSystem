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
                    res.Products = context.Products.Include("State").Include("Store").Include("Provider")
                        .Include("Provider.Responsible").Include("Provider.Responsible.Post").ToList();
                }
            }
            catch (Exception ex)
            {
                res.Error = ex.Message;
            }

            return await Task.Run(() => JsonConvert.SerializeObject(res));
        }

        [HttpPost]
        public async Task<string> AddOrEditProduct(string data)
        {
            string error = string.Empty;
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    var itemAddOrEdit = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Product>(data));
                    itemAddOrEdit.State = itemAddOrEdit.State != null ? context.ProductStates.FirstOrDefault(p => p.Id == itemAddOrEdit.State.Id) : null;
                    itemAddOrEdit.Provider = itemAddOrEdit.Provider != null ? context.Providers.FirstOrDefault(p => p.Id == itemAddOrEdit.Provider.Id) : null;
                    itemAddOrEdit.Store = itemAddOrEdit.Store != null ? context.Stores.FirstOrDefault(p => p.Id == itemAddOrEdit.Store.Id) : null;
                    if (itemAddOrEdit.Id <= 0)
                    {
                        context.Products.Add(itemAddOrEdit);
                    }
                    else
                    {
                        var itemEdit = context.Products.FirstOrDefault(p => p.Id == itemAddOrEdit.Id);
                        if (itemEdit != null)
                        {
                            itemEdit.Name = itemAddOrEdit.Name;
                            itemEdit.State = itemAddOrEdit.State;
                            itemEdit.Store = itemAddOrEdit.Store;
                            itemEdit.Provider = itemAddOrEdit.Provider;
                            itemEdit.Price = itemAddOrEdit.Price;
                            itemEdit.Description = itemAddOrEdit.Description;
                        }
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return JsonConvert.SerializeObject(error);
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
        public async Task<string> GetStates(string data)
        {
            (List<ProductState> Products, string Error) res = (new List<ProductState>(), "");
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    res.Products = context.ProductStates.ToList();
                }
            }
            catch (Exception ex)
            {
                res.Error = ex.Message;
            }

            return await Task.Run(() => JsonConvert.SerializeObject(res));
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
                        Include("Product").Include("Product.State").Include("Product.Store")
                        .Include("Product.Provider").Include("Product.Provider.Responsible")
                        .Include("Product.Provider.Responsible.Post").ToList();
                }
            }
            catch (Exception ex)
            {
                res.Error = ex.Message;
            }

            return await Task.Run(() => JsonConvert.SerializeObject(res));
        }

        [HttpPost]
        public async Task<string> AddOrEditOrder(string data)
        {
            string error = string.Empty;
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    var itemAddOrEdit = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Order>(data));
                    itemAddOrEdit.State = itemAddOrEdit.State != null ? context.ProductStates.FirstOrDefault(p => p.Id == itemAddOrEdit.State.Id) : null;
                    itemAddOrEdit.Person = itemAddOrEdit.Person != null ? context.Persons.FirstOrDefault(p => p.Id == itemAddOrEdit.Person.Id) : null;
                    itemAddOrEdit.Product = itemAddOrEdit.Product != null ? context.Products.FirstOrDefault(p => p.Id == itemAddOrEdit.Product.Id) : null;
                    if (itemAddOrEdit.Id <= 0)
                    {
                        context.Order.Add(itemAddOrEdit);
                    }
                    else
                    {
                        var itemEdit = context.Order.FirstOrDefault(p => p.Id == itemAddOrEdit.Id);
                        if (itemEdit != null)
                        {
                            itemEdit.Description = itemAddOrEdit.Description;
                            itemEdit.Quantity = itemAddOrEdit.Quantity;
                            itemEdit.State = itemAddOrEdit.State;
                            itemEdit.Person = itemAddOrEdit.Person;
                            itemEdit.Product = itemAddOrEdit.Product;
                        }
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return JsonConvert.SerializeObject(error);
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
        public async Task<string> AddOrEditPerson(string data)
        {
            string error = string.Empty;
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    var itemAddOrEdit = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Person>(data));
                    itemAddOrEdit.Post = itemAddOrEdit.Post != null ? context.Posts.FirstOrDefault(p => p.Id == itemAddOrEdit.Post.Id) : null;
                    if (itemAddOrEdit.Id <= 0)
                    {
                        context.Persons.Add(itemAddOrEdit);
                    }
                    else
                    {
                        var itemEdit = context.Persons.FirstOrDefault(p => p.Id == itemAddOrEdit.Id);
                        if (itemEdit != null)
                        {
                            itemEdit.LastName = itemAddOrEdit.LastName;
                            itemEdit.Name = itemAddOrEdit.Name;
                            itemEdit.MiddleName = itemAddOrEdit.MiddleName;
                            itemEdit.PhoneNumber = itemAddOrEdit.PhoneNumber;
                            itemEdit.Post = itemAddOrEdit.Post;
                            itemEdit.Email = itemAddOrEdit.Email;
                            itemEdit.DataBirth = itemAddOrEdit.DataBirth;
                        }
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return JsonConvert.SerializeObject(error);
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
        public async Task<string> AddOrEditPost(string data)
        {
            string error = string.Empty;
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    var itemAddOrEdit = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Post>(data));

                    if (itemAddOrEdit.Id <= 0)
                    {
                        context.Posts.Add(itemAddOrEdit);
                    }
                    else
                    {
                        var itemEdit = context.Posts.FirstOrDefault(p => p.Id == itemAddOrEdit.Id);
                        itemEdit.Name = itemAddOrEdit.Name;
                        itemEdit.Description = itemAddOrEdit.Description;
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return JsonConvert.SerializeObject(error);
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
        public async Task<string> AddOrEditProvider(string data)
        {
            string error = string.Empty;
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    var itemAddOrEdit = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Provider>(data));
                    itemAddOrEdit.Responsible = itemAddOrEdit.Responsible != null ? context.Persons.FirstOrDefault(p => p.Id == itemAddOrEdit.Responsible.Id) : null;
                    
                    if (itemAddOrEdit.Id <= 0)
                    {
                        context.Providers.Add(itemAddOrEdit);
                    }
                    else
                    {
                        var itemEdit = context.Providers.FirstOrDefault(p => p.Id == itemAddOrEdit.Id);
                        itemEdit.Name = itemAddOrEdit.Name;
                        itemEdit.Responsible = itemAddOrEdit.Responsible;
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return JsonConvert.SerializeObject(error);
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
        public async Task<string> AddOrEditStore(string data)
        {
            string error = string.Empty;
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    var itemAddOrEdit = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Store>(data));
                  
                    if (itemAddOrEdit.Id <= 0)
                    {
                        context.Stores.Add(itemAddOrEdit);
                    }
                    else
                    {
                        var itemEdit = context.Stores.FirstOrDefault(p => p.Id == itemAddOrEdit.Id);
                        itemEdit.Name = itemAddOrEdit.Name;
                        itemEdit.Description = itemAddOrEdit.Description;
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return JsonConvert.SerializeObject(error);
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
        public async Task<string> AddOrEditUserBD(string data)
        {
            string error = string.Empty;
            try
            {
                using (ContextBD context = new ContextBD())
                {
                    var itemAddOrEdit = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<UserBD>(data));
                    itemAddOrEdit.Person = itemAddOrEdit.Person != null ? context.Persons.FirstOrDefault(p => p.Id == itemAddOrEdit.Person.Id) : null;
                    var itemEditOrNew = context.UsersBD.FirstOrDefault(p => p.Login == itemAddOrEdit.Login);
                    if (itemEditOrNew == null)
                    {
                        context.UsersBD.Add(itemAddOrEdit);
                    }
                    else
                    {
                        itemEditOrNew.Login = itemAddOrEdit.Login;
                        itemEditOrNew.Password = itemAddOrEdit.Password;
                        itemEditOrNew.Description = itemAddOrEdit.Description;
                        itemEditOrNew.Enabled = itemAddOrEdit.Enabled;
                        itemEditOrNew.Person = itemAddOrEdit.Person;
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }

            return JsonConvert.SerializeObject(error);
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