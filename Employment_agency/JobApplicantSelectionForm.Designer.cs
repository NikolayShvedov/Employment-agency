namespace Employment_agency
{
    partial class JobApplicantSelectionForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonDeleteApplicant = new System.Windows.Forms.Button();
            this.buttonChoice = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.wordExportButton = new System.Windows.Forms.Button();
            this.excelExportButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.сollapseButton = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.buttonBack);
            this.panel1.Controls.Add(this.buttonDeleteApplicant);
            this.panel1.Controls.Add(this.buttonChoice);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.wordExportButton);
            this.panel1.Controls.Add(this.excelExportButton);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.сollapseButton);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(764, 380);
            this.panel1.TabIndex = 0;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Employment_agency.Properties.Resources.determination;
            this.pictureBox1.Location = new System.Drawing.Point(617, 219);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 149);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 92;
            this.pictureBox1.TabStop = false;
            // 
            // buttonBack
            // 
            this.buttonBack.BackColor = System.Drawing.Color.Blue;
            this.buttonBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBack.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.buttonBack.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.buttonBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBack.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonBack.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonBack.Location = new System.Drawing.Point(437, 320);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(142, 48);
            this.buttonBack.TabIndex = 91;
            this.buttonBack.Text = "Вернуться к вакансиям";
            this.buttonBack.UseVisualStyleBackColor = false;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonDeleteApplicant
            // 
            this.buttonDeleteApplicant.BackColor = System.Drawing.Color.Red;
            this.buttonDeleteApplicant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDeleteApplicant.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Salmon;
            this.buttonDeleteApplicant.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Salmon;
            this.buttonDeleteApplicant.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteApplicant.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonDeleteApplicant.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonDeleteApplicant.Location = new System.Drawing.Point(266, 320);
            this.buttonDeleteApplicant.Name = "buttonDeleteApplicant";
            this.buttonDeleteApplicant.Size = new System.Drawing.Size(148, 48);
            this.buttonDeleteApplicant.TabIndex = 90;
            this.buttonDeleteApplicant.Text = "Удалить данного соискателя";
            this.buttonDeleteApplicant.UseVisualStyleBackColor = false;
            this.buttonDeleteApplicant.Click += new System.EventHandler(this.buttonDeleteApplicant_Click);
            // 
            // buttonChoice
            // 
            this.buttonChoice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonChoice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonChoice.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Chartreuse;
            this.buttonChoice.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chartreuse;
            this.buttonChoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonChoice.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonChoice.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonChoice.Location = new System.Drawing.Point(28, 320);
            this.buttonChoice.Name = "buttonChoice";
            this.buttonChoice.Size = new System.Drawing.Size(215, 48);
            this.buttonChoice.TabIndex = 89;
            this.buttonChoice.Text = " Выбрать для вакансии данного соискателя";
            this.buttonChoice.UseVisualStyleBackColor = false;
            this.buttonChoice.Click += new System.EventHandler(this.buttonChoice_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(9, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(613, 18);
            this.label2.TabIndex = 88;
            this.label2.Text = "Выберите наиболее подходящего Вам соискателя и данная вакансия будет считаться за" +
    "крытой.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Aqua;
            this.label1.Location = new System.Drawing.Point(7, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(450, 30);
            this.label1.TabIndex = 87;
            this.label1.Text = "Список соискателей по данной вакансии!";
            // 
            // wordExportButton
            // 
            this.wordExportButton.BackColor = System.Drawing.Color.Blue;
            this.wordExportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.wordExportButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MediumTurquoise;
            this.wordExportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumTurquoise;
            this.wordExportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wordExportButton.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.wordExportButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.wordExportButton.Location = new System.Drawing.Point(617, 120);
            this.wordExportButton.Name = "wordExportButton";
            this.wordExportButton.Size = new System.Drawing.Size(139, 36);
            this.wordExportButton.TabIndex = 86;
            this.wordExportButton.Text = "Отчёт в Word";
            this.wordExportButton.UseVisualStyleBackColor = false;
            this.wordExportButton.Click += new System.EventHandler(this.wordExportButton_Click);
            // 
            // excelExportButton
            // 
            this.excelExportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.excelExportButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.excelExportButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LawnGreen;
            this.excelExportButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LawnGreen;
            this.excelExportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.excelExportButton.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.excelExportButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.excelExportButton.Location = new System.Drawing.Point(617, 67);
            this.excelExportButton.Name = "excelExportButton";
            this.excelExportButton.Size = new System.Drawing.Size(139, 37);
            this.excelExportButton.TabIndex = 85;
            this.excelExportButton.Text = "Отчёт в Excel";
            this.excelExportButton.UseVisualStyleBackColor = false;
            this.excelExportButton.Click += new System.EventHandler(this.excelExportButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(608, 257);
            this.dataGridView1.TabIndex = 84;
            this.dataGridView1.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseClick);
            // 
            // сollapseButton
            // 
            this.сollapseButton.AutoSize = true;
            this.сollapseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.сollapseButton.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.сollapseButton.ForeColor = System.Drawing.Color.Lime;
            this.сollapseButton.Location = new System.Drawing.Point(711, 6);
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
            this.closeButton.Location = new System.Drawing.Point(730, 6);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(26, 27);
            this.closeButton.TabIndex = 82;
            this.closeButton.Text = "X";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // JobApplicantSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(764, 380);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "JobApplicantSelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JobApplicantSelectionForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label сollapseButton;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.Button wordExportButton;
        private System.Windows.Forms.Button excelExportButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonDeleteApplicant;
        private System.Windows.Forms.Button buttonChoice;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}