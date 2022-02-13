using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommonData
{
    /// <summary>
    /// Пользователь программы
    /// </summary>
    [Serializable]
    [Table("UsersBD")]
    public class UserBD:BaseDelete
    {
        [Key]
        [DisplayName("Логин")]
        public string Login { get; set; }

        [Browsable(false)]
        [DisplayName("Пароль")]
        public string Password { get; set; }

        [NotMapped]
        [DisplayName("Пароль")]
        public string PasswordView 
        { 
            get { return string.IsNullOrEmpty(Password) ? "" :  string.Concat(Password.Select(s => "*")); }
        }

        [DisplayName("Физ. лицо")]
        [ReadOnly(true)]
        public virtual Person Person { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Активность")]
        public bool Enabled { get; set; }

        public override string ToString()
        {
            return $"{Login} {(Enabled ? "Активен" : "Не активен")}";
        }

        private static string exception = string.Empty;
        public static string GetException()
        {
            return exception;
        }

        public static async Task<List<UserBD>> GetusersBD()
        {
            List<UserBD> lists = new List<UserBD>();
            try
            {
                string JSONData = await Task.Run(() => JsonConvert.SerializeObject("DataLists"));
                WebRequest request = WebRequest.Create($"{Authorization.URL}/Home/GetUsersBD");
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
                var result = await Task.Run(() => JsonConvert.DeserializeObject<(List<UserBD> Lists, string Error)>(answer));

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

        public override async void Delete<T>(List<T> dataBoundItems, EventHandler eventHandler)
        {
            try
            {
                exceptionDel = string.Empty;
                string JSONData = await Task.Run(() => JsonConvert.SerializeObject(dataBoundItems));
                WebRequest request = WebRequest.Create($"{Authorization.URL}/Home/DelUsersBD");
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