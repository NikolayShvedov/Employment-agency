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
    public partial class InitialForm : Form
    {
        private Point MouseHook;

        public InitialForm()
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

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            adminButton.Font = new Font(adminButton.Font, FontStyle.Underline);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            adminButton.Font = new Font(adminButton.Font, FontStyle.Regular);
        }

        private void employerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm("employer");
            loginForm.Show();
        }

        private void aspirantButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm("aspirant");
            loginForm.Show();
        }

        private void adminButton_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm("admin");
            loginForm.Show();
        }
    }
}
