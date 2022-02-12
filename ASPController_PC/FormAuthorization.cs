using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASPController_PC
{
    public partial class FormAuthorization : Form
    {
        private bool anim = true;
        public FormAuthorization()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            Anim();
            if (await CommonData.Authorization.StartAuthorization(textBoxLogin.Text, textBoxPassword.Text))
            {
                anim = false;
                new FormBase().Show();
                this.Hide();
            }
            else
                MessageBox.Show(CommonData.Authorization.Exception, "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            anim = false;
            progressBar1.Value = 0;
        }

        private async void Anim()
        {
            anim = true;
            await Task.Run(() =>
              {
                  while (anim)
                  {
                      Thread.Sleep(100);
                      progressBar1.Invoke((MethodInvoker)delegate
                      {
                          if (progressBar1.Value == 99)
                              progressBar1.Value = 0;
                          progressBar1.Value++;
                      });
                  }
              });
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FormAuthorization_Load(object sender, EventArgs e)
        {

        }
    }

    [Serializable]
    public class TestData
    {
        public string Name { get; set; }
    }
}
