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
    public partial class FormSearch : Form
    {
        private List<Product> products;
        private List<Order> orders;
        private DataGridView dataGridView = null;
        private Table table;
        public FormSearch(DataGridView dataGridView, Table table)
        {
            InitializeComponent();
            LoadData();
            this.dataGridView = dataGridView;
            this.table = table;
        }

        public async void LoadData()
        {
            products = await Product.GetProducts();
            orders = await Order.GetOrders();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (table)
            {
                case Table.Product:
                    {
                        dataGridView.DataSource = new ObservableCollection<Product>(products.Where(p => p.Name.ToUpper().Contains(textBoxText.Text.ToUpper()))).ToBindingList();
                    }
                    break;
                case Table.Order:
                    {
                        dataGridView.DataSource = new ObservableCollection<Order>(orders.Where(p => p.Person.ToString().ToUpper().Contains(textBoxText.Text.ToUpper()))).ToBindingList();
                    }
                    break;
            }
        }
    }

    public enum Table
    {
        Product,
        Order
    }

}
