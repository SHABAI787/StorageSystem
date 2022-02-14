using CommonData;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace ASPController_PC
{
    public partial class FormAddOrEditProvider : Form
    {
        Provider provider = null;
        public FormAddOrEditProvider(Provider provider = null)
        {
            InitializeComponent();
            LoadData();
            if (provider != null)
            {
                this.provider = provider;
                textBoxName.Text = provider.Name;
                this.Text = @"Изменение поставщика";
                button.Text = "Сохранить изменения";
            }
            else
            {
                this.provider = new Provider();
            }
        }

        private async void LoadData()
        {
            comboBoxPerson.DataSource = new ObservableCollection<Person>(await Person.GetPersons()).ToBindingList();

            if (provider.Responsible != null)
                comboBoxPerson.SelectedItem = comboBoxPerson.Items.Cast<Person>().First(p => p.Id == provider.Responsible.Id);
        }

        private void buttonAddOrEdit_Click(object sender, EventArgs e)
        {
            provider.Name = textBoxName.Text;
            provider.Responsible = comboBoxPerson.SelectedIndex >= 0 ? (Person)comboBoxPerson.SelectedItem : null;
            Provider.AddOrEdit(provider);
        }
    }
}
