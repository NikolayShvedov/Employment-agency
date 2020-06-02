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
    public partial class JobApplicantSelectionForm : Form
    {
        private WorkWithDataOfApplicants workWithDataOfApplicants = new WorkWithDataOfApplicants();
        private WorkWithJobData workWithJobData = new WorkWithJobData();
        private Point MouseHook;
        private int id_Vacancy;
        private int id_Applicant = 0;
        private int Id_Employer;

        public JobApplicantSelectionForm(int id_Vacancy, int Id_Employer)
        {
            InitializeComponent();
            this.id_Vacancy = id_Vacancy;
            this.Id_Employer = Id_Employer;
            workWithJobData.DisplayJobApplicants(id_Vacancy, dataGridView1);
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

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormPublishingVacancies formPublishingVacancies = new FormPublishingVacancies(Id_Employer);
            formPublishingVacancies.Show();
        }

        private void buttonDeleteApplicant_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите удалить данного соискателя из списка?", "Сообщение", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
            {
                workWithJobData.deleteApplicants(id_Applicant, id_Vacancy);
                workWithJobData.DisplayJobApplicants(id_Vacancy, dataGridView1);
            }
        }

        private void buttonChoice_Click(object sender, EventArgs e)
        {
            if (id_Applicant != 0)
            {
                if (MessageBox.Show("Вы уверены, что хотите нанять данного соискателя?", "Сообщение", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                {
                    workWithJobData.selectionApplicantForThisVacancy(id_Applicant, id_Vacancy);
                    workWithJobData.deleteAClosedVacancy(id_Vacancy);
                    string message = "Поздравляем, вы нашли необходимого соискателя!" + "\n" + "Данная вакансия считается закрытой и удаляется из списка!";
                    MessageBox.Show(message);
                    this.Hide();
                    FormPublishingVacancies formPublishingVacancies = new FormPublishingVacancies(Id_Employer);
                    formPublishingVacancies.Show();

                }
                else
                {
                    workWithJobData.DisplayJobApplicants(id_Vacancy, dataGridView1);
                }
            }
            else
            {
                MessageBox.Show("Соискатель не выбран!");
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string email = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            if (email != "")
            {
                int id_Applicant = workWithDataOfApplicants.findId(email);
                this.id_Applicant = id_Applicant;
            }
            else
            {
                MessageBox.Show("Соискатель не выбран!");
            }
        }

        private void excelExportButton_Click(object sender, EventArgs e)
        {
            workWithJobData.ExportExcel(dataGridView1);
        }

        private void wordExportButton_Click(object sender, EventArgs e)
        {
            workWithJobData.ExportWord(dataGridView1);
        }
    }
}
