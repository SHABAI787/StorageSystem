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

namespace CommonData
{
    /// <summary>
    /// Товар
    /// </summary>
    [Serializable]
    [Table("Products")]
    public class Product
    {
        private static string exception = string.Empty;

        [Browsable(false)]
        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }

        [DisplayName("Стоимость")]
        public decimal Price { get; set; }

        [DisplayName("Состояние")]
        [ReadOnly(true)]
        public virtual ProductState State { get; set; }

        [DisplayName("Склад")]
        [ReadOnly(true)]
        public virtual Store Store { get; set; }

        [DisplayName("Поставщик")]
        [ReadOnly(true)]
        public virtual Provider Provider { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public static string GetException()
        {
            return exception;
        }

        public static async Task<List<Product>> GetProducts()
        {
            List<Product> products = new List<Product>();
            try
            {
                string JSONData = await Task.Run(() => JsonConvert.SerializeObject("testData"));
                WebRequest request = WebRequest.Create($"{Authorization.URL}/Home/GetProducts");
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
                var result = await Task.Run(() => JsonConvert.DeserializeObject<(List<Product> Products, string Error)>(answer));

                if (string.IsNullOrEmpty(result.Error))
                {
                    products = result.Products;
                }
                else
                    exception = result.Error;
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }

            return products;
        }
    }
}
