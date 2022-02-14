using CommonData;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASPController_PC
{
    public partial class FormAddOrEditProduct: Form
    {
        Product product = null;
        public FormAddOrEditProduct(Product product = null)
        {
            InitializeComponent();
            LoadData();
            if (product != null)
            {
                this.product = product;
                textBoxName.Text = product.Name;
                richTextBoxDescription.Text = product.Description;
                textBoxPrice.Text = Convert.ToString(product.Price);
                this.Text = "Изменение товара";
                button.Text = "Сохранить изменения";
            }
            else
            {
                this.product = new Product();
            }
        }

        private async void LoadData()
        {
            comboBoxState.DataSource = new ObservableCollection<ProductState>(await ProductState.GetStates()).ToBindingList();
            comboBoxStore.DataSource = new ObservableCollection<Store>(await Store.GetStores()).ToBindingList();
            comboBoxProvider.DataSource = new ObservableCollection<Provider>(await Provider.GetProviders()).ToBindingList();
            if (!string.IsNullOrEmpty(Post.GetException()))
                MessageBox.Show(Post.GetException());
            else
            {
                if (product.State != null)
                    comboBoxState.SelectedItem = comboBoxState.Items.Cast<ProductState>().First(p => p.Id == product.State.Id);
                if (product.Provider != null)
                    comboBoxProvider.SelectedItem = comboBoxProvider.Items.Cast<Provider>().First(p => p.Id == product.Provider.Id);
                if (product.Store != null)
                    comboBoxStore.SelectedItem = comboBoxStore.Items.Cast<Store>().First(p => p.Id == product.Store.Id);
            }
        }

        private void buttonAddOrEdit_Click(object sender, EventArgs e)
        {
            decimal price = 0;
            if(!decimal.TryParse(textBoxPrice.Text, out price))
            {
                MessageBox.Show("Стоимость задана не корректно");
                return;
            }

            product.Name = textBoxName.Text;
            product.Description = richTextBoxDescription.Text;
            product.Price = price;
            product.State = comboBoxState.SelectedIndex >= 0 ? (ProductState)comboBoxState.SelectedItem : null;
            product.Store = comboBoxStore.SelectedIndex >= 0 ? (Store)comboBoxStore.SelectedItem : null;
            product.Provider = comboBoxProvider.SelectedIndex >= 0 ? (Provider)comboBoxProvider.SelectedItem : null;
            Product.AddOrEdit(product);
        }
    }
}
