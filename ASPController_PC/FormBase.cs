﻿using CommonData;
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
    }
}