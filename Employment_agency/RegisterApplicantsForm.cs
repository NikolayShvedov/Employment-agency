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
    public partial class RegisterApplicantsForm : Form
    {
        private Point MouseHook;
        private WorkWithDataOfApplicants workWithDataOfApplicants = new WorkWithDataOfApplicants();

        public RegisterApplicantsForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void сollapseButton_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) MouseHook = e.Location;
            Location = new Point((Size)Location - (Size)MouseHook + (Size)e.Location);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm("aspirant");
            loginForm.Show();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string surname = textBox1.Text; // фамилия
            string name = textBox2.Text; // имя
            string middlename = textBox3.Text; // отчество
            string dateOfBirth = dateTimePicker1.Text; // дата рождения
            string phone = textBox4.Text; // номер телефона
            string address = textBox5.Text; // адрес
            int gender = 0, nation = 0; // пол и гражданство
            if (radioButton1.Checked)
            {
                gender = 1;
            }
            else if (radioButton2.Checked)
            {
                gender = 2;
            }

            if (comboBox1.Text.Equals("Русское"))
            {
                nation = 1;
            }
            else if (comboBox1.Text.Equals("Иностранное"))
            {
                nation = 2;
            }
            string email = textBox6.Text; // электронная почта
            string pass = textBox7.Text; // пароль
            string doublepass = textBox8.Text; // повтор пароля

            if ((surname == "") || (name == "") || (middlename == "") || (dateOfBirth == "") || (phone == "") || (address == "") || (gender == 0) || (nation == 0) || (email == "") || (pass == "") || (doublepass == ""))
            {
                MessageBox.Show("Вы ввели не все данные!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (pass != doublepass)
            {
                MessageBox.Show("Вы не правильно повторили пароль!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (workWithDataOfApplicants.isUserExists(email))
            {
                MessageBox.Show("Такой email уже есть, введите другой", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                workWithDataOfApplicants.addApplicants(surname, name, middlename, dateOfBirth, phone, email, address, gender, nation);
                int id_appl = workWithDataOfApplicants.findId(email);
                bool result = workWithDataOfApplicants.userRegistration(email, pass, id_appl);
                if (result == true)
                {
                    MessageBox.Show("Аккаунт для пользователя " + name + " " + surname + " создан!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    LoginForm loginForm = new LoginForm("aspirant");
                    loginForm.Show();
                }
                else
                {
                    MessageBox.Show("Аккаунт не создан!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }
    }
}
