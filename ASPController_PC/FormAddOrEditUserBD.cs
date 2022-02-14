using CommonData;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace ASPController_PC
{
    public partial class FormAddOrEditUserBD : Form
    {
        UserBD user = null;
        public FormAddOrEditUserBD(UserBD user = null)
        {
            InitializeComponent();
            LoadData();
            if (user != null)
            {
                this.user = user;
                textBoxLogin.Text = user.Login;
                richTextBoxDescription.Text = user.Description;
                textBoxPassword.Text = user.Password;
                checkBoxEnable.Checked = user.Enabled;
                this.Text = @"Изменение пользователя";
                button.Text = "Сохранить изменения";
            }
            else
            {
                this.user = new UserBD();
            }
        }

        private async void LoadData()
        {
            comboBoxPerson.DataSource = new ObservableCollection<Person>(await Person.GetPersons()).ToBindingList();

            if (user.Person != null)
                comboBoxPerson.SelectedItem = comboBoxPerson.Items.Cast<Person>().First(p => p.Id == user.Person.Id);
        }

        private void buttonAddOrEdit_Click(object sender, EventArgs e)
        {
            user.Login = textBoxLogin.Text;
            user.Password = string.IsNullOrEmpty(textBoxPassword.Text) ? null : textBoxPassword.Text;
            user.Description = richTextBoxDescription.Text;
            user.Enabled = checkBoxEnable.Checked;
            user.Person = comboBoxPerson.SelectedIndex >= 0 ? (Person)comboBoxPerson.SelectedItem : null;
            UserBD.AddOrEdit(user);
        }
    }
}
