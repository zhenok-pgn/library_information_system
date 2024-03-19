using Library.Domain;
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
    public partial class AddReadingRoomForm : Form
    {
        public AddReadingRoomForm(ReadingRoom room = null)
        {
            InitializeComponent();
            PrepairForm(room);
        }

        ReadingRoom room;

        private void PrepairForm(ReadingRoom room)
        {
            if (room == null)
            {
                button1.Click += AddRoomButton_Click;
            }
            else
            {
                this.room = room;

                textBox1.Text = room.Name;
                button1.Click += UpdateRoomButton_Click;
            }
        }

        private void AddRoomButton_Click(object sender, EventArgs e)
        {
            var room = new ReadingRoom
            {
                Name = textBox1.Text
            };

            try
            {
                ReadingRoomRepository.Insert(room);
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

        private void UpdateRoomButton_Click(object sender, EventArgs e)
        {
            room.Name = textBox1.Text;

            try
            {
                ReadingRoomRepository.Update(room);
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
