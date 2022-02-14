
namespace ASPController_PC
{
    partial class FormAddOrEditOrder
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
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.comboBoxState = new System.Windows.Forms.ComboBox();
            this.button = new System.Windows.Forms.Button();
            this.comboBoxPerson = new System.Windows.Forms.ComboBox();
            this.richTextBoxDescription = new System.Windows.Forms.RichTextBox();
            this.comboBoxProduct = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(21, 45);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(453, 26);
            this.textBoxQuantity.TabIndex = 5;
            this.textBoxQuantity.Text = "Количество";
            // 
            // comboBoxState
            // 
            this.comboBoxState.FormattingEnabled = true;
            this.comboBoxState.Location = new System.Drawing.Point(21, 110);
            this.comboBoxState.Name = "comboBoxState";
            this.comboBoxState.Size = new System.Drawing.Size(453, 27);
            this.comboBoxState.TabIndex = 4;
            this.comboBoxState.Text = "Состояние";
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button.Location = new System.Drawing.Point(21, 253);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(453, 56);
            this.button.TabIndex = 7;
            this.button.Text = "Добавить";
            this.button.UseVisualStyleBackColor = false;
            this.button.Click += new System.EventHandler(this.buttonAddOrEdit_Click);
            // 
            // comboBoxPerson
            // 
            this.comboBoxPerson.FormattingEnabled = true;
            this.comboBoxPerson.Location = new System.Drawing.Point(21, 77);
            this.comboBoxPerson.Name = "comboBoxPerson";
            this.comboBoxPerson.Size = new System.Drawing.Size(453, 27);
            this.comboBoxPerson.TabIndex = 9;
            this.comboBoxPerson.Text = "Физ.лицо";
            // 
            // richTextBoxDescription
            // 
            this.richTextBoxDescription.Location = new System.Drawing.Point(21, 143);
            this.richTextBoxDescription.Name = "richTextBoxDescription";
            this.richTextBoxDescription.Size = new System.Drawing.Size(453, 96);
            this.richTextBoxDescription.TabIndex = 8;
            this.richTextBoxDescription.Text = "Описание";
            // 
            // comboBoxProduct
            // 
            this.comboBoxProduct.FormattingEnabled = true;
            this.comboBoxProduct.Location = new System.Drawing.Point(21, 12);
            this.comboBoxProduct.Name = "comboBoxProduct";
            this.comboBoxProduct.Size = new System.Drawing.Size(453, 27);
            this.comboBoxProduct.TabIndex = 10;
            this.comboBoxProduct.Text = "Продукт";
            // 
            // FormAddOrEditOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(504, 321);
            this.Controls.Add(this.comboBoxProduct);
            this.Controls.Add(this.comboBoxPerson);
            this.Controls.Add(this.richTextBoxDescription);
            this.Controls.Add(this.button);
            this.Controls.Add(this.comboBoxState);
            this.Controls.Add(this.textBoxQuantity);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormAddOrEditOrder";
            this.Text = "Добавление заказа\\брони";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.ComboBox comboBoxState;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.ComboBox comboBoxPerson;
        private System.Windows.Forms.RichTextBox richTextBoxDescription;
        private System.Windows.Forms.ComboBox comboBoxProduct;
    }
}