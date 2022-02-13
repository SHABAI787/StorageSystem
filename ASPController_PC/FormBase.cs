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
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }

        private async void toolStripButtonAddProduct_Click_1(object sender, EventArgs e)
        {
            
        }

        private async void toolStripButtonUpdateProduct_Click(object sender, EventArgs e)
        {
            var products = await Product.GetProducts();
            dataGridViewProducts.DataSource = new ObservableCollection<Product>(products).ToBindingList();
            if(!string.IsNullOrEmpty(Product.GetException()))
                MessageBox.Show(Product.GetException());
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tabControl = sender as TabControl;
            switch (tabControl.SelectedTab.Name)
            {
                case "tabPageOrders":  break;
                case "tabPagePersons":  break;
                case "tabPagePosts":  break;
                case "tabPageProducts":  break;
                case "tabPageProviders":  break;
                case "tabPageStores":  break;
                case "tabPageUsersBD":  break;
                default:
                    break;
            }
        }

        private void FormBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            toolStripButtonUpdateProduct_Click(sender, e);
            toolStripButtonUpdateOrder_Click(sender, e);
            toolStripButtonUpdatePerson_Click(sender, e);
            toolStripButtonUpdatePost_Click(sender, e);
            toolStripButtonUpdateProvider_Click(sender, e);
            toolStripButtonUpdateStore_Click(sender, e);
            toolStripButtonUpdateUsersBD_Click(sender, e);
        }

        private async void toolStripButtonUpdateOrder_Click(object sender, EventArgs e)
        {
            var data = await Order.GetOrders();
            dataGridViewOrders.DataSource = new ObservableCollection<Order>(data).ToBindingList();
            if (!string.IsNullOrEmpty(Order.GetException()))
                MessageBox.Show(Order.GetException());
        }

        private async void toolStripButtonUpdatePerson_Click(object sender, EventArgs e)
        {
            var data = await Person.GetPersons();
            dataGridViewPersons.DataSource = new ObservableCollection<Person>(data).ToBindingList();
            if (!string.IsNullOrEmpty(Person.GetException()))
                MessageBox.Show(Person.GetException());
        }

        private async void toolStripButtonUpdatePost_Click(object sender, EventArgs e)
        {
            var data = await Post.GetPosts();
            dataGridViewPosts.DataSource = new ObservableCollection<Post>(data).ToBindingList();
            if (!string.IsNullOrEmpty(Post.GetException()))
                MessageBox.Show(Post.GetException());
        }

        private async void toolStripButtonUpdateProvider_Click(object sender, EventArgs e)
        {
            var data = await Provider.GetProviders();
            dataGridViewProviders.DataSource = new ObservableCollection<Provider>(data).ToBindingList();
            if (!string.IsNullOrEmpty(Provider.GetException()))
                MessageBox.Show(Provider.GetException());
        }

        private async void toolStripButtonUpdateStore_Click(object sender, EventArgs e)
        {
            var data = await Store.GetStores();
            dataGridViewStores.DataSource = new ObservableCollection<Store>(data).ToBindingList();
            if (!string.IsNullOrEmpty(Store.GetException()))
                MessageBox.Show(Store.GetException());
        }

        private async void toolStripButtonUpdateUsersBD_Click(object sender, EventArgs e)
        {
            var data = await UserBD.GetusersBD();
            dataGridViewUsersBD.DataSource = new ObservableCollection<UserBD>(data).ToBindingList();
            if (!string.IsNullOrEmpty(UserBD.GetException()))
                MessageBox.Show(UserBD.GetException());
        }

        private void DeleteItem<T>(DataGridView dataGridView, EventHandler eventHandler) where T: BaseDelete
        {
            if (dataGridView.SelectedRows.Count > 0)
            {
                List<T> delItems = new List<T>();
                foreach (DataGridViewRow item in dataGridView.SelectedRows)
                {
                    delItems.Add((T)item.DataBoundItem);
                }
                var first = delItems.First();
                first.Delete(delItems, eventHandler);

                if (!string.IsNullOrEmpty(first.GetDelException()))
                    MessageBox.Show(first.GetDelException());
            }
            else
                MessageBox.Show("Выберите элементы для удаления");
        }

        private void toolStripButtonDeleteOrder_Click(object sender, EventArgs e)
        {
            DeleteItem<Order>(dataGridViewOrders, toolStripButtonUpdateOrder_Click);
        }

        private void toolStripButtonDelPerson_Click(object sender, EventArgs e)
        {
            DeleteItem<Person>(dataGridViewPersons, toolStripButtonUpdatePerson_Click);
        }

        private void toolStripButtonDelPost_Click(object sender, EventArgs e)
        {
            DeleteItem<Post>(dataGridViewPosts, toolStripButtonUpdatePost_Click);
        }

        private void toolStripButtonDeleteProduct_Click(object sender, EventArgs e)
        {
            DeleteItem<Product>(dataGridViewProducts, toolStripButtonUpdateProduct_Click);
        }

        private void toolStripButtonDelProvider_Click(object sender, EventArgs e)
        {
            DeleteItem<Provider>(dataGridViewProviders, toolStripButtonUpdateProvider_Click);
        }

        private void toolStripButtonDelStore_Click(object sender, EventArgs e)
        {
            DeleteItem<Store>(dataGridViewStores, toolStripButtonUpdateStore_Click);
        }

        private void toolStripButtonDelUsersBD_Click(object sender, EventArgs e)
        {
            DeleteItem<UserBD>(dataGridViewUsersBD, toolStripButtonUpdateUsersBD_Click);
        }
    }
}
