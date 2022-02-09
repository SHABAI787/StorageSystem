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
            TestData testData = new TestData();
            testData.Name = textBoxName.Text;

            string JSONData = await Task.Run(() => JsonConvert.SerializeObject(testData));

            WebRequest request = WebRequest.Create($"https://{textBoxIP.Text}:{textBoxPort.Text}/Home/Hello");
            request.Method = "POST";
            string query = $"name={JSONData}";
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
