using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonData
{
    /// <summary>
    /// Заказы на товар
    /// </summary>
    [Serializable]
    [Table("Orders")]
    public class Order: BaseDelete
    {
        [Browsable(false)]
        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        [DisplayName("Заказчик")]
        public virtual Person Person { get; set; }

        [DisplayName("Товар")]
        public virtual Product Product { get; set; }
        
        [DisplayName("Состояние")]
        public virtual ProductState State { get; set; }

        [DisplayName("Количество")]
        public int Quantity { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        private static string exception = string.Empty;
        public static string GetException()
        {
            return exception;
        }

        public static async Task<List<Order>> GetOrders()
        {
            List<Order> orders = new List<Order>();
            try
            {
                exception = string.Empty;
                string JSONData = await Task.Run(() => JsonConvert.SerializeObject("DataOrders"));
                WebRequest request = WebRequest.Create($"{Authorization.URL}/Home/GetOrders");
                request.Method = "POST";
                string query = $"data={JSONData}";
                byte[] byteMsg = Encoding.UTF8.GetBytes(query);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteMsg.Length;

                using (Stream stream = await request.GetRequestStreamAsync())
                {
                    await stream.WriteAsync(byteMsg, 0, byteMsg.Length);
                }

                WebResponse response = await request.GetResponseAsync();

                string answer = null;

                using (Stream s = response.GetResponseStream())
                {
                    using (StreamReader sR = new StreamReader(s))
                    {
                        answer = await sR.ReadToEndAsync();
                    }
                }

                response.Close();
                var result = await Task.Run(() => JsonConvert.DeserializeObject<(List<Order> Orders, string Error)>(answer));

                if (string.IsNullOrEmpty(result.Error))
                {
                    orders = result.Orders;
                }
                else
                    exception = result.Error;
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }

            return orders;
        }

        public static async void AddOrEdit(Order item)
        {
            try
            {
                exception = string.Empty;
                string JSONData = await Task.Run(() => JsonConvert.SerializeObject(item));
                WebRequest request = WebRequest.Create($"{Authorization.URL}/Home/AddOrEditOrder");
                request.Method = "POST";
                string query = $"data={JSONData}";
                byte[] byteMsg = Encoding.UTF8.GetBytes(query);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteMsg.Length;

                using (Stream stream = await request.GetRequestStreamAsync())
                {
                    await stream.WriteAsync(byteMsg, 0, byteMsg.Length);
                }

                WebResponse response = await request.GetResponseAsync();

                string answer = null;

                using (Stream s = response.GetResponseStream())
                {
                    using (StreamReader sR = new StreamReader(s))
                    {
                        answer = await sR.ReadToEndAsync();
                    }
                }

                response.Close();
                var result = await Task.Run(() => JsonConvert.DeserializeObject<string>(answer));

                if (!string.IsNullOrEmpty(result))
                    exception = result;

            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }

            if (!string.IsNullOrEmpty(Order.GetException()))
                MessageBox.Show(Order.GetException());
        }

        public override async void Delete<T>(List<T> dataBoundItems, EventHandler eventHandler)
        {
            try
            {
                exceptionDel = string.Empty;
                string JSONData = await Task.Run(() => JsonConvert.SerializeObject(dataBoundItems));
                WebRequest request = WebRequest.Create($"{Authorization.URL}/Home/DelOrders");
                request.Method = "POST";
                string query = $"data={JSONData}";
                byte[] byteMsg = Encoding.UTF8.GetBytes(query);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteMsg.Length;

                using (Stream stream = await request.GetRequestStreamAsync())
                {
                    await stream.WriteAsync(byteMsg, 0, byteMsg.Length);
                }

                WebResponse response = await request.GetResponseAsync();

                string answer = null;

                using (Stream s = response.GetResponseStream())
                {
                    using (StreamReader sR = new StreamReader(s))
                    {
                        answer = await sR.ReadToEndAsync();
                    }
                }

                response.Close();
                var result = await Task.Run(() => JsonConvert.DeserializeObject<string>(answer));

                if (!string.IsNullOrEmpty(result))
                    exceptionDel = result;

                eventHandler?.Invoke(this, null);
            }
            catch (Exception ex)
            {
                exceptionDel = ex.Message;
            }
        }
    }
}
