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
    /// Физическое лицо
    /// </summary>
    [Serializable]
    [Table("Persons")]
    public class Person
    {
        private static string exception = string.Empty;

        [Browsable(false)]
        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        [DisplayName("Фамилия")]
        public string LastName { get; set; }

        [DisplayName("Имя")]
        public string Name { get; set; }

        [DisplayName("Отчество")]
        public string MiddleName { get; set; }

        [DisplayName("Дата рождения")]
        public DateTime? DataBirth { get; set; }

        [DisplayName("Электронная почта")]
        public string Email { get; set; }

        [DisplayName("Номер телефона")]
        public string PhoneNumber { get; set; }

        [DisplayName("Должность")]
        [ReadOnly(true)]
        public virtual Post Post { get; set; }

        public override string ToString()
        {
            return $"{LastName} {Name} {MiddleName}";
        }

        public static string GetException()
        {
            return exception;
        }

        public static async Task<List<Person>> GetPersons()
        {
            List<Person> lists = new List<Person>();
            try
            {
                string JSONData = await Task.Run(() => JsonConvert.SerializeObject("DataLists"));
                WebRequest request = WebRequest.Create($"{Authorization.URL}/Home/GetPersons");
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
                var result = await Task.Run(() => JsonConvert.DeserializeObject<(List<Person> Lists, string Error)>(answer));

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
    }
}
