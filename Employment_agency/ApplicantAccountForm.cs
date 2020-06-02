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
    public partial class ApplicantAccountForm : Form
    {
        private Point MouseHook;
        private WorkWithDataOfApplicants workWithDataOfApplicants = new WorkWithDataOfApplicants();
        private int id_appl;

        public ApplicantAccountForm(int id_appl)
        {
            InitializeComponent();
            this.id_appl = id_appl;
            string name = workWithDataOfApplicants.findName(id_appl);
            string surname = workWithDataOfApplicants.findSurname(id_appl);
            label2.Text = "Профиль пользователя: " + name + " " + surname;
            workWithDataOfApplicants.DisplayClientData(id_appl, dataGridView1);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void сollapseButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ApplicantAccountForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) MouseHook = e.Location;
            Location = new Point((Size)Location - (Size)MouseHook + (Size)e.Location);
        }

        public void CleanData()
        {
            textBox1.Text = ""; // фамилия
            textBox2.Text = ""; // имя
            textBox3.Text = ""; // отчество
            dateTimePicker1.Text = ""; // дата рождения
            textBox4.Text = ""; // телефон
            textBox5.Text = ""; // email
            textBox6.Text = ""; // адрес
            radioButton1.Checked = false; // пол (Мужской)
            radioButton2.Checked = false; // пол (Женский)
            comboBox1.SelectedIndex = -1; // гражданство
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            int gender = 0, nation = 0;

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

            workWithDataOfApplicants.ChangeApplicant(id_appl, textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker1.Text, textBox4.Text, textBox5.Text, textBox6.Text, gender, nation, dataGridView1);
            CleanData();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString(); //фамилия
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString(); //имя
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString(); //отчество
            dateTimePicker1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(); //дата рождения
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(); //телефон
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString(); //email
            textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString(); //адрес
            String pol = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString(); //пол
            String nation = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString(); //гражданство
            if (pol.Equals("Мужской"))
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
            }
            else
            {
                radioButton1.Checked = false;
                radioButton2.Checked = true;
            }

            if (nation.Equals("Русское"))
            {
                comboBox1.Text = comboBox1.Items[0].ToString();
            }
            else
            {
                comboBox1.Text = comboBox1.Items[1].ToString();
            }
        }

        private void buttonChoice_Click(object sender, EventArgs e)
        {
            this.Hide();
            JobSearchWindow jobSearchWindow = new JobSearchWindow(id_appl);
            jobSearchWindow.Show();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm("aspirant");
            loginForm.Show();
        }
    }
}
