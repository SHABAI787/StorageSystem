using CommonData;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace ASPController_PC
{
    public partial class FormAddOrEditOrder : Form
    {
        Order order = null;
        public FormAddOrEditOrder(Order order = null)
        {
            InitializeComponent();
            LoadData();
            if (order != null)
            {
                this.order = order;
                textBoxQuantity.Text = Convert.ToString(order.Quantity);
                richTextBoxDescription.Text = order.Description;
                this.Text = @"Изменение заказа\брони";
                button.Text = "Сохранить изменения";
            }
            else
            {
                this.order = new Order();
            }
        }

        private async void LoadData()
        {
            comboBoxState.DataSource = new ObservableCollection<ProductState>(await ProductState.GetStates()).ToBindingList();
            comboBoxProduct.DataSource = new ObservableCollection<Product>(await Product.GetProducts()).ToBindingList();
            comboBoxPerson.DataSource = new ObservableCollection<Person>(await Person.GetPersons()).ToBindingList();

            if (order.State != null)
                comboBoxState.SelectedItem = comboBoxState.Items.Cast<ProductState>().First(p => p.Id == order.State.Id);
            if (order.Product != null)
                comboBoxProduct.SelectedItem = comboBoxProduct.Items.Cast<Product>().First(p => p.Id == order.Product.Id);
            if (order.Person != null)
                comboBoxPerson.SelectedItem = comboBoxPerson.Items.Cast<Person>().First(p => p.Id == order.Person.Id);

        }

        private void buttonAddOrEdit_Click(object sender, EventArgs e)
        {
            int quantity = 0;
            if (!int.TryParse(textBoxQuantity.Text, out quantity))
            {
                MessageBox.Show("Количество задано не корректно");
                return;
            }

            order.Description = richTextBoxDescription.Text;
            order.Quantity = quantity;
            order.State = comboBoxState.SelectedIndex >= 0 ? (ProductState)comboBoxState.SelectedItem : null;
            order.Product = comboBoxProduct.SelectedIndex >= 0 ? (Product)comboBoxProduct.SelectedItem : null;
            order.Person = comboBoxPerson.SelectedIndex >= 0 ? (Person)comboBoxPerson.SelectedItem : null;
            Order.AddOrEdit(order);
        }
    }
}
