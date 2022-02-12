﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Net;
using System.IO;
using CommonData;

namespace ASPController_PC
{
    public partial class FormAuthorization : Form
    {
        public FormAuthorization()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if(await CommonData.Authorization.StartAuthorization(textBoxLogin.Text, textBoxPassword.Text))
            {
                new FormBase().Show();
                this.Hide();
            }
            else
                MessageBox.Show(CommonData.Authorization.Exception, "Авторизация", MessageBoxButtons.OK, MessageBoxIcon.Information);
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