using CommonData;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace ASPController_PC
{
    public partial class FormAddOrEditPost : Form
    {
        Post post = null;
        public FormAddOrEditPost(Post post = null)
        {
            InitializeComponent();
            if (post != null)
            {
                this.post = post;
                textBoxName.Text = post.Name;
                richTextBoxDescription.Text = post.Description;
                this.Text = @"Изменение должности";
                button.Text = "Сохранить изменения";
            }
            else
            {
                this.post = new Post();
            }
        }

        private void buttonAddOrEdit_Click(object sender, EventArgs e)
        {
            post.Name = textBoxName.Text;
            post.Description = richTextBoxDescription.Text;
            Post.AddOrEdit(post);
        }
    }
}
