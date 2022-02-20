using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonData
{
    /// <summary>
    /// Поставщик
    /// </summary>
    [Serializable]
    [Table("Providers")]
    public class Provider : BaseDelete
    {
        [Browsable(false)]
        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        [DisplayName("Наименование")]
        public string Name { get; set; }

        [Browsable(false)]
        [DisplayName("Ответственный")]
        public virtual Person Responsible { get; set; }

        [NotMapped]
        [DisplayName("Ответственный")]
        public string ResponsibleText
        {
            get { return $"{Responsible} - {Responsible?.Post?.Name} {Responsible?.PhoneNumber} {Responsible?.Email}"; }
        }

        public override string ToString()
        {
            return Name;
        }

        private static string exception = string.Empty;
        public static string GetException()
        {
            return exception;
        }

        public static async Task<List<Provider>> GetProviders()
        {
            List<Provider> lists = new List<Provider>();
            try
            {
                string JSONData = await Task.Run(() => JsonConvert.SerializeObject("DataLists"));
                WebRequest request = WebRequest.Create($"{Authorization.URL}/Home/GetProviders");
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
                var result = await Task.Run(() => JsonConvert.DeserializeObject<(List<Provider> Lists, string Error)>(answer));

                if (string.IsNullOrEmpty(result.Error))
                {
                    lists = result.Lists;
                }
                else
                    exception = result.Error;
            }
            catch (Exception ex)
            {
                exception = ex.Message;
            }

            return lists;
        }

        public static async void AddOrEdit(Provider item)
        {
            try
            {
                exception = string.Empty;
                string JSONData = await Task.Run(() => JsonConvert.SerializeObject(item));
                WebRequest request = WebRequest.Create($"{Authorization.URL}/Home/AddOrEditProvider");
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

            if (!string.IsNullOrEmpty(UserBD.GetException()))
                MessageBox.Show(UserBD.GetException());
        }

        public override async void Delete<T>(List<T> dataBoundItems, EventHandler eventHandler)
        {
            try
            {
                exceptionDel = string.Empty;
                string JSONData = await Task.Run(() => JsonConvert.SerializeObject(dataBoundItems));
                WebRequest request = WebRequest.Create($"{Authorization.URL}/Home/DelProviders");
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
