namespace BibliotecaEtec
{
    partial class F_EditaAlocacao
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
            this.btn_salvar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lb_titulo = new System.Windows.Forms.Label();
            this.img_livro = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb_cpfUser = new System.Windows.Forms.Label();
            this.lb_nomeUser = new System.Windows.Forms.Label();
            this.lb_instituicao = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lb_cpfAdmin = new System.Windows.Forms.Label();
            this.lb_nomeAdmin = new System.Windows.Forms.Label();
            this.dtp_dataDevolucao = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.img_perfilAdmin = new BibliotecaEtec.IMGRadius();
            this.img_perfilUser = new BibliotecaEtec.IMGRadius();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_livro)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_perfilAdmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_perfilUser)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_salvar
            // 
            this.btn_salvar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(135)))), ((int)(((byte)(245)))));
            this.btn_salvar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_salvar.FlatAppearance.BorderSize = 0;
            this.btn_salvar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_salvar.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_salvar.ForeColor = System.Drawing.Color.White;
            this.btn_salvar.Location = new System.Drawing.Point(468, 519);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.Size = new System.Drawing.Size(160, 38);
            this.btn_salvar.TabIndex = 134;
            this.btn_salvar.Text = "Salvar Edições";
            this.btn_salvar.UseVisualStyleBackColor = false;
            this.btn_salvar.Click += new System.EventHandler(this.btn_exportar_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(19)))));
            this.panel1.Controls.Add(this.lb_instituicao);
            this.panel1.Controls.Add(this.lb_titulo);
            this.panel1.Controls.Add(this.img_livro);
            this.panel1.Location = new System.Drawing.Point(33, 84);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 76);
            this.panel1.TabIndex = 129;
            // 
            // lb_titulo
            // 
            this.lb_titulo.AutoSize = true;
            this.lb_titulo.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titulo.ForeColor = System.Drawing.Color.White;
            this.lb_titulo.Location = new System.Drawing.Point(65, 14);
            this.lb_titulo.Name = "lb_titulo";
            this.lb_titulo.Size = new System.Drawing.Size(44, 16);
            this.lb_titulo.TabIndex = 1;
            this.lb_titulo.Text = "Titulo";
            // 
            // img_livro
            // 
            this.img_livro.Location = new System.Drawing.Point(12, 14);
            this.img_livro.Name = "img_livro";
            this.img_livro.Size = new System.Drawing.Size(35, 50);
            this.img_livro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_livro.TabIndex = 0;
            this.img_livro.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Controls.Add(this.pictureBox4);
            this.panel3.Controls.Add(this.pictureBox3);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(663, 52);
            this.panel3.TabIndex = 128;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.Image = global::BibliotecaEtec.Properties.Resources.LogoJKCircular;
            this.pictureBox4.Location = new System.Drawing.Point(620, 12);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(30, 30);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 11;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = global::BibliotecaEtec.Properties.Resources.LogoCPSCircular;
            this.pictureBox3.Location = new System.Drawing.Point(584, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BibliotecaEtec.Properties.Resources.LogoCircular;
            this.pictureBox1.Location = new System.Drawing.Point(15, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 30);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(51, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Biblioteca - Editar Alocação";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(19)))));
            this.panel2.Controls.Add(this.img_perfilUser);
            this.panel2.Controls.Add(this.lb_cpfUser);
            this.panel2.Controls.Add(this.lb_nomeUser);
            this.panel2.Location = new System.Drawing.Point(33, 177);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(594, 76);
            this.panel2.TabIndex = 130;
            // 
            // lb_cpfUser
            // 
            this.lb_cpfUser.AutoSize = true;
            this.lb_cpfUser.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_cpfUser.ForeColor = System.Drawing.Color.White;
            this.lb_cpfUser.Location = new System.Drawing.Point(65, 48);
            this.lb_cpfUser.Name = "lb_cpfUser";
            this.lb_cpfUser.Size = new System.Drawing.Size(34, 16);
            this.lb_cpfUser.TabIndex = 2;
            this.lb_cpfUser.Text = "CPF";
            // 
            // lb_nomeUser
            // 
            this.lb_nomeUser.AutoSize = true;
            this.lb_nomeUser.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nomeUser.ForeColor = System.Drawing.Color.White;
            this.lb_nomeUser.Location = new System.Drawing.Point(65, 14);
            this.lb_nomeUser.Name = "lb_nomeUser";
            this.lb_nomeUser.Size = new System.Drawing.Size(45, 16);
            this.lb_nomeUser.TabIndex = 1;
            this.lb_nomeUser.Text = "Nome";
            // 
            // lb_instituicao
            // 
            this.lb_instituicao.AutoSize = true;
            this.lb_instituicao.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_instituicao.ForeColor = System.Drawing.Color.White;
            this.lb_instituicao.Location = new System.Drawing.Point(65, 48);
            this.lb_instituicao.Name = "lb_instituicao";
            this.lb_instituicao.Size = new System.Drawing.Size(73, 16);
            this.lb_instituicao.TabIndex = 3;
            this.lb_instituicao.Text = "Instituição";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(19)))), ((int)(((byte)(19)))));
            this.panel4.Controls.Add(this.img_perfilAdmin);
            this.panel4.Controls.Add(this.lb_cpfAdmin);
            this.panel4.Controls.Add(this.lb_nomeAdmin);
            this.panel4.Location = new System.Drawing.Point(33, 319);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(594, 76);
            this.panel4.TabIndex = 131;
            // 
            // lb_cpfAdmin
            // 
            this.lb_cpfAdmin.AutoSize = true;
            this.lb_cpfAdmin.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_cpfAdmin.ForeColor = System.Drawing.Color.White;
            this.lb_cpfAdmin.Location = new System.Drawing.Point(65, 48);
            this.lb_cpfAdmin.Name = "lb_cpfAdmin";
            this.lb_cpfAdmin.Size = new System.Drawing.Size(34, 16);
            this.lb_cpfAdmin.TabIndex = 2;
            this.lb_cpfAdmin.Text = "CPF";
            // 
            // lb_nomeAdmin
            // 
            this.lb_nomeAdmin.AutoSize = true;
            this.lb_nomeAdmin.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nomeAdmin.ForeColor = System.Drawing.Color.White;
            this.lb_nomeAdmin.Location = new System.Drawing.Point(65, 14);
            this.lb_nomeAdmin.Name = "lb_nomeAdmin";
            this.lb_nomeAdmin.Size = new System.Drawing.Size(45, 16);
            this.lb_nomeAdmin.TabIndex = 1;
            this.lb_nomeAdmin.Text = "Nome";
            // 
            // dtp_dataDevolucao
            // 
            this.dtp_dataDevolucao.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtp_dataDevolucao.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_dataDevolucao.Location = new System.Drawing.Point(34, 454);
            this.dtp_dataDevolucao.Name = "dtp_dataDevolucao";
            this.dtp_dataDevolucao.Size = new System.Drawing.Size(594, 26);
            this.dtp_dataDevolucao.TabIndex = 135;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(30, 422);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(146, 18);
            this.label7.TabIndex = 136;
            this.label7.Text = "Data de Devolução:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(31, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(275, 16);
            this.label2.TabIndex = 137;
            this.label2.Text = "Administrador responsável pela alocação:";
            // 
            // img_perfilAdmin
            // 
            this.img_perfilAdmin.Location = new System.Drawing.Point(12, 19);
            this.img_perfilAdmin.Name = "img_perfilAdmin";
            this.img_perfilAdmin.Size = new System.Drawing.Size(40, 40);
            this.img_perfilAdmin.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_perfilAdmin.TabIndex = 3;
            this.img_perfilAdmin.TabStop = false;
            // 
            // img_perfilUser
            // 
            this.img_perfilUser.Location = new System.Drawing.Point(12, 19);
            this.img_perfilUser.Name = "img_perfilUser";
            this.img_perfilUser.Size = new System.Drawing.Size(40, 40);
            this.img_perfilUser.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_perfilUser.TabIndex = 3;
            this.img_perfilUser.TabStop = false;
            // 
            // F_EditaAlocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.ClientSize = new System.Drawing.Size(663, 595);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp_dataDevolucao);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_salvar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "F_EditaAlocacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biblioteca - Editar Alocação";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_livro)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_perfilAdmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_perfilUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_salvar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lb_instituicao;
        private System.Windows.Forms.Label lb_titulo;
        private System.Windows.Forms.PictureBox img_livro;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private IMGRadius img_perfilUser;
        private System.Windows.Forms.Label lb_cpfUser;
        private System.Windows.Forms.Label lb_nomeUser;
        private System.Windows.Forms.Panel panel4;
        private IMGRadius img_perfilAdmin;
        private System.Windows.Forms.Label lb_cpfAdmin;
        private System.Windows.Forms.Label lb_nomeAdmin;
        private System.Windows.Forms.DateTimePicker dtp_dataDevolucao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
    }
}