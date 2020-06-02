namespace Employment_agency
{
    partial class FormAdminActions
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonExit = new System.Windows.Forms.Button();
            this.buttonDisplayEmployer = new System.Windows.Forms.Button();
            this.buttonDisplayApplicants = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.сollapseButton = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Label();
            this.addKeyButton = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.addKeyButton);
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.buttonDisplayEmployer);
            this.panel1.Controls.Add(this.buttonDisplayApplicants);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.textEmail);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridView2);
            this.panel1.Controls.Add(this.сollapseButton);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(673, 433);
            this.panel1.TabIndex = 0;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // buttonExit
            // 
            this.buttonExit.BackColor = System.Drawing.Color.Red;
            this.buttonExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Salmon;
            this.buttonExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Salmon;
            this.buttonExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonExit.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonExit.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonExit.Location = new System.Drawing.Point(594, 394);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(71, 31);
            this.buttonExit.TabIndex = 119;
            this.buttonExit.Text = "Выйти";
            this.buttonExit.UseVisualStyleBackColor = false;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // buttonDisplayEmployer
            // 
            this.buttonDisplayEmployer.BackColor = System.Drawing.Color.Blue;
            this.buttonDisplayEmployer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDisplayEmployer.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.buttonDisplayEmployer.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.buttonDisplayEmployer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDisplayEmployer.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDisplayEmployer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonDisplayEmployer.Location = new System.Drawing.Point(309, 42);
            this.buttonDisplayEmployer.Name = "buttonDisplayEmployer";
            this.buttonDisplayEmployer.Size = new System.Drawing.Size(185, 31);
            this.buttonDisplayEmployer.TabIndex = 118;
            this.buttonDisplayEmployer.Text = "Показать работодателей";
            this.buttonDisplayEmployer.UseVisualStyleBackColor = false;
            this.buttonDisplayEmployer.Click += new System.EventHandler(this.buttonDisplayEmployer_Click);
            // 
            // buttonDisplayApplicants
            // 
            this.buttonDisplayApplicants.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonDisplayApplicants.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDisplayApplicants.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Chartreuse;
            this.buttonDisplayApplicants.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chartreuse;
            this.buttonDisplayApplicants.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDisplayApplicants.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDisplayApplicants.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonDisplayApplicants.Location = new System.Drawing.Point(309, 6);
            this.buttonDisplayApplicants.Name = "buttonDisplayApplicants";
            this.buttonDisplayApplicants.Size = new System.Drawing.Size(185, 31);
            this.buttonDisplayApplicants.TabIndex = 117;
            this.buttonDisplayApplicants.Text = " Показать соискателей";
            this.buttonDisplayApplicants.UseVisualStyleBackColor = false;
            this.buttonDisplayApplicants.Click += new System.EventHandler(this.buttonDisplayApplicants_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label8.Location = new System.Drawing.Point(4, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 17);
            this.label8.TabIndex = 116;
            this.label8.Text = "Введите email для поиска";
            // 
            // textEmail
            // 
            this.textEmail.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textEmail.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textEmail.Location = new System.Drawing.Point(7, 30);
            this.textEmail.Name = "textEmail";
            this.textEmail.Size = new System.Drawing.Size(282, 26);
            this.textEmail.TabIndex = 86;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(286, 23);
            this.label1.TabIndex = 85;
            this.label1.Text = "Список всех клиентов приложения";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(7, 79);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(658, 309);
            this.dataGridView2.TabIndex = 84;
            this.dataGridView2.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView2_CellMouseDoubleClick);
            // 
            // сollapseButton
            // 
            this.сollapseButton.AutoSize = true;
            this.сollapseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.сollapseButton.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.сollapseButton.ForeColor = System.Drawing.Color.Lime;
            this.сollapseButton.Location = new System.Drawing.Point(625, 4);
            this.сollapseButton.Name = "сollapseButton";
            this.сollapseButton.Size = new System.Drawing.Size(22, 30);
            this.сollapseButton.TabIndex = 83;
            this.сollapseButton.Text = "–";
            this.сollapseButton.Click += new System.EventHandler(this.сollapseButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.ForeColor = System.Drawing.Color.Red;
            this.closeButton.Location = new System.Drawing.Point(644, 4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(26, 27);
            this.closeButton.TabIndex = 82;
            this.closeButton.Text = "X";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // addKeyButton
            // 
            this.addKeyButton.AutoSize = true;
            this.addKeyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addKeyButton.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addKeyButton.ForeColor = System.Drawing.Color.Transparent;
            this.addKeyButton.Location = new System.Drawing.Point(12, 394);
            this.addKeyButton.Name = "addKeyButton";
            this.addKeyButton.Size = new System.Drawing.Size(352, 17);
            this.addKeyButton.TabIndex = 120;
            this.addKeyButton.Text = "Добавить новый инициализирующий ключ для компании";
            this.addKeyButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.addKeyButton_MouseClick);
            this.addKeyButton.MouseEnter += new System.EventHandler(this.addKeyButton_MouseEnter);
            this.addKeyButton.MouseLeave += new System.EventHandler(this.addKeyButton_MouseLeave);
            // 
            // FormAdminActions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 433);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAdminActions";
            this.Text = "FormAdminActions";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label сollapseButton;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonDisplayApplicants;
        private System.Windows.Forms.Button buttonDisplayEmployer;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label addKeyButton;
    }
}