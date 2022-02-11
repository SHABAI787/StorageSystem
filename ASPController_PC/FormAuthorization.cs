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
    public partial class FormAuthorization : Form
    {
        public FormAuthorization()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string JSONData = await Task.Run(() => JsonConvert.SerializeObject((textBoxLogin.Text, textBoxPassword.Text)));
                WebRequest request = WebRequest.Create("http://90.188.45.208/ASPController/Home/Authorization");
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
                string result = await Task.Run(() => JsonConvert.DeserializeObject<string>(answer));

                if(string.IsNullOrEmpty(result))
                    MessageBox.Show("Успешно!");
                else
                    MessageBox.Show(result);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Внимание!",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
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
