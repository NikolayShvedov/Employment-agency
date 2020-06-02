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
    public partial class RegisterEmployerForm : Form
    {
        private Point MouseHook;
        private WorkWithJobData workWithJobData = new WorkWithJobData();

        public RegisterEmployerForm()
        {
            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void сollapseButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) MouseHook = e.Location;
            Location = new Point((Size)Location - (Size)MouseHook + (Size)e.Location);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm("employer");
            loginForm.Show();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            string email = loginTextBox.Text;
            string password = passwordTextBox.Text;
            string doublepassword = doublepasswordTextBox.Text;
            string company = companyTextBox.Text;
            string key = textAccessKey.Text;

            if ((email == "") || (password == "") || (doublepassword == "") || (company == "") || (key == ""))
            {
                MessageBox.Show("Вы ввели не все данные!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (password != doublepassword)
            {
                MessageBox.Show("Вы не правильно повторили пароль!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (workWithJobData.isEmployerExists(email) == true)
            {
                MessageBox.Show("Такой email уже есть, введите другой", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (workWithJobData.isEmployerKey(key, company) == false)
            {
                MessageBox.Show("Неверный инициализирующий ключ или название компании!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int id_key = workWithJobData.findIdKey(key);

                if (workWithJobData.employerRegistration(email, password, id_key) == true)
                {
                    MessageBox.Show("Аккаунт для  компании '" + company + "' создан!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    LoginForm loginForm = new LoginForm("employer");
                    loginForm.Show();
                }
                else
                {
                    MessageBox.Show("Аккаунт не создан!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
