using CommonData;
using System;
using System.Windows.Forms;

namespace ASPController_PC
{
    public partial class FormAddOrEditProductState : Form
    {
        ProductState state = null;
        public FormAddOrEditProductState(ProductState state = null)
        {
            InitializeComponent();
            if (state != null)
            {
                this.state = state;
                textBoxName.Text = state.Name;
                richTextBoxDescription.Text = state.Description;
                this.Text = @"Изменение состояния";
                button.Text = "Сохранить изменения";
            }
            else
            {
                this.state = new ProductState();
            }
        }

        private void buttonAddOrEdit_Click(object sender, EventArgs e)
        {
            state.Name = textBoxName.Text;
            state.Description = richTextBoxDescription.Text;
            ProductState.AddOrEdit(state);
        }
    }
}
