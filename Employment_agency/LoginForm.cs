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
    public partial class LoginForm : Form
    {
        private Point MouseHook;
        private string role;

        public LoginForm(string role)
        {
            InitializeComponent();

            this.passField.AutoSize = false;
            this.passField.Size = new Size(this.passField.Size.Width, 41);

            loginField.Text = "Введите email";
            loginField.ForeColor = Color.Gray;

            passField.Text = "Введите пароль";
            passField.ForeColor = Color.Gray;

            this.role = role;

            if (role.Equals("admin"))
            {
                textAccessKey.Enabled = true;
                RegisterButton.Enabled = false;
            }
            else
            {
                textAccessKey.Enabled = false;
                RegisterButton.Enabled = true;
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void сollapseButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            InitialForm initialForm = new InitialForm();
            initialForm.Show();
        }

        private void loginField_Enter(object sender, EventArgs e)
        {
            if (loginField.Text == "Введите email")
            {
                loginField.Text = "";
                loginField.ForeColor = Color.Black;
            }
        }

        private void loginField_Leave(object sender, EventArgs e)
        {
            if (loginField.Text == "")
            {
                loginField.Text = "Введите email";
                loginField.ForeColor = Color.Gray;
            }
        }

        private void passField_Enter(object sender, EventArgs e)
        {
            if (passField.Text == "Введите пароль")
            {
                passField.Text = "";
                passField.ForeColor = Color.Black;
            }
        }

        private void passField_Leave(object sender, EventArgs e)
        {
            if (passField.Text == "")
            {
                passField.Text = "Введите пароль";
                passField.ForeColor = Color.Gray;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) MouseHook = e.Location;
            Location = new Point((Size)Location - (Size)MouseHook + (Size)e.Location);
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (role.Equals("aspirant"))
            {
                this.Hide();
                RegisterApplicantsForm registerApplicantsForm = new RegisterApplicantsForm();
                registerApplicantsForm.Show();
            }
            else if (role.Equals("employer"))
            {
                this.Hide();
                RegisterEmployerForm registerEmployerForm = new RegisterEmployerForm();
                registerEmployerForm.Show();
            }
            
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string loginUser = loginField.Text;
            string passUser = passField.Text;
            if ((loginUser == "Введите email") || (passUser == "Введите пароль"))
            {
                MessageBox.Show("Вы ввели не все данные!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                WorkWithDataOfApplicants workWithDataOfApplicants = new WorkWithDataOfApplicants();
                WorkWithJobData workWithJobData = new WorkWithJobData();
                bool result;
                if (role.Equals("admin"))
                {
                    result = workWithJobData.employerLogin(loginUser, passUser);
                    int id_key = workWithJobData.findIdKey(textAccessKey.Text);
                    if ((result == true) && (textAccessKey.Text == "JY4TJ-68L9H-8ZQE1"))
                    {
                        this.Hide();
                        FormAdminActions formAdminActions = new FormAdminActions();
                        formAdminActions.Show();
                    }
                    else
                    {
                        MessageBox.Show("Вход не выполнен!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (role.Equals("aspirant"))
                {
                    result = workWithDataOfApplicants.userLogin(loginUser, passUser);
                    if (result == true)
                    {
                        int id_appl = workWithDataOfApplicants.findId(loginUser);
                        this.Hide();
                        ApplicantAccountForm applicantAccountForm = new ApplicantAccountForm(id_appl);
                        applicantAccountForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Неизвестный пользователь!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (role.Equals("employer"))
                {
                    result = workWithJobData.employerLogin(loginUser, passUser);
                    if (result == true)
                    {
                        int Id_Employer = workWithJobData.findIdEmployer(loginUser);
                        this.Hide();
                        FormPublishingVacancies formPublishingVacancies = new FormPublishingVacancies(Id_Employer);
                        formPublishingVacancies.Show();
                    }
                    else
                    {
                        MessageBox.Show("Неизвестный пользователь!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }
    }
}
