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
    public partial class JobSearchWindow : Form
    {
        private WorkWithDataOfApplicants workWithDataOfApplicants = new WorkWithDataOfApplicants();
        private WorkWithJobData workWithJobData = new WorkWithJobData();
        private Point MouseHook;
        private int id_appl;

        public JobSearchWindow(int id_appl)
        {
            InitializeComponent();
            this.id_appl = id_appl;
            comboBox2.Enabled = false;
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

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ApplicantAccountForm applicantAccountForm = new ApplicantAccountForm(id_appl);
            applicantAccountForm.Show();
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.Font = new Font(label8.Font, FontStyle.Underline);
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.Font = new Font(label8.Font, FontStyle.Regular);
        }

        private void label8_MouseClick(object sender, MouseEventArgs e)
        {
            workWithDataOfApplicants.jobOpenings(id_appl, dataGridView2);
            workWithDataOfApplicants.lineFilling(id_appl, dataGridView2);
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            label9.Font = new Font(label9.Font, FontStyle.Underline);
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.Font = new Font(label9.Font, FontStyle.Regular);
        }

        private void label9_MouseClick(object sender, MouseEventArgs e)
        {
            workWithDataOfApplicants.displayVacancyData(id_appl, dataGridView2);
            workWithDataOfApplicants.lineFilling(id_appl, dataGridView2);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Enabled = true;
            if (comboBox1.Text.Equals("Образование"))
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Высшее");
                comboBox2.Items.Add("Среднее");
                comboBox2.Items.Add("Среднее специальное");
                comboBox2.Items.Add("Не требуется");
            }
            else if (comboBox1.Text.Equals("Опыт работы"))
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Требуется");
                comboBox2.Items.Add("Не требуется");
            }
            else if (comboBox1.Text.Equals("График работы"))
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Ненормированный");
                comboBox2.Items.Add("Гибкий график");
                comboBox2.Items.Add("Сменный график");
                comboBox2.Items.Add("Удалённая работа");
                comboBox2.Items.Add("Посменно");
                comboBox2.Items.Add("Полный день");
            }
            else if (comboBox1.Text.Equals("Соцпакет"))
            {
                comboBox2.Items.Clear();
                comboBox2.Items.Add("Есть");
                comboBox2.Items.Add("Нет");
            }
            else
            {
                comboBox2.Items.Clear();
                MessageBox.Show("Критерий не выбран!");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string profession = textBox1.Text;
            int initial_salary = 0, final_salary = 0;
            if (textBox2.Text != "" || textBox3.Text != "")
            {
                initial_salary = int.Parse(textBox2.Text);
                final_salary = int.Parse(textBox3.Text);
            }

            if (comboBox1.SelectedIndex == -1)
            {
                if (profession == "" && initial_salary == 0 && final_salary == 0)
                {
                    MessageBox.Show("Вы не указали ни одного значения для поиска!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    workWithDataOfApplicants.displayVacancyData(id_appl, dataGridView2);
                    workWithDataOfApplicants.lineFilling(id_appl, dataGridView2);
                }
                else
                {
                    workWithDataOfApplicants.showingAVacancyByProfession(profession, initial_salary, final_salary, dataGridView2);
                    workWithDataOfApplicants.lineFilling(id_appl, dataGridView2);
                }
            }
            else
            {
                if (comboBox2.SelectedIndex != -1)
                {
                    int id_Criterion = comboBox2.SelectedIndex;
                    if (comboBox1.Text.Equals("Образование"))
                    {
                        id_Criterion += 1;
                        workWithDataOfApplicants.educationJobShow(profession, initial_salary, final_salary, id_Criterion, dataGridView2);
                        workWithDataOfApplicants.lineFilling(id_appl, dataGridView2);
                    }
                    else if (comboBox1.Text.Equals("Опыт работы"))
                    {
                        id_Criterion += 1;
                        workWithDataOfApplicants.showingJobExperience(profession, initial_salary, final_salary, id_Criterion, dataGridView2);
                        workWithDataOfApplicants.lineFilling(id_appl, dataGridView2);
                    }
                    else if (comboBox1.Text.Equals("График работы"))
                    {
                        id_Criterion += 2;
                        workWithDataOfApplicants.showingAVacancyOnAWorkSchedule(profession, initial_salary, final_salary, id_Criterion, dataGridView2);
                        workWithDataOfApplicants.lineFilling(id_appl, dataGridView2);
                    }
                    else if (comboBox1.Text.Equals("Соцпакет"))
                    {
                        id_Criterion += 1;
                        workWithDataOfApplicants.socialPackVacancyShowing(profession, initial_salary, final_salary, id_Criterion, dataGridView2);
                        workWithDataOfApplicants.lineFilling(id_appl, dataGridView2);
                    }
                }
                else
                {
                    if (profession == "" && initial_salary == 0 && final_salary == 0)
                    {
                        MessageBox.Show("Вы не указали значение критерия для поиска вакансии!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        workWithDataOfApplicants.displayVacancyData(id_appl, dataGridView2);
                        workWithDataOfApplicants.lineFilling(id_appl, dataGridView2);
                    }
                    else
                    {
                        workWithDataOfApplicants.showingAVacancyByProfession(profession, initial_salary, final_salary, dataGridView2);
                        workWithDataOfApplicants.lineFilling(id_appl, dataGridView2);
                    }
                }
            }

        }

        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            bool result = workWithDataOfApplicants.jobMatchingCheck(id_appl, int.Parse(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString()));
            if (result == true)
            {
                if (MessageBox.Show("Удалить данную вакансию из выбранных вами?", "Сообщение", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                {
                    int id_Job = int.Parse(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                    workWithJobData.deleteApplicants(id_appl, id_Job);
                    workWithDataOfApplicants.displayVacancyData(id_appl, dataGridView2);
                    workWithDataOfApplicants.lineFilling(id_appl, dataGridView2);
                }
            }
            else if (result == false)
            {
                if (MessageBox.Show("Вы уверены, что хотите выбрать данную вакансию?", "Сообщение", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                {
                    int id_Job = int.Parse(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
                    string date_application = DateTime.Now.ToString("dd MMMM yyyy") + " г.";
                    workWithDataOfApplicants.newJobPosting(date_application, id_appl, id_Job);
                    workWithDataOfApplicants.displayVacancyData(id_appl, dataGridView2);
                    workWithDataOfApplicants.lineFilling(id_appl, dataGridView2);
                }
            }
        }
    }
}
