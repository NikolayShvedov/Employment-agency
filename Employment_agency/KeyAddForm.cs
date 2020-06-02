using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Employment_agency
{
    public partial class KeyAddForm : Form
    {
        private Point MouseHook;
        private WorkWithAdminData workWithAdminData = new WorkWithAdminData();

        public KeyAddForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void сollapseButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonAddKey_Click(object sender, EventArgs e)
        {
            if (textKey.Text == "" || textCompany.Text == "")
            {
                MessageBox.Show("Заполните поля!");
            }
            else
            {
                bool result = workWithAdminData.registrationKey(textKey.Text, textCompany.Text);
                if (result == true)
                {
                    MessageBox.Show("Ключ для компании " + textCompany.Text + " добавлен!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Ошибка! Повторение данных!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }  
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) MouseHook = e.Location;
            Location = new Point((Size)Location - (Size)MouseHook + (Size)e.Location);
        }
    }
}
