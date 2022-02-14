
namespace ASPController_PC
{
    partial class FormAddOrEditProvider
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.button = new System.Windows.Forms.Button();
            this.comboBoxPerson = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(21, 19);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(453, 26);
            this.textBoxName.TabIndex = 5;
            this.textBoxName.Text = "Наименование";
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button.Location = new System.Drawing.Point(21, 97);
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
            this.comboBoxPerson.Location = new System.Drawing.Point(21, 51);
            this.comboBoxPerson.Name = "comboBoxPerson";
            this.comboBoxPerson.Size = new System.Drawing.Size(453, 27);
            this.comboBoxPerson.TabIndex = 9;
            this.comboBoxPerson.Text = "Представитель";
            // 
            // FormAddOrEditProvider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(504, 172);
            this.Controls.Add(this.comboBoxPerson);
            this.Controls.Add(this.button);
            this.Controls.Add(this.textBoxName);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormAddOrEditProvider";
            this.Text = "Добавление поставщика";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.ComboBox comboBoxPerson;
    }
}