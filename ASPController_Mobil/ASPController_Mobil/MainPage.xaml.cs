using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net;
using System.Net.Http;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;

namespace ASPController_Mobil
{
    public partial class MainPage : ContentPage
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string testURL = "http://192.168.0.8/ASPController/Home/Hello";
        //private readonly string testURL = "http://192.168.1.32/Home/Hello";
        //private readonly string testURL = $"http://localhost:44332/Home/Hello";
        public MainPage()
        {
            InitializeComponent();
        }

        int count = 0;
        private async void Button_Clicked(object sender, EventArgs e)
        {
            count++;
            ((Button)sender).Text = $"You clicked {count} times.";

            //Dictionary<string, string> dict = new Dictionary<string, string>()
            //{
            //    { "name","Nikita"}
            //};

            //FormUrlEncodedContent form = new FormUrlEncodedContent(dict);
            //HttpResponseMessage response = await client.PostAsync(testURL, form);
            //string result = await response.Content.ReadAsStringAsync();

            string JSONData = await Task.Run(() => JsonConvert.SerializeObject("NIKITA"));

            //WebRequest request = WebRequest.Create($"http://{textBoxIP.Text}:{textBoxPort.Text}/Home/Hello");
            WebRequest request = WebRequest.Create(testURL);
            request.Method = "POST";
            string query = $"name={JSONData}";
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
            string helloStr = await Task.Run(() => JsonConvert.DeserializeObject<string>(answer));

            await DisplayAlert("Результат", helloStr, "ОК");
        }
    }
}
