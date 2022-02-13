﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommonData
{
    /// <summary>
    /// Заказы на товар
    /// </summary>
    [Serializable]
    [Table("Orders")]
    public class Order
    {
        private static string exception = string.Empty;

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

        public static async void Delete(List<Order> dataBoundItems)
        {
            try
            {
                exception = string.Empty;
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
                    exception = result;
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }
        }
    }
}
