using CommonData;
using System;
using System.Windows.Forms;

namespace ASPController_PC
{
    public partial class FormAddOrEditStore : Form
    {
        Store store = null;
        public FormAddOrEditStore(Store store = null)
        {
            InitializeComponent();
            if (store != null)
            {
                this.store = store;
                textBoxName.Text = store.Name;
                richTextBoxDescription.Text = store.Description;
                this.Text = @"Изменение склада";
                button.Text = "Сохранить изменения";
            }
            else
            {
                this.store = new Store();
            }
        }

        private void buttonAddOrEdit_Click(object sender, EventArgs e)
        {
            store.Name = textBoxName.Text;
            store.Description = richTextBoxDescription.Text;
            Store.AddOrEdit(store);
        }
    }
}
