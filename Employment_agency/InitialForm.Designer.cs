namespace Employment_agency
{
    partial class InitialForm
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
            this.label5 = new System.Windows.Forms.Label();
            this.adminButton = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.aspirantButton = new System.Windows.Forms.Button();
            this.employerButton = new System.Windows.Forms.Button();
            this.сollapseButton = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.adminButton);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.aspirantButton);
            this.panel1.Controls.Add(this.employerButton);
            this.panel1.Controls.Add(this.сollapseButton);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(458, 331);
            this.panel1.TabIndex = 0;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(27, 305);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(396, 17);
            this.label5.TabIndex = 75;
            this.label5.Text = "По всем вопросам обращаться на почту: employment.agency@mail.ru";
            // 
            // adminButton
            // 
            this.adminButton.AutoSize = true;
            this.adminButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.adminButton.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.adminButton.ForeColor = System.Drawing.Color.Transparent;
            this.adminButton.Location = new System.Drawing.Point(106, 256);
            this.adminButton.Name = "adminButton";
            this.adminButton.Size = new System.Drawing.Size(245, 17);
            this.adminButton.TabIndex = 74;
            this.adminButton.Text = "Войти в приложение как администратор";
            this.adminButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.adminButton_MouseClick);
            this.adminButton.MouseEnter += new System.EventHandler(this.label4_MouseEnter);
            this.adminButton.MouseLeave += new System.EventHandler(this.label4_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(189, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 40);
            this.label3.TabIndex = 73;
            this.label3.Text = "или";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(456, 21);
            this.label2.TabIndex = 72;
            this.label2.Text = "Выберите, в качестве кого вы хотите зайти в приложение";
            // 
            // aspirantButton
            // 
            this.aspirantButton.BackColor = System.Drawing.Color.Red;
            this.aspirantButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.aspirantButton.FlatAppearance.BorderSize = 0;
            this.aspirantButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.aspirantButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.aspirantButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.aspirantButton.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aspirantButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.aspirantButton.Location = new System.Drawing.Point(90, 183);
            this.aspirantButton.Name = "aspirantButton";
            this.aspirantButton.Size = new System.Drawing.Size(275, 53);
            this.aspirantButton.TabIndex = 71;
            this.aspirantButton.Text = "Соискатель";
            this.aspirantButton.UseVisualStyleBackColor = false;
            this.aspirantButton.Click += new System.EventHandler(this.aspirantButton_Click);
            // 
            // employerButton
            // 
            this.employerButton.BackColor = System.Drawing.Color.Blue;
            this.employerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.employerButton.FlatAppearance.BorderSize = 0;
            this.employerButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(245)))), ((int)(((byte)(214)))));
            this.employerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(245)))), ((int)(((byte)(214)))));
            this.employerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.employerButton.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.employerButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.employerButton.Location = new System.Drawing.Point(90, 74);
            this.employerButton.Name = "employerButton";
            this.employerButton.Size = new System.Drawing.Size(275, 53);
            this.employerButton.TabIndex = 70;
            this.employerButton.Text = "Работодатель";
            this.employerButton.UseVisualStyleBackColor = false;
            this.employerButton.Click += new System.EventHandler(this.employerButton_Click);
            // 
            // сollapseButton
            // 
            this.сollapseButton.AutoSize = true;
            this.сollapseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.сollapseButton.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.сollapseButton.ForeColor = System.Drawing.Color.Lime;
            this.сollapseButton.Location = new System.Drawing.Point(414, -2);
            this.сollapseButton.Name = "сollapseButton";
            this.сollapseButton.Size = new System.Drawing.Size(22, 30);
            this.сollapseButton.TabIndex = 10;
            this.сollapseButton.Text = "–";
            this.сollapseButton.Click += new System.EventHandler(this.сollapseButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.ForeColor = System.Drawing.Color.Red;
            this.closeButton.Location = new System.Drawing.Point(433, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(26, 27);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "X";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(362, 40);
            this.label1.TabIndex = 3;
            this.label1.Text = "Доброго времени суток!";
            // 
            // InitialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(458, 331);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InitialForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InitialForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label сollapseButton;
        private System.Windows.Forms.Label closeButton;
        private System.Windows.Forms.Button aspirantButton;
        private System.Windows.Forms.Button employerButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label adminButton;
        private System.Windows.Forms.Label label5;
    }
}