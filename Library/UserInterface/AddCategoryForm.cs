using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Library.UserInterface
{
    public partial class AddCategoryForm : Form
    {
        ComboBox box;

        public AddCategoryForm(ComboBox box)
        {
            InitializeComponent();
            this.box = box;
        }

        private void Addbutton_Click(object sender, EventArgs e)
        {
            try
            { 
                box.Items.Add(textBox1.Text);
                const string message =
                    "Данные успешно добавлены";
                const string caption = "Успех";
                var result = MessageBox.Show(message, caption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Information);
                Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
}
    }
}
