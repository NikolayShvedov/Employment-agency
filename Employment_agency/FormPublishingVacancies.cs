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
    public partial class FormPublishingVacancies : Form
    {
        private int id_employer;
        private int id_vacancy = 0;
        private Point MouseHook;
        private WorkWithJobData workWithJobData = new WorkWithJobData();

        public FormPublishingVacancies(int id_employer)
        {
            InitializeComponent();
            this.id_employer = id_employer;
            string company = workWithJobData.findCompany(id_employer);
            label2.Text = "Аккаунт для публикации вакансиий (Компания " + company + ")";
            textBox1.Text = company;
            workWithJobData.DisplayVacancyData(id_employer, dataGridView1);
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

        public void CleanData()
        {
            textBox4.Text = ""; // Должность
            textBox5.Text = ""; // Оклад
            comboBox1.SelectedIndex = -1; // Образование
            radioButton1.Checked = false; // Опыт
            radioButton2.Checked = false; // работы
            comboBox2.SelectedIndex = -1; // График работы
            comboBox3.SelectedIndex = -1; // Социальный пакет
        }

        private void buttonAddVacancy_Click(object sender, EventArgs e)
        {
            string company_for_recording = textBox1.Text;
            string companyAddress = textBox2.Text;
            string profArea = textBox3.Text;
            string position = textBox4.Text;
            int salary = int.Parse(textBox5.Text);

            int education = 0, experience = 0, workSchedule = 0, socialpack = 0;

            if (comboBox1.Text.Equals("Высшее"))
            {
                education = 1;
            }
            else if (comboBox1.Text.Equals("Среднее"))
            {
                education = 2;
            }
            else if (comboBox1.Text.Equals("Среднее специальное"))
            {
                education = 3;
            }
            else if (comboBox1.Text.Equals("Не требуется"))
            {
                education = 4;
            }

            if (radioButton1.Checked)
            {
                experience = 1;
            }
            else if (radioButton2.Checked)
            {
                experience = 2;
            }

            if (comboBox2.Text.Equals("Ненормированный"))
            {
                workSchedule = 2;
            }
            else if (comboBox2.Text.Equals("Гибкий график"))
            {
                workSchedule = 3;
            }
            else if (comboBox2.Text.Equals("Сменный график"))
            {
                workSchedule = 4;
            }
            else if (comboBox2.Text.Equals("Удалённая работа"))
            {
                workSchedule = 5;
            }
            else if (comboBox2.Text.Equals("Посменно"))
            {
                workSchedule = 6;
            }
            else if (comboBox2.Text.Equals("Полный день"))
            {
                workSchedule = 7;
            }

            if (comboBox3.Text.Equals("Есть"))
            {
                socialpack = 1;
            }
            else if (comboBox3.Text.Equals("Нет"))
            {
                socialpack = 2;
            }

            int id_Work = workWithJobData.findPosition(position), id_ProfArea = workWithJobData.findProfessionalArea(profArea);

            if (id_Work == 0)
            {
                workWithJobData.addPosition(position);
                id_Work = workWithJobData.findPosition(position);
            }

            if (id_ProfArea == 0)
            {
                workWithJobData.addProfessionalArea(profArea);
                id_ProfArea = workWithJobData.findProfessionalArea(profArea);
            }

            workWithJobData.addVacancy(company_for_recording, companyAddress, salary, id_employer, workSchedule, id_Work, education, experience, id_ProfArea, socialpack);
            workWithJobData.DisplayVacancyData(id_employer, dataGridView1);
            CleanData();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            string company_for_recording = textBox1.Text;
            string companyAddress = textBox2.Text;
            string profArea = textBox3.Text;
            string position = textBox4.Text;
            int salary = int.Parse(textBox5.Text);
            int education = 0, experience = 0, workSchedule = 0, socialpack = 0;

            if (comboBox1.Text.Equals("Высшее"))
            {
                education = 1;
            }
            else if (comboBox1.Text.Equals("Среднее"))
            {
                education = 2;
            }
            else if (comboBox1.Text.Equals("Среднее специальное"))
            {
                education = 3;
            }
            else if (comboBox1.Text.Equals("Не требуется"))
            {
                education = 4;
            }

            if (radioButton1.Checked)
            {
                experience = 1;
            }
            else if (radioButton2.Checked)
            {
                experience = 2;
            }

            if (comboBox2.Text.Equals("Ненормированный"))
            {
                workSchedule = 2;
            }
            else if (comboBox2.Text.Equals("Гибкий график"))
            {
                workSchedule = 3;
            }
            else if (comboBox2.Text.Equals("Сменный график"))
            {
                workSchedule = 4;
            }
            else if (comboBox2.Text.Equals("Удалённая работа"))
            {
                workSchedule = 5;
            }
            else if (comboBox2.Text.Equals("Посменно"))
            {
                workSchedule = 6;
            }
            else if (comboBox2.Text.Equals("Полный день"))
            {
                workSchedule = 7;
            }

            if (comboBox3.Text.Equals("Есть"))
            {
                socialpack = 1;
            }
            else if (comboBox3.Text.Equals("Нет"))
            {
                socialpack = 2;
            }

            int id_Work = workWithJobData.findPosition(position), id_ProfArea = workWithJobData.findProfessionalArea(profArea);

            if (id_Work == 0)
            {
                workWithJobData.addPosition(position);
                id_Work = workWithJobData.findPosition(position);
            }

            if (id_ProfArea == 0)
            {
                workWithJobData.addProfessionalArea(profArea);
                id_ProfArea = workWithJobData.findProfessionalArea(profArea);
            }

            workWithJobData.changeVacancy(id_vacancy, company_for_recording, companyAddress, salary, id_employer, workSchedule, id_Work, education, experience, id_ProfArea, socialpack, dataGridView1);
            workWithJobData.DisplayVacancyData(id_employer, dataGridView1);
            CleanData();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (id_vacancy != 0)
            {
                workWithJobData.deleteVacancy(id_vacancy, dataGridView1);
                workWithJobData.DisplayVacancyData(id_employer, dataGridView1);
                CleanData();
            }
            else
            {
                MessageBox.Show("Удаление вакансии не возможно!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm("employer");
            loginForm.Show();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            id_vacancy = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()); //id вакансии
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); //Компания
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(); //Адрес компании
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(); //Профобласть
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(); //Должность
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString(); //Оклад
            string education, experience, workSchedule, socialpack;
            education = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(); //Образование
            experience = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString(); //Опыт работы
            workSchedule = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString(); //График работы
            socialpack = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString(); //Социальный пакет

            if (education == "Высшее")
            {
                comboBox1.Text = comboBox1.Items[0].ToString();
            }
            else if (education == "Среднее")
            {
                comboBox1.Text = comboBox1.Items[1].ToString();
            }
            else if (education == "Среднее специальное")
            {
                comboBox1.Text = comboBox1.Items[2].ToString();
            }
            else if (education == "Не требуется")
            {
                comboBox1.Text = comboBox1.Items[3].ToString();
            }

            if (experience == "Требуется")
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else if (experience == "Не требуется")
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }

            if (workSchedule == "Ненормированный")
            {
                comboBox2.Text = comboBox2.Items[0].ToString();
            }
            else if (workSchedule == "Гибкий график")
            {
                comboBox2.Text = comboBox2.Items[1].ToString();
            }
            else if (workSchedule == "Сменный график")
            {
                comboBox2.Text = comboBox2.Items[2].ToString();
            }
            else if (workSchedule == "Удалённая работа")
            {
                comboBox2.Text = comboBox2.Items[3].ToString();
            }
            else if (workSchedule == "Посменно")
            {
                comboBox2.Text = comboBox2.Items[4].ToString();
            }
            else if (workSchedule == "Полный день")
            {
                comboBox2.Text = comboBox2.Items[5].ToString();
            }

            if (socialpack == "Есть")
            {
                comboBox3.Text = comboBox3.Items[0].ToString();
            }
            else if (socialpack == "Нет")
            {
                comboBox3.Text = comboBox3.Items[1].ToString();
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void buttonChoice_Click(object sender, EventArgs e)
        {
            if (id_vacancy != 0)
            {
                if (MessageBox.Show("Открыть список соискателей по данной вакансии?", "Сообщение", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                {
                    this.Hide();
                    JobApplicantSelectionForm jobApplicantSelectionForm = new JobApplicantSelectionForm(id_vacancy, id_employer);
                    jobApplicantSelectionForm.Show();
                }               
            }
            else
            {
                MessageBox.Show("Вакансия не выбрана!", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
