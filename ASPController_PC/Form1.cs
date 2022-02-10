using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using CommonData;

namespace ASPController_PC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            UserBD userBD = new UserBD();
            Person person = new Person();
            userBD.Login = "nik";
            userBD.Password = "pas";
            userBD.Person = person;
            person.LastName = "LastName";
            person.Name = "Name";
            person.MiddleName = "MiddleName";
            person.PhoneNumber = "+792435698585";


            string JSONData = await Task.Run(() => JsonConvert.SerializeObject(userBD));

            //WebRequest request = WebRequest.Create($"http://{textBoxIP.Text}:{textBoxPort.Text}/Home/Hello");
            WebRequest request = WebRequest.Create($"http://{textBoxIP.Text}:{textBoxPort.Text}/Home/AddUserBD");
            request.Method = "POST";
            string query = $"userBD={JSONData}";
            byte[] byteMsg = Encoding.UTF8.GetBytes(query);

            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteMsg.Length;

            using(Stream stream = await request.GetRequestStreamAsync())
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
            MessageBox.Show(helloStr);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

    [Serializable]
    public class TestData
    {
        public string Name { get; set; }
    }
}
