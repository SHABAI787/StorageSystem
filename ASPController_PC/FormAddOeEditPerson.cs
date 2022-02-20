using CommonData;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace ASPController_PC
{
    public partial class FormAddOrEditPerson : Form
    {
        Person person = null;
        public FormAddOrEditPerson(Person person = null)
        {
            InitializeComponent();
            dateTimePickerBirth.Value = DateTime.Now;
            LoadData();
            if (person != null)
            {
                this.person = person;
                textBoxLastName.Text = person.LastName;
                textBoxName.Text = person.Name;
                textBoxMiddleName.Text = person.MiddleName;
                dateTimePickerBirth.Value = person.DataBirth == null ? DateTime.Now : person.DataBirth.Value;
                textBoxEmail.Text = person.Email;
                textBoxNumber.Text = person.PhoneNumber;

                this.Text = "Изменение физ.лица";
                button1.Text = "Сохранить изменения";
            }
            else
            {
                this.person = new Person();
            }
        }

        private async void LoadData()
        {
            var data = await Post.GetPosts();
            comboBoxPost.DataSource = new ObservableCollection<Post>(data).ToBindingList();
            if (!string.IsNullOrEmpty(Post.GetException()))
                MessageBox.Show(Post.GetException());
            else
            {
                if (person.Post != null)
                    comboBoxPost.SelectedItem = comboBoxPost.Items.Cast<Post>().First(p => p.Id == person.Post.Id);
            }
        }

        private void buttonAddPerson_Click(object sender, EventArgs e)
        {
            person.LastName = textBoxLastName.Text;
            person.Name = textBoxName.Text;
            person.MiddleName = textBoxMiddleName.Text;
            person.DataBirth = ((DateTime?)dateTimePickerBirth.Value.Date) == ((DateTime?)DateTime.Now.Date) ? null : (DateTime?)dateTimePickerBirth.Value.Date;
            person.Email = textBoxEmail.Text;
            person.PhoneNumber = textBoxNumber.Text;
            person.Post = comboBoxPost.SelectedIndex >= 0 ? (Post)comboBoxPost.SelectedItem : null;
            Person.AddOrEditPerson(person);
        }
    }
}
