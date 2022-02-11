using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CommonData
{
    public static class Authorization
    {
        public const string URL = "http://90.188.45.208/ASPController";
        public static string Exception = string.Empty;
        public static string Login = string.Empty;
        public static string Name = string.Empty;

        public static async Task<bool> StartAuthorization(string login, string password)
        {
            bool res = false;
            try
            {
                string JSONData = await Task.Run(() => JsonConvert.SerializeObject((login, password)));
                WebRequest request = WebRequest.Create($"{URL}/Home/Authorization");
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
                var result = await Task.Run(() => JsonConvert.DeserializeObject<(string Login, string Name, string Exception)>(answer));

                if (!string.IsNullOrEmpty(result.Login))
                {
                    res = true;
                    Login = result.Login;
                    Name = result.Name;
                }
                else
                    Exception = "Не верный логин или пароль";

            }
            catch (Exception ex)
            {
                Exception = ex.Message;
            }

            return res;
        }
    }
}
