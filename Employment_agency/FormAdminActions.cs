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
    public partial class FormAdminActions : Form
    {
        private Point MouseHook;
        private WorkWithAdminData workWithAdminData = new WorkWithAdminData();
        private string role;

        public FormAdminActions()
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

        private void buttonDisplayApplicants_Click(object sender, EventArgs e)
        {
            if (textEmail.Text == "")
            {
                workWithAdminData.displayApplicantsData(dataGridView2);
            }
            else
            {
                workWithAdminData.displayApplicantsDataOnEmail(textEmail.Text, dataGridView2);
            }
            role = "Aspirant";
        }

        private void buttonDisplayEmployer_Click(object sender, EventArgs e)
        {
            if (textEmail.Text == "")
            {
                workWithAdminData.displayEmployerData(dataGridView2);
            }
            else
            {
                workWithAdminData.displayEmployerDataOnEmail(textEmail.Text, dataGridView2);
            }
            role = "Employer";
        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = int.Parse(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
            if (role == "Aspirant")
            {
                if (MessageBox.Show("Удалить эту запись из базы данных?", "Сообщение", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                {
                    workWithAdminData.deleteSummaryApplicant(id);
                    workWithAdminData.deleteApplicantAccount(id);
                    workWithAdminData.deleteApplicant(id);
                    workWithAdminData.displayApplicantsData(dataGridView2);
                    textEmail.Text = "";
                } 
            }
            else if (role == "Employer")
            {
                if (MessageBox.Show("Удалить эту запись из базы данных?", "Сообщение", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                {
                    workWithAdminData.deleteSummaryEmployer(id);
                    workWithAdminData.deleteVacancy(id);
                    int id_key = workWithAdminData.findIdKey(id);
                    workWithAdminData.deleteEmployerAccount(id);
                    workWithAdminData.deleteEmployerKey(id_key);
;                   workWithAdminData.displayEmployerData(dataGridView2);
                    textEmail.Text = "";
                }
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm("admin");
            loginForm.Show();
        }

        private void addKeyButton_MouseEnter(object sender, EventArgs e)
        {
            addKeyButton.Font = new Font(addKeyButton.Font, FontStyle.Underline);
        }

        private void addKeyButton_MouseLeave(object sender, EventArgs e)
        {
            addKeyButton.Font = new Font(addKeyButton.Font, FontStyle.Regular);
        }

        private void addKeyButton_MouseClick(object sender, MouseEventArgs e)
        {
            KeyAddForm keyAddForm = new KeyAddForm();
            keyAddForm.ShowDialog();
        }
    }
}
