
namespace ASPController_PC
{
    partial class FormBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageOrders = new System.Windows.Forms.TabPage();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDeleteOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUpdateOrder = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSearchOrder = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.tabPagePersons = new System.Windows.Forms.TabPage();
            this.tabPagePosts = new System.Windows.Forms.TabPage();
            this.tabPageProducts = new System.Windows.Forms.TabPage();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddProduct = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDeleteProduct = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUpdateProduct = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSearchProduct = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.tabPageProviders = new System.Windows.Forms.TabPage();
            this.tabPageStores = new System.Windows.Forms.TabPage();
            this.tabPageUsersBD = new System.Windows.Forms.TabPage();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddPerson = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonDelPerson = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonUpdatePerson = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSearchPerson = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewPersons = new System.Windows.Forms.DataGridView();
            this.tabControl1.SuspendLayout();
            this.tabPageOrders.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            this.tabPagePersons.SuspendLayout();
            this.tabPageProducts.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersons)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageOrders);
            this.tabControl1.Controls.Add(this.tabPagePersons);
            this.tabControl1.Controls.Add(this.tabPagePosts);
            this.tabControl1.Controls.Add(this.tabPageProducts);
            this.tabControl1.Controls.Add(this.tabPageProviders);
            this.tabControl1.Controls.Add(this.tabPageStores);
            this.tabControl1.Controls.Add(this.tabPageUsersBD);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(800, 450);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPageOrders
            // 
            this.tabPageOrders.Controls.Add(this.toolStrip1);
            this.tabPageOrders.Controls.Add(this.dataGridViewOrders);
            this.tabPageOrders.Location = new System.Drawing.Point(4, 22);
            this.tabPageOrders.Name = "tabPageOrders";
            this.tabPageOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOrders.Size = new System.Drawing.Size(792, 424);
            this.tabPageOrders.TabIndex = 0;
            this.tabPageOrders.Text = "Заказы\\Брони";
            this.tabPageOrders.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddOrder,
            this.toolStripButtonDeleteOrder,
            this.toolStripButtonUpdateOrder,
            this.toolStripButtonSearchOrder});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(786, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAddOrder
            // 
            this.toolStripButtonAddOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddOrder.Image = global::ASPController_PC.Properties.Resources.icons8_add_23;
            this.toolStripButtonAddOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddOrder.Name = "toolStripButtonAddOrder";
            this.toolStripButtonAddOrder.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAddOrder.Text = "toolStripButton1";
            // 
            // toolStripButtonDeleteOrder
            // 
            this.toolStripButtonDeleteOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteOrder.Image = global::ASPController_PC.Properties.Resources.icons8_close_window_23;
            this.toolStripButtonDeleteOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteOrder.Name = "toolStripButtonDeleteOrder";
            this.toolStripButtonDeleteOrder.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDeleteOrder.Text = "toolStripButton2";
            // 
            // toolStripButtonUpdateOrder
            // 
            this.toolStripButtonUpdateOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUpdateOrder.Image = global::ASPController_PC.Properties.Resources.icons8_update_23;
            this.toolStripButtonUpdateOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUpdateOrder.Name = "toolStripButtonUpdateOrder";
            this.toolStripButtonUpdateOrder.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUpdateOrder.Text = "toolStripButton3";
            this.toolStripButtonUpdateOrder.Click += new System.EventHandler(this.toolStripButtonUpdateOrder_Click);
            // 
            // toolStripButtonSearchOrder
            // 
            this.toolStripButtonSearchOrder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSearchOrder.Image = global::ASPController_PC.Properties.Resources.icons8_search_more_25;
            this.toolStripButtonSearchOrder.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearchOrder.Name = "toolStripButtonSearchOrder";
            this.toolStripButtonSearchOrder.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSearchOrder.Text = "toolStripButton4";
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.AllowUserToAddRows = false;
            this.dataGridViewOrders.AllowUserToDeleteRows = false;
            this.dataGridViewOrders.AllowUserToOrderColumns = true;
            this.dataGridViewOrders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewOrders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewOrders.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Location = new System.Drawing.Point(0, 31);
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrders.ShowEditingIcon = false;
            this.dataGridViewOrders.Size = new System.Drawing.Size(792, 393);
            this.dataGridViewOrders.TabIndex = 1;
            // 
            // tabPagePersons
            // 
            this.tabPagePersons.Controls.Add(this.toolStrip3);
            this.tabPagePersons.Controls.Add(this.dataGridViewPersons);
            this.tabPagePersons.Location = new System.Drawing.Point(4, 22);
            this.tabPagePersons.Name = "tabPagePersons";
            this.tabPagePersons.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePersons.Size = new System.Drawing.Size(792, 424);
            this.tabPagePersons.TabIndex = 1;
            this.tabPagePersons.Text = "Физ.лица";
            this.tabPagePersons.UseVisualStyleBackColor = true;
            // 
            // tabPagePosts
            // 
            this.tabPagePosts.Location = new System.Drawing.Point(4, 22);
            this.tabPagePosts.Name = "tabPagePosts";
            this.tabPagePosts.Size = new System.Drawing.Size(792, 424);
            this.tabPagePosts.TabIndex = 2;
            this.tabPagePosts.Text = "Должности";
            this.tabPagePosts.UseVisualStyleBackColor = true;
            // 
            // tabPageProducts
            // 
            this.tabPageProducts.Controls.Add(this.toolStrip2);
            this.tabPageProducts.Controls.Add(this.dataGridViewProducts);
            this.tabPageProducts.Location = new System.Drawing.Point(4, 22);
            this.tabPageProducts.Name = "tabPageProducts";
            this.tabPageProducts.Size = new System.Drawing.Size(792, 424);
            this.tabPageProducts.TabIndex = 3;
            this.tabPageProducts.Text = "Товары";
            this.tabPageProducts.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip2.AutoSize = false;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddProduct,
            this.toolStripButtonDeleteProduct,
            this.toolStripButtonUpdateProduct,
            this.toolStripButtonSearchProduct});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(792, 25);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButtonAddProduct
            // 
            this.toolStripButtonAddProduct.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddProduct.Image = global::ASPController_PC.Properties.Resources.icons8_add_23;
            this.toolStripButtonAddProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddProduct.Name = "toolStripButtonAddProduct";
            this.toolStripButtonAddProduct.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAddProduct.Text = "toolStripButton1";
            this.toolStripButtonAddProduct.Click += new System.EventHandler(this.toolStripButtonAddProduct_Click_1);
            // 
            // toolStripButtonDeleteProduct
            // 
            this.toolStripButtonDeleteProduct.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDeleteProduct.Image = global::ASPController_PC.Properties.Resources.icons8_close_window_23;
            this.toolStripButtonDeleteProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDeleteProduct.Name = "toolStripButtonDeleteProduct";
            this.toolStripButtonDeleteProduct.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDeleteProduct.Text = "toolStripButton2";
            // 
            // toolStripButtonUpdateProduct
            // 
            this.toolStripButtonUpdateProduct.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUpdateProduct.Image = global::ASPController_PC.Properties.Resources.icons8_update_23;
            this.toolStripButtonUpdateProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUpdateProduct.Name = "toolStripButtonUpdateProduct";
            this.toolStripButtonUpdateProduct.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUpdateProduct.Text = "toolStripButton3";
            this.toolStripButtonUpdateProduct.Click += new System.EventHandler(this.toolStripButtonUpdateProduct_Click);
            // 
            // toolStripButtonSearchProduct
            // 
            this.toolStripButtonSearchProduct.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSearchProduct.Image = global::ASPController_PC.Properties.Resources.icons8_search_more_25;
            this.toolStripButtonSearchProduct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearchProduct.Name = "toolStripButtonSearchProduct";
            this.toolStripButtonSearchProduct.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSearchProduct.Text = "toolStripButton4";
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AllowUserToAddRows = false;
            this.dataGridViewProducts.AllowUserToDeleteRows = false;
            this.dataGridViewProducts.AllowUserToOrderColumns = true;
            this.dataGridViewProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProducts.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Location = new System.Drawing.Point(0, 31);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProducts.ShowEditingIcon = false;
            this.dataGridViewProducts.Size = new System.Drawing.Size(792, 393);
            this.dataGridViewProducts.TabIndex = 4;
            // 
            // tabPageProviders
            // 
            this.tabPageProviders.Location = new System.Drawing.Point(4, 22);
            this.tabPageProviders.Name = "tabPageProviders";
            this.tabPageProviders.Size = new System.Drawing.Size(792, 424);
            this.tabPageProviders.TabIndex = 4;
            this.tabPageProviders.Text = "Поставщики";
            this.tabPageProviders.UseVisualStyleBackColor = true;
            // 
            // tabPageStores
            // 
            this.tabPageStores.Location = new System.Drawing.Point(4, 22);
            this.tabPageStores.Name = "tabPageStores";
            this.tabPageStores.Size = new System.Drawing.Size(792, 424);
            this.tabPageStores.TabIndex = 5;
            this.tabPageStores.Text = "Склады";
            this.tabPageStores.UseVisualStyleBackColor = true;
            // 
            // tabPageUsersBD
            // 
            this.tabPageUsersBD.Location = new System.Drawing.Point(4, 22);
            this.tabPageUsersBD.Name = "tabPageUsersBD";
            this.tabPageUsersBD.Size = new System.Drawing.Size(792, 424);
            this.tabPageUsersBD.TabIndex = 6;
            this.tabPageUsersBD.Text = "Пользователи";
            this.tabPageUsersBD.UseVisualStyleBackColor = true;
            // 
            // toolStrip3
            // 
            this.toolStrip3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolStrip3.AutoSize = false;
            this.toolStrip3.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddPerson,
            this.toolStripButtonDelPerson,
            this.toolStripButtonUpdatePerson,
            this.toolStripButtonSearchPerson});
            this.toolStrip3.Location = new System.Drawing.Point(3, 3);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(792, 25);
            this.toolStrip3.TabIndex = 7;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButtonAddPerson
            // 
            this.toolStripButtonAddPerson.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonAddPerson.Image = global::ASPController_PC.Properties.Resources.icons8_add_23;
            this.toolStripButtonAddPerson.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddPerson.Name = "toolStripButtonAddPerson";
            this.toolStripButtonAddPerson.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonAddPerson.Text = "toolStripButton1";
            // 
            // toolStripButtonDelPerson
            // 
            this.toolStripButtonDelPerson.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDelPerson.Image = global::ASPController_PC.Properties.Resources.icons8_close_window_23;
            this.toolStripButtonDelPerson.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelPerson.Name = "toolStripButtonDelPerson";
            this.toolStripButtonDelPerson.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDelPerson.Text = "toolStripButton2";
            // 
            // toolStripButtonUpdatePerson
            // 
            this.toolStripButtonUpdatePerson.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonUpdatePerson.Image = global::ASPController_PC.Properties.Resources.icons8_update_23;
            this.toolStripButtonUpdatePerson.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonUpdatePerson.Name = "toolStripButtonUpdatePerson";
            this.toolStripButtonUpdatePerson.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonUpdatePerson.Text = "toolStripButton3";
            this.toolStripButtonUpdatePerson.Click += new System.EventHandler(this.toolStripButtonUpdatePerson_Click);
            // 
            // toolStripButtonSearchPerson
            // 
            this.toolStripButtonSearchPerson.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSearchPerson.Image = global::ASPController_PC.Properties.Resources.icons8_search_more_25;
            this.toolStripButtonSearchPerson.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSearchPerson.Name = "toolStripButtonSearchPerson";
            this.toolStripButtonSearchPerson.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSearchPerson.Text = "toolStripButton4";
            // 
            // dataGridViewPersons
            // 
            this.dataGridViewPersons.AllowUserToAddRows = false;
            this.dataGridViewPersons.AllowUserToDeleteRows = false;
            this.dataGridViewPersons.AllowUserToOrderColumns = true;
            this.dataGridViewPersons.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPersons.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewPersons.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewPersons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPersons.Location = new System.Drawing.Point(0, 31);
            this.dataGridViewPersons.Name = "dataGridViewPersons";
            this.dataGridViewPersons.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPersons.ShowEditingIcon = false;
            this.dataGridViewPersons.Size = new System.Drawing.Size(792, 393);
            this.dataGridViewPersons.TabIndex = 6;
            // 
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormBase";
            this.Text = "Система хранения";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormBase_FormClosed);
            this.Load += new System.EventHandler(this.FormBase_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageOrders.ResumeLayout(false);
            this.tabPageOrders.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            this.tabPagePersons.ResumeLayout(false);
            this.tabPageProducts.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersons)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageOrders;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.TabPage tabPagePersons;
        private System.Windows.Forms.TabPage tabPagePosts;
        private System.Windows.Forms.TabPage tabPageProducts;
        private System.Windows.Forms.TabPage tabPageProviders;
        private System.Windows.Forms.TabPage tabPageStores;
        private System.Windows.Forms.TabPage tabPageUsersBD;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddOrder;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteOrder;
        private System.Windows.Forms.ToolStripButton toolStripButtonUpdateOrder;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearchOrder;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddProduct;
        private System.Windows.Forms.ToolStripButton toolStripButtonDeleteProduct;
        private System.Windows.Forms.ToolStripButton toolStripButtonUpdateProduct;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearchProduct;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddPerson;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelPerson;
        private System.Windows.Forms.ToolStripButton toolStripButtonUpdatePerson;
        private System.Windows.Forms.ToolStripButton toolStripButtonSearchPerson;
        private System.Windows.Forms.DataGridView dataGridViewPersons;
    }
}