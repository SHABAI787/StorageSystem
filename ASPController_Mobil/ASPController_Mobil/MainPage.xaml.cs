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

namespace ASPController_Mobil
{
    public partial class MainPage : ContentPage
    {
        private static readonly HttpClient client = new HttpClient();
        private readonly string testURL = "http://192.168.1.32/Home/Hello";
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

            Dictionary<string, string> dict = new Dictionary<string, string>()
            {
                { "name","Nikita"}
            };

            FormUrlEncodedContent form = new FormUrlEncodedContent(dict);
            HttpResponseMessage response = await client.PostAsync(testURL, form);
            string result = await response.Content.ReadAsStringAsync();

            await DisplayAlert("Результат", result, "ОК");
        }
    }
}
