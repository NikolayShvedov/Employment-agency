namespace Employment_agency
{
    partial class KeyAddForm
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
            this.сollapseButton = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Label();
            this.buttonAddKey = new System.Windows.Forms.Button();
            this.textCompany = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textKey = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.сollapseButton);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Controls.Add(this.buttonAddKey);
            this.panel1.Controls.Add(this.textCompany);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textKey);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 213);
            this.panel1.TabIndex = 0;
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            // 
            // сollapseButton
            // 
            this.сollapseButton.AutoSize = true;
            this.сollapseButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.сollapseButton.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.сollapseButton.ForeColor = System.Drawing.Color.Lime;
            this.сollapseButton.Location = new System.Drawing.Point(280, -2);
            this.сollapseButton.Name = "сollapseButton";
            this.сollapseButton.Size = new System.Drawing.Size(22, 30);
            this.сollapseButton.TabIndex = 120;
            this.сollapseButton.Text = "–";
            this.сollapseButton.Click += new System.EventHandler(this.сollapseButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.AutoSize = true;
            this.closeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeButton.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closeButton.ForeColor = System.Drawing.Color.Red;
            this.closeButton.Location = new System.Drawing.Point(299, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(26, 27);
            this.closeButton.TabIndex = 119;
            this.closeButton.Text = "X";
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // buttonAddKey
            // 
            this.buttonAddKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonAddKey.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonAddKey.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Chartreuse;
            this.buttonAddKey.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Chartreuse;
            this.buttonAddKey.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddKey.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddKey.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonAddKey.Location = new System.Drawing.Point(190, 170);
            this.buttonAddKey.Name = "buttonAddKey";
            this.buttonAddKey.Size = new System.Drawing.Size(123, 31);
            this.buttonAddKey.TabIndex = 118;
            this.buttonAddKey.Text = " Добавить";
            this.buttonAddKey.UseVisualStyleBackColor = false;
            this.buttonAddKey.Click += new System.EventHandler(this.buttonAddKey_Click);
            // 
            // textCompany
            // 
            this.textCompany.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textCompany.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textCompany.Location = new System.Drawing.Point(8, 133);
            this.textCompany.Name = "textCompany";
            this.textCompany.Size = new System.Drawing.Size(282, 26);
            this.textCompany.TabIndex = 90;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(3, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 30);
            this.label2.TabIndex = 89;
            this.label2.Text = "Компания:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(3, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 30);
            this.label1.TabIndex = 88;
            this.label1.Text = "Инициализирующий ключ:";
            // 
            // textKey
            // 
            this.textKey.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.textKey.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textKey.Location = new System.Drawing.Point(8, 61);
            this.textKey.Name = "textKey";
            this.textKey.Size = new System.Drawing.Size(282, 26);
            this.textKey.TabIndex = 87;
            // 
            // KeyAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 213);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KeyAddForm";
            this.Text = "KeyAddForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textKey;
        private System.Windows.Forms.TextBox textCompany;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAddKey;
        private System.Windows.Forms.Label сollapseButton;
        private System.Windows.Forms.Label closeButton;
    }
}