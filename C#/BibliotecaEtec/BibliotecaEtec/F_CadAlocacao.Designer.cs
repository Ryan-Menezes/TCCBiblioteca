namespace BibliotecaEtec
{
    partial class F_CadAlocacao
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tb_rmCpf = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cb_tipoUsuario = new System.Windows.Forms.ComboBox();
            this.lb_aviso = new System.Windows.Forms.Label();
            this.lb_titulo = new System.Windows.Forms.Label();
            this.btn_adicionarLivros = new System.Windows.Forms.Button();
            this.list_livros = new System.Windows.Forms.ListBox();
            this.lb_livro = new System.Windows.Forms.Label();
            this.dtp_devolucao = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtp_alocacao = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_alocar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(160, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 20);
            this.label4.TabIndex = 49;
            this.label4.Text = "Gênero:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(160, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 20);
            this.label3.TabIndex = 46;
            this.label3.Text = "Ano de Publicação:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.pictureBox4);
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(781, 62);
            this.panel2.TabIndex = 51;
            this.panel2.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.list_livros_MouseDoubleClick);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.Image = global::BibliotecaEtec.Properties.Resources.LogoJKCircular;
            this.pictureBox4.Location = new System.Drawing.Point(729, 12);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(40, 40);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 11;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = global::BibliotecaEtec.Properties.Resources.LogoCPSCircular;
            this.pictureBox3.Location = new System.Drawing.Point(683, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BibliotecaEtec.Properties.Resources.LogoCircular;
            this.pictureBox1.Location = new System.Drawing.Point(15, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(61, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 18);
            this.label1.TabIndex = 9;
            this.label1.Text = "Biblioteca - Adicionar Alocação";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.tb_rmCpf);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.cb_tipoUsuario);
            this.panel1.Controls.Add(this.lb_aviso);
            this.panel1.Controls.Add(this.lb_titulo);
            this.panel1.Controls.Add(this.btn_adicionarLivros);
            this.panel1.Controls.Add(this.list_livros);
            this.panel1.Controls.Add(this.lb_livro);
            this.panel1.Controls.Add(this.dtp_devolucao);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.dtp_alocacao);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.maskedTextBox3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.maskedTextBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.maskedTextBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(781, 588);
            this.panel1.TabIndex = 52;
            // 
            // tb_rmCpf
            // 
            this.tb_rmCpf.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.tb_rmCpf.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tb_rmCpf.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.tb_rmCpf.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_rmCpf.ForeColor = System.Drawing.Color.White;
            this.tb_rmCpf.Location = new System.Drawing.Point(64, 440);
            this.tb_rmCpf.Name = "tb_rmCpf";
            this.tb_rmCpf.Size = new System.Drawing.Size(638, 26);
            this.tb_rmCpf.TabIndex = 129;
            this.tb_rmCpf.Tag = "11";
            this.tb_rmCpf.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.tb_rmCpf.TextChanged += new System.EventHandler(this.tb_rmCpf_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(62, 329);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 18);
            this.label11.TabIndex = 128;
            this.label11.Text = "Tipo de Usuário:";
            // 
            // cb_tipoUsuario
            // 
            this.cb_tipoUsuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.cb_tipoUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_tipoUsuario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_tipoUsuario.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_tipoUsuario.ForeColor = System.Drawing.Color.White;
            this.cb_tipoUsuario.FormattingEnabled = true;
            this.cb_tipoUsuario.Items.AddRange(new object[] {
            "Etec Juscelino",
            "Etec Juscelino",
            "Etec Juscelino",
            "Etec Juscelino",
            "Etec Juscelino"});
            this.cb_tipoUsuario.Location = new System.Drawing.Point(64, 360);
            this.cb_tipoUsuario.Name = "cb_tipoUsuario";
            this.cb_tipoUsuario.Size = new System.Drawing.Size(638, 24);
            this.cb_tipoUsuario.TabIndex = 127;
            this.cb_tipoUsuario.SelectedValueChanged += new System.EventHandler(this.cb_tipoUsuario_SelectedValueChanged);
            // 
            // lb_aviso
            // 
            this.lb_aviso.AutoSize = true;
            this.lb_aviso.BackColor = System.Drawing.Color.Transparent;
            this.lb_aviso.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_aviso.ForeColor = System.Drawing.Color.Maroon;
            this.lb_aviso.Location = new System.Drawing.Point(62, 469);
            this.lb_aviso.Name = "lb_aviso";
            this.lb_aviso.Size = new System.Drawing.Size(70, 15);
            this.lb_aviso.TabIndex = 126;
            this.lb_aviso.Text = "Digite o RM";
            this.lb_aviso.Visible = false;
            // 
            // lb_titulo
            // 
            this.lb_titulo.AutoSize = true;
            this.lb_titulo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titulo.ForeColor = System.Drawing.Color.White;
            this.lb_titulo.Location = new System.Drawing.Point(62, 407);
            this.lb_titulo.Name = "lb_titulo";
            this.lb_titulo.Size = new System.Drawing.Size(36, 18);
            this.lb_titulo.TabIndex = 123;
            this.lb_titulo.Text = "RM:";
            // 
            // btn_adicionarLivros
            // 
            this.btn_adicionarLivros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(135)))), ((int)(((byte)(245)))));
            this.btn_adicionarLivros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_adicionarLivros.FlatAppearance.BorderSize = 0;
            this.btn_adicionarLivros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_adicionarLivros.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_adicionarLivros.ForeColor = System.Drawing.Color.White;
            this.btn_adicionarLivros.Location = new System.Drawing.Point(64, 246);
            this.btn_adicionarLivros.Name = "btn_adicionarLivros";
            this.btn_adicionarLivros.Size = new System.Drawing.Size(140, 32);
            this.btn_adicionarLivros.TabIndex = 4;
            this.btn_adicionarLivros.Text = "Selecionar Livro";
            this.btn_adicionarLivros.UseVisualStyleBackColor = false;
            this.btn_adicionarLivros.Click += new System.EventHandler(this.btn_adicionarLivros_Click);
            // 
            // list_livros
            // 
            this.list_livros.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.list_livros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.list_livros.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_livros.ForeColor = System.Drawing.Color.White;
            this.list_livros.FormattingEnabled = true;
            this.list_livros.ItemHeight = 16;
            this.list_livros.Location = new System.Drawing.Point(65, 142);
            this.list_livros.Name = "list_livros";
            this.list_livros.Size = new System.Drawing.Size(638, 98);
            this.list_livros.TabIndex = 3;
            this.list_livros.Enter += new System.EventHandler(this.list_livros_Enter);
            this.list_livros.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.list_livros_MouseDoubleClick);
            // 
            // lb_livro
            // 
            this.lb_livro.AutoSize = true;
            this.lb_livro.BackColor = System.Drawing.Color.Transparent;
            this.lb_livro.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_livro.ForeColor = System.Drawing.Color.Maroon;
            this.lb_livro.Location = new System.Drawing.Point(61, 297);
            this.lb_livro.Name = "lb_livro";
            this.lb_livro.Size = new System.Drawing.Size(242, 15);
            this.lb_livro.TabIndex = 84;
            this.lb_livro.Text = "Selecione pelo menos um livro para alocar";
            this.lb_livro.Visible = false;
            // 
            // dtp_devolucao
            // 
            this.dtp_devolucao.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtp_devolucao.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_devolucao.Location = new System.Drawing.Point(396, 82);
            this.dtp_devolucao.Name = "dtp_devolucao";
            this.dtp_devolucao.Size = new System.Drawing.Size(307, 26);
            this.dtp_devolucao.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(392, 50);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(146, 18);
            this.label10.TabIndex = 58;
            this.label10.Text = "Data de Devolução:";
            // 
            // dtp_alocacao
            // 
            this.dtp_alocacao.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtp_alocacao.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_alocacao.Location = new System.Drawing.Point(65, 82);
            this.dtp_alocacao.Name = "dtp_alocacao";
            this.dtp_alocacao.Size = new System.Drawing.Size(312, 26);
            this.dtp_alocacao.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(61, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 18);
            this.label7.TabIndex = 34;
            this.label7.Text = "Data da Alocação:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_alocar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 489);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(781, 99);
            this.panel3.TabIndex = 32;
            // 
            // btn_alocar
            // 
            this.btn_alocar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(135)))), ((int)(((byte)(245)))));
            this.btn_alocar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_alocar.FlatAppearance.BorderSize = 0;
            this.btn_alocar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_alocar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_alocar.ForeColor = System.Drawing.Color.White;
            this.btn_alocar.Location = new System.Drawing.Point(528, 25);
            this.btn_alocar.Name = "btn_alocar";
            this.btn_alocar.Size = new System.Drawing.Size(180, 40);
            this.btn_alocar.TabIndex = 6;
            this.btn_alocar.Text = "Cadastrar Alocação";
            this.btn_alocar.UseVisualStyleBackColor = false;
            this.btn_alocar.Click += new System.EventHandler(this.btn_alocar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(498, -118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Celular:";
            // 
            // maskedTextBox3
            // 
            this.maskedTextBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.maskedTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBox3.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.maskedTextBox3.ForeColor = System.Drawing.Color.White;
            this.maskedTextBox3.Location = new System.Drawing.Point(502, -85);
            this.maskedTextBox3.Mask = "(00)00000-0000";
            this.maskedTextBox3.Name = "maskedTextBox3";
            this.maskedTextBox3.Size = new System.Drawing.Size(201, 26);
            this.maskedTextBox3.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(282, -118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Telefone:";
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.maskedTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBox2.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.maskedTextBox2.ForeColor = System.Drawing.Color.White;
            this.maskedTextBox2.Location = new System.Drawing.Point(286, -85);
            this.maskedTextBox2.Mask = "(00)00000-0000";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(201, 26);
            this.maskedTextBox2.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(61, -118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "CPF:";
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.maskedTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.maskedTextBox1.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maskedTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.maskedTextBox1.ForeColor = System.Drawing.Color.White;
            this.maskedTextBox1.Location = new System.Drawing.Point(65, -85);
            this.maskedTextBox1.Mask = "000.000.000-00";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(201, 26);
            this.maskedTextBox1.TabIndex = 8;
            // 
            // F_CadAlocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.ClientSize = new System.Drawing.Size(781, 650);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "F_CadAlocacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biblioteca - Adicionar Alocação";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_alocar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox maskedTextBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.DateTimePicker dtp_alocacao;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtp_devolucao;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lb_livro;
        private System.Windows.Forms.Button btn_adicionarLivros;
        private System.Windows.Forms.Label lb_aviso;
        private System.Windows.Forms.Label lb_titulo;
        public System.Windows.Forms.ListBox list_livros;
        private System.Windows.Forms.ComboBox cb_tipoUsuario;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox tb_rmCpf;
    }
}