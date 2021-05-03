namespace Biblioteca01
{
    partial class F_CadProfessor
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
            this.lb_rm_professor = new System.Windows.Forms.Label();
            this.nud_rm_professor = new System.Windows.Forms.NumericUpDown();
            this.btn_cadastrar = new System.Windows.Forms.Button();
            this.txt_email_professor = new System.Windows.Forms.TextBox();
            this.lb_email_professor = new System.Windows.Forms.Label();
            this.txt_celular_professor = new System.Windows.Forms.TextBox();
            this.lb_celular_professor = new System.Windows.Forms.Label();
            this.txt_telefone_professor = new System.Windows.Forms.TextBox();
            this.lb_telefone_professor = new System.Windows.Forms.Label();
            this.txt_complemento_professor = new System.Windows.Forms.TextBox();
            this.lb_complemento_aluno = new System.Windows.Forms.Label();
            this.lb_cidade_professor = new System.Windows.Forms.Label();
            this.cb_cidade_professor = new System.Windows.Forms.ComboBox();
            this.txt_bairro_professor = new System.Windows.Forms.TextBox();
            this.lb_bairro_professor = new System.Windows.Forms.Label();
            this.txt_numero_residencia_professor = new System.Windows.Forms.TextBox();
            this.lb_numero_residencia_professor = new System.Windows.Forms.Label();
            this.txt_logradouro_professor = new System.Windows.Forms.TextBox();
            this.lb_logradouro_professor = new System.Windows.Forms.Label();
            this.txt_cep_professor = new System.Windows.Forms.TextBox();
            this.lb_cep_professor = new System.Windows.Forms.Label();
            this.lb_data_cadastro_professor = new System.Windows.Forms.Label();
            this.lb_sexo_professor = new System.Windows.Forms.Label();
            this.cb_sexo_professor = new System.Windows.Forms.ComboBox();
            this.txt_cpf_professor = new System.Windows.Forms.TextBox();
            this.lb_cpf_professor = new System.Windows.Forms.Label();
            this.txt_sobrenome_professor = new System.Windows.Forms.TextBox();
            this.lb_sobrenome_professor = new System.Windows.Forms.Label();
            this.txt_nome_professor = new System.Windows.Forms.TextBox();
            this.lb_nome_professor = new System.Windows.Forms.Label();
            this.img_perfil_aluno = new System.Windows.Forms.PictureBox();
            this.lb_sede = new System.Windows.Forms.Label();
            this.txt_senha_usuario = new System.Windows.Forms.TextBox();
            this.lb_senha = new System.Windows.Forms.Label();
            this.lb_status = new System.Windows.Forms.Label();
            this.cb_status = new System.Windows.Forms.ComboBox();
            this.lb_nivel_acesso = new System.Windows.Forms.Label();
            this.cb_nivel_acesso = new System.Windows.Forms.ComboBox();
            this.dtp_cadastro_professor = new System.Windows.Forms.DateTimePicker();
            this.cb_cod_instituicao = new System.Windows.Forms.ComboBox();
            this.lb_cod_instituicao = new System.Windows.Forms.Label();
            this.cb_situacao = new System.Windows.Forms.ComboBox();
            this.lb_situacao = new System.Windows.Forms.Label();
            this.cb_sede_professor = new System.Windows.Forms.ComboBox();
            this.lb_id_curso = new System.Windows.Forms.Label();
            this.cb_curso = new System.Windows.Forms.ComboBox();
            this.lb_situacao_curso = new System.Windows.Forms.Label();
            this.cb_situacao_curso = new System.Windows.Forms.ComboBox();
            this.btn_excluir = new System.Windows.Forms.Button();
            this.btn_alterar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_rm_professor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_perfil_aluno)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_rm_professor
            // 
            this.lb_rm_professor.AutoSize = true;
            this.lb_rm_professor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_rm_professor.ForeColor = System.Drawing.Color.Black;
            this.lb_rm_professor.Location = new System.Drawing.Point(226, 31);
            this.lb_rm_professor.Name = "lb_rm_professor";
            this.lb_rm_professor.Size = new System.Drawing.Size(37, 22);
            this.lb_rm_professor.TabIndex = 171;
            this.lb_rm_professor.Text = "Rm";
            // 
            // nud_rm_professor
            // 
            this.nud_rm_professor.Location = new System.Drawing.Point(230, 56);
            this.nud_rm_professor.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nud_rm_professor.Name = "nud_rm_professor";
            this.nud_rm_professor.Size = new System.Drawing.Size(98, 20);
            this.nud_rm_professor.TabIndex = 170;
            // 
            // btn_cadastrar
            // 
            this.btn_cadastrar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_cadastrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cadastrar.FlatAppearance.BorderSize = 0;
            this.btn_cadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_cadastrar.ForeColor = System.Drawing.Color.White;
            this.btn_cadastrar.Location = new System.Drawing.Point(675, 611);
            this.btn_cadastrar.Name = "btn_cadastrar";
            this.btn_cadastrar.Size = new System.Drawing.Size(90, 40);
            this.btn_cadastrar.TabIndex = 169;
            this.btn_cadastrar.Text = "Cadastrar";
            this.btn_cadastrar.UseVisualStyleBackColor = false;
            this.btn_cadastrar.Click += new System.EventHandler(this.btn_cadastrar_Click);
            // 
            // txt_email_professor
            // 
            this.txt_email_professor.Location = new System.Drawing.Point(269, 563);
            this.txt_email_professor.Multiline = true;
            this.txt_email_professor.Name = "txt_email_professor";
            this.txt_email_professor.Size = new System.Drawing.Size(183, 20);
            this.txt_email_professor.TabIndex = 166;
            this.txt_email_professor.TabStop = false;
            // 
            // lb_email_professor
            // 
            this.lb_email_professor.AutoSize = true;
            this.lb_email_professor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_email_professor.ForeColor = System.Drawing.Color.Black;
            this.lb_email_professor.Location = new System.Drawing.Point(268, 538);
            this.lb_email_professor.Name = "lb_email_professor";
            this.lb_email_professor.Size = new System.Drawing.Size(60, 22);
            this.lb_email_professor.TabIndex = 165;
            this.lb_email_professor.Text = "E-mail";
            // 
            // txt_celular_professor
            // 
            this.txt_celular_professor.Location = new System.Drawing.Point(150, 563);
            this.txt_celular_professor.Multiline = true;
            this.txt_celular_professor.Name = "txt_celular_professor";
            this.txt_celular_professor.Size = new System.Drawing.Size(88, 20);
            this.txt_celular_professor.TabIndex = 164;
            this.txt_celular_professor.TabStop = false;
            // 
            // lb_celular_professor
            // 
            this.lb_celular_professor.AutoSize = true;
            this.lb_celular_professor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_celular_professor.ForeColor = System.Drawing.Color.Black;
            this.lb_celular_professor.Location = new System.Drawing.Point(149, 538);
            this.lb_celular_professor.Name = "lb_celular_professor";
            this.lb_celular_professor.Size = new System.Drawing.Size(67, 22);
            this.lb_celular_professor.TabIndex = 163;
            this.lb_celular_professor.Text = "Celular";
            // 
            // txt_telefone_professor
            // 
            this.txt_telefone_professor.Location = new System.Drawing.Point(28, 563);
            this.txt_telefone_professor.Multiline = true;
            this.txt_telefone_professor.Name = "txt_telefone_professor";
            this.txt_telefone_professor.Size = new System.Drawing.Size(88, 20);
            this.txt_telefone_professor.TabIndex = 162;
            this.txt_telefone_professor.TabStop = false;
            // 
            // lb_telefone_professor
            // 
            this.lb_telefone_professor.AutoSize = true;
            this.lb_telefone_professor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_telefone_professor.ForeColor = System.Drawing.Color.Black;
            this.lb_telefone_professor.Location = new System.Drawing.Point(27, 538);
            this.lb_telefone_professor.Name = "lb_telefone_professor";
            this.lb_telefone_professor.Size = new System.Drawing.Size(81, 22);
            this.lb_telefone_professor.TabIndex = 161;
            this.lb_telefone_professor.Text = "Telefone";
            // 
            // txt_complemento_professor
            // 
            this.txt_complemento_professor.Location = new System.Drawing.Point(24, 465);
            this.txt_complemento_professor.Multiline = true;
            this.txt_complemento_professor.Name = "txt_complemento_professor";
            this.txt_complemento_professor.Size = new System.Drawing.Size(158, 54);
            this.txt_complemento_professor.TabIndex = 158;
            this.txt_complemento_professor.TabStop = false;
            // 
            // lb_complemento_aluno
            // 
            this.lb_complemento_aluno.AutoSize = true;
            this.lb_complemento_aluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_complemento_aluno.ForeColor = System.Drawing.Color.Black;
            this.lb_complemento_aluno.Location = new System.Drawing.Point(21, 440);
            this.lb_complemento_aluno.Name = "lb_complemento_aluno";
            this.lb_complemento_aluno.Size = new System.Drawing.Size(120, 22);
            this.lb_complemento_aluno.TabIndex = 157;
            this.lb_complemento_aluno.Text = "Complemento";
            // 
            // lb_cidade_professor
            // 
            this.lb_cidade_professor.AutoSize = true;
            this.lb_cidade_professor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_cidade_professor.ForeColor = System.Drawing.Color.Black;
            this.lb_cidade_professor.Location = new System.Drawing.Point(541, 375);
            this.lb_cidade_professor.Name = "lb_cidade_professor";
            this.lb_cidade_professor.Size = new System.Drawing.Size(67, 22);
            this.lb_cidade_professor.TabIndex = 156;
            this.lb_cidade_professor.Text = "Cidade";
            // 
            // cb_cidade_professor
            // 
            this.cb_cidade_professor.BackColor = System.Drawing.Color.White;
            this.cb_cidade_professor.DropDownHeight = 200;
            this.cb_cidade_professor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_cidade_professor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_cidade_professor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_cidade_professor.ForeColor = System.Drawing.Color.Black;
            this.cb_cidade_professor.FormattingEnabled = true;
            this.cb_cidade_professor.IntegralHeight = false;
            this.cb_cidade_professor.ItemHeight = 16;
            this.cb_cidade_professor.Items.AddRange(new object[] {
            "SÃO PAULO",
            "DIADEMA",
            "SÃO BERNADO DO CAMPO",
            "SÃO CAETANO"});
            this.cb_cidade_professor.Location = new System.Drawing.Point(542, 400);
            this.cb_cidade_professor.Name = "cb_cidade_professor";
            this.cb_cidade_professor.Size = new System.Drawing.Size(125, 24);
            this.cb_cidade_professor.TabIndex = 155;
            // 
            // txt_bairro_professor
            // 
            this.txt_bairro_professor.Location = new System.Drawing.Point(369, 400);
            this.txt_bairro_professor.Multiline = true;
            this.txt_bairro_professor.Name = "txt_bairro_professor";
            this.txt_bairro_professor.Size = new System.Drawing.Size(141, 20);
            this.txt_bairro_professor.TabIndex = 154;
            this.txt_bairro_professor.TabStop = false;
            // 
            // lb_bairro_professor
            // 
            this.lb_bairro_professor.AutoSize = true;
            this.lb_bairro_professor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_bairro_professor.ForeColor = System.Drawing.Color.Black;
            this.lb_bairro_professor.Location = new System.Drawing.Point(368, 375);
            this.lb_bairro_professor.Name = "lb_bairro_professor";
            this.lb_bairro_professor.Size = new System.Drawing.Size(58, 22);
            this.lb_bairro_professor.TabIndex = 153;
            this.lb_bairro_professor.Text = "Bairro";
            // 
            // txt_numero_residencia_professor
            // 
            this.txt_numero_residencia_professor.Location = new System.Drawing.Point(285, 401);
            this.txt_numero_residencia_professor.Multiline = true;
            this.txt_numero_residencia_professor.Name = "txt_numero_residencia_professor";
            this.txt_numero_residencia_professor.Size = new System.Drawing.Size(48, 20);
            this.txt_numero_residencia_professor.TabIndex = 152;
            this.txt_numero_residencia_professor.TabStop = false;
            // 
            // lb_numero_residencia_professor
            // 
            this.lb_numero_residencia_professor.AutoSize = true;
            this.lb_numero_residencia_professor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_numero_residencia_professor.ForeColor = System.Drawing.Color.Black;
            this.lb_numero_residencia_professor.Location = new System.Drawing.Point(281, 375);
            this.lb_numero_residencia_professor.Name = "lb_numero_residencia_professor";
            this.lb_numero_residencia_professor.Size = new System.Drawing.Size(30, 22);
            this.lb_numero_residencia_professor.TabIndex = 151;
            this.lb_numero_residencia_professor.Text = "Nº";
            // 
            // txt_logradouro_professor
            // 
            this.txt_logradouro_professor.Location = new System.Drawing.Point(118, 400);
            this.txt_logradouro_professor.Multiline = true;
            this.txt_logradouro_professor.Name = "txt_logradouro_professor";
            this.txt_logradouro_professor.Size = new System.Drawing.Size(141, 20);
            this.txt_logradouro_professor.TabIndex = 150;
            this.txt_logradouro_professor.TabStop = false;
            // 
            // lb_logradouro_professor
            // 
            this.lb_logradouro_professor.AutoSize = true;
            this.lb_logradouro_professor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_logradouro_professor.ForeColor = System.Drawing.Color.Black;
            this.lb_logradouro_professor.Location = new System.Drawing.Point(117, 375);
            this.lb_logradouro_professor.Name = "lb_logradouro_professor";
            this.lb_logradouro_professor.Size = new System.Drawing.Size(102, 22);
            this.lb_logradouro_professor.TabIndex = 149;
            this.lb_logradouro_professor.Text = "Logradouro";
            // 
            // txt_cep_professor
            // 
            this.txt_cep_professor.Location = new System.Drawing.Point(25, 400);
            this.txt_cep_professor.Multiline = true;
            this.txt_cep_professor.Name = "txt_cep_professor";
            this.txt_cep_professor.Size = new System.Drawing.Size(81, 20);
            this.txt_cep_professor.TabIndex = 148;
            this.txt_cep_professor.TabStop = false;
            // 
            // lb_cep_professor
            // 
            this.lb_cep_professor.AutoSize = true;
            this.lb_cep_professor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_cep_professor.ForeColor = System.Drawing.Color.Black;
            this.lb_cep_professor.Location = new System.Drawing.Point(24, 375);
            this.lb_cep_professor.Name = "lb_cep_professor";
            this.lb_cep_professor.Size = new System.Drawing.Size(43, 22);
            this.lb_cep_professor.TabIndex = 147;
            this.lb_cep_professor.Text = "Cep";
            // 
            // lb_data_cadastro_professor
            // 
            this.lb_data_cadastro_professor.AutoSize = true;
            this.lb_data_cadastro_professor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_data_cadastro_professor.ForeColor = System.Drawing.Color.Black;
            this.lb_data_cadastro_professor.Location = new System.Drawing.Point(25, 599);
            this.lb_data_cadastro_professor.Name = "lb_data_cadastro_professor";
            this.lb_data_cadastro_professor.Size = new System.Drawing.Size(147, 22);
            this.lb_data_cadastro_professor.TabIndex = 145;
            this.lb_data_cadastro_professor.Text = "Data de cadastro";
            // 
            // lb_sexo_professor
            // 
            this.lb_sexo_professor.AutoSize = true;
            this.lb_sexo_professor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sexo_professor.ForeColor = System.Drawing.Color.Black;
            this.lb_sexo_professor.Location = new System.Drawing.Point(400, 187);
            this.lb_sexo_professor.Name = "lb_sexo_professor";
            this.lb_sexo_professor.Size = new System.Drawing.Size(51, 22);
            this.lb_sexo_professor.TabIndex = 144;
            this.lb_sexo_professor.Text = "Sexo";
            // 
            // cb_sexo_professor
            // 
            this.cb_sexo_professor.BackColor = System.Drawing.Color.White;
            this.cb_sexo_professor.DropDownHeight = 200;
            this.cb_sexo_professor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_sexo_professor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_sexo_professor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_sexo_professor.ForeColor = System.Drawing.Color.Black;
            this.cb_sexo_professor.FormattingEnabled = true;
            this.cb_sexo_professor.IntegralHeight = false;
            this.cb_sexo_professor.ItemHeight = 16;
            this.cb_sexo_professor.Items.AddRange(new object[] {
            "M",
            "F",
            "O"});
            this.cb_sexo_professor.Location = new System.Drawing.Point(404, 210);
            this.cb_sexo_professor.Name = "cb_sexo_professor";
            this.cb_sexo_professor.Size = new System.Drawing.Size(98, 24);
            this.cb_sexo_professor.TabIndex = 143;
            // 
            // txt_cpf_professor
            // 
            this.txt_cpf_professor.Location = new System.Drawing.Point(227, 212);
            this.txt_cpf_professor.Multiline = true;
            this.txt_cpf_professor.Name = "txt_cpf_professor";
            this.txt_cpf_professor.Size = new System.Drawing.Size(141, 20);
            this.txt_cpf_professor.TabIndex = 142;
            this.txt_cpf_professor.TabStop = false;
            // 
            // lb_cpf_professor
            // 
            this.lb_cpf_professor.AutoSize = true;
            this.lb_cpf_professor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_cpf_professor.ForeColor = System.Drawing.Color.Black;
            this.lb_cpf_professor.Location = new System.Drawing.Point(226, 187);
            this.lb_cpf_professor.Name = "lb_cpf_professor";
            this.lb_cpf_professor.Size = new System.Drawing.Size(38, 22);
            this.lb_cpf_professor.TabIndex = 141;
            this.lb_cpf_professor.Text = "Cpf";
            // 
            // txt_sobrenome_professor
            // 
            this.txt_sobrenome_professor.Location = new System.Drawing.Point(227, 154);
            this.txt_sobrenome_professor.Multiline = true;
            this.txt_sobrenome_professor.Name = "txt_sobrenome_professor";
            this.txt_sobrenome_professor.Size = new System.Drawing.Size(141, 20);
            this.txt_sobrenome_professor.TabIndex = 140;
            this.txt_sobrenome_professor.TabStop = false;
            // 
            // lb_sobrenome_professor
            // 
            this.lb_sobrenome_professor.AutoSize = true;
            this.lb_sobrenome_professor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sobrenome_professor.ForeColor = System.Drawing.Color.Black;
            this.lb_sobrenome_professor.Location = new System.Drawing.Point(226, 129);
            this.lb_sobrenome_professor.Name = "lb_sobrenome_professor";
            this.lb_sobrenome_professor.Size = new System.Drawing.Size(102, 22);
            this.lb_sobrenome_professor.TabIndex = 139;
            this.lb_sobrenome_professor.Text = "Sobrenome";
            // 
            // txt_nome_professor
            // 
            this.txt_nome_professor.Location = new System.Drawing.Point(227, 106);
            this.txt_nome_professor.Multiline = true;
            this.txt_nome_professor.Name = "txt_nome_professor";
            this.txt_nome_professor.Size = new System.Drawing.Size(141, 20);
            this.txt_nome_professor.TabIndex = 138;
            this.txt_nome_professor.TabStop = false;
            // 
            // lb_nome_professor
            // 
            this.lb_nome_professor.AutoSize = true;
            this.lb_nome_professor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nome_professor.ForeColor = System.Drawing.Color.Black;
            this.lb_nome_professor.Location = new System.Drawing.Point(226, 81);
            this.lb_nome_professor.Name = "lb_nome_professor";
            this.lb_nome_professor.Size = new System.Drawing.Size(57, 22);
            this.lb_nome_professor.TabIndex = 137;
            this.lb_nome_professor.Text = "Nome";
            // 
            // img_perfil_aluno
            // 
            this.img_perfil_aluno.Location = new System.Drawing.Point(31, 43);
            this.img_perfil_aluno.Name = "img_perfil_aluno";
            this.img_perfil_aluno.Size = new System.Drawing.Size(185, 180);
            this.img_perfil_aluno.TabIndex = 134;
            this.img_perfil_aluno.TabStop = false;
            // 
            // lb_sede
            // 
            this.lb_sede.AutoSize = true;
            this.lb_sede.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_sede.ForeColor = System.Drawing.Color.Black;
            this.lb_sede.Location = new System.Drawing.Point(541, 131);
            this.lb_sede.Name = "lb_sede";
            this.lb_sede.Size = new System.Drawing.Size(52, 22);
            this.lb_sede.TabIndex = 173;
            this.lb_sede.Text = "Sede";
            // 
            // txt_senha_usuario
            // 
            this.txt_senha_usuario.Location = new System.Drawing.Point(404, 56);
            this.txt_senha_usuario.Multiline = true;
            this.txt_senha_usuario.Name = "txt_senha_usuario";
            this.txt_senha_usuario.PasswordChar = '*';
            this.txt_senha_usuario.Size = new System.Drawing.Size(98, 20);
            this.txt_senha_usuario.TabIndex = 182;
            this.txt_senha_usuario.TabStop = false;
            // 
            // lb_senha
            // 
            this.lb_senha.AutoSize = true;
            this.lb_senha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_senha.ForeColor = System.Drawing.Color.Black;
            this.lb_senha.Location = new System.Drawing.Point(403, 31);
            this.lb_senha.Name = "lb_senha";
            this.lb_senha.Size = new System.Drawing.Size(62, 22);
            this.lb_senha.TabIndex = 181;
            this.lb_senha.Text = "Senha";
            // 
            // lb_status
            // 
            this.lb_status.AutoSize = true;
            this.lb_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_status.ForeColor = System.Drawing.Color.Black;
            this.lb_status.Location = new System.Drawing.Point(400, 131);
            this.lb_status.Name = "lb_status";
            this.lb_status.Size = new System.Drawing.Size(61, 22);
            this.lb_status.TabIndex = 180;
            this.lb_status.Text = "Status";
            // 
            // cb_status
            // 
            this.cb_status.BackColor = System.Drawing.Color.White;
            this.cb_status.DropDownHeight = 200;
            this.cb_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_status.ForeColor = System.Drawing.Color.Black;
            this.cb_status.FormattingEnabled = true;
            this.cb_status.IntegralHeight = false;
            this.cb_status.ItemHeight = 16;
            this.cb_status.Items.AddRange(new object[] {
            "BLOQUEADO",
            "DESBLOQUEADO"});
            this.cb_status.Location = new System.Drawing.Point(404, 154);
            this.cb_status.Name = "cb_status";
            this.cb_status.Size = new System.Drawing.Size(98, 24);
            this.cb_status.TabIndex = 179;
            // 
            // lb_nivel_acesso
            // 
            this.lb_nivel_acesso.AutoSize = true;
            this.lb_nivel_acesso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nivel_acesso.ForeColor = System.Drawing.Color.Black;
            this.lb_nivel_acesso.Location = new System.Drawing.Point(400, 81);
            this.lb_nivel_acesso.Name = "lb_nivel_acesso";
            this.lb_nivel_acesso.Size = new System.Drawing.Size(114, 22);
            this.lb_nivel_acesso.TabIndex = 178;
            this.lb_nivel_acesso.Text = "Nível Acesso";
            // 
            // cb_nivel_acesso
            // 
            this.cb_nivel_acesso.BackColor = System.Drawing.Color.White;
            this.cb_nivel_acesso.DropDownHeight = 200;
            this.cb_nivel_acesso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_nivel_acesso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_nivel_acesso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_nivel_acesso.ForeColor = System.Drawing.Color.Black;
            this.cb_nivel_acesso.FormattingEnabled = true;
            this.cb_nivel_acesso.IntegralHeight = false;
            this.cb_nivel_acesso.ItemHeight = 16;
            this.cb_nivel_acesso.Items.AddRange(new object[] {
            "PROFESSOR",
            "ADMIN"});
            this.cb_nivel_acesso.Location = new System.Drawing.Point(404, 104);
            this.cb_nivel_acesso.Name = "cb_nivel_acesso";
            this.cb_nivel_acesso.Size = new System.Drawing.Size(98, 24);
            this.cb_nivel_acesso.TabIndex = 177;
            // 
            // dtp_cadastro_professor
            // 
            this.dtp_cadastro_professor.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtp_cadastro_professor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtp_cadastro_professor.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_cadastro_professor.Location = new System.Drawing.Point(28, 624);
            this.dtp_cadastro_professor.Name = "dtp_cadastro_professor";
            this.dtp_cadastro_professor.Size = new System.Drawing.Size(133, 27);
            this.dtp_cadastro_professor.TabIndex = 183;
            // 
            // cb_cod_instituicao
            // 
            this.cb_cod_instituicao.BackColor = System.Drawing.Color.White;
            this.cb_cod_instituicao.DropDownHeight = 200;
            this.cb_cod_instituicao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_cod_instituicao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_cod_instituicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_cod_instituicao.ForeColor = System.Drawing.Color.Black;
            this.cb_cod_instituicao.FormattingEnabled = true;
            this.cb_cod_instituicao.IntegralHeight = false;
            this.cb_cod_instituicao.ItemHeight = 16;
            this.cb_cod_instituicao.Location = new System.Drawing.Point(542, 52);
            this.cb_cod_instituicao.Name = "cb_cod_instituicao";
            this.cb_cod_instituicao.Size = new System.Drawing.Size(103, 24);
            this.cb_cod_instituicao.TabIndex = 185;
            // 
            // lb_cod_instituicao
            // 
            this.lb_cod_instituicao.AutoSize = true;
            this.lb_cod_instituicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_cod_instituicao.ForeColor = System.Drawing.Color.Black;
            this.lb_cod_instituicao.Location = new System.Drawing.Point(538, 31);
            this.lb_cod_instituicao.Name = "lb_cod_instituicao";
            this.lb_cod_instituicao.Size = new System.Drawing.Size(128, 22);
            this.lb_cod_instituicao.TabIndex = 184;
            this.lb_cod_instituicao.Text = "Cod Instituição";
            // 
            // cb_situacao
            // 
            this.cb_situacao.BackColor = System.Drawing.Color.White;
            this.cb_situacao.DropDownHeight = 200;
            this.cb_situacao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_situacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_situacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_situacao.ForeColor = System.Drawing.Color.Black;
            this.cb_situacao.FormattingEnabled = true;
            this.cb_situacao.IntegralHeight = false;
            this.cb_situacao.ItemHeight = 16;
            this.cb_situacao.Items.AddRange(new object[] {
            "DETERMINADO",
            "INDETERMINADO"});
            this.cb_situacao.Location = new System.Drawing.Point(542, 102);
            this.cb_situacao.Name = "cb_situacao";
            this.cb_situacao.Size = new System.Drawing.Size(103, 24);
            this.cb_situacao.TabIndex = 187;
            // 
            // lb_situacao
            // 
            this.lb_situacao.AutoSize = true;
            this.lb_situacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_situacao.ForeColor = System.Drawing.Color.Black;
            this.lb_situacao.Location = new System.Drawing.Point(538, 81);
            this.lb_situacao.Name = "lb_situacao";
            this.lb_situacao.Size = new System.Drawing.Size(80, 22);
            this.lb_situacao.TabIndex = 186;
            this.lb_situacao.Text = "Situação";
            // 
            // cb_sede_professor
            // 
            this.cb_sede_professor.BackColor = System.Drawing.Color.White;
            this.cb_sede_professor.DropDownHeight = 200;
            this.cb_sede_professor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_sede_professor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_sede_professor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_sede_professor.ForeColor = System.Drawing.Color.Black;
            this.cb_sede_professor.FormattingEnabled = true;
            this.cb_sede_professor.IntegralHeight = false;
            this.cb_sede_professor.ItemHeight = 16;
            this.cb_sede_professor.Location = new System.Drawing.Point(542, 156);
            this.cb_sede_professor.Name = "cb_sede_professor";
            this.cb_sede_professor.Size = new System.Drawing.Size(103, 24);
            this.cb_sede_professor.TabIndex = 188;
            // 
            // lb_id_curso
            // 
            this.lb_id_curso.AutoSize = true;
            this.lb_id_curso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_id_curso.ForeColor = System.Drawing.Color.Black;
            this.lb_id_curso.Location = new System.Drawing.Point(27, 290);
            this.lb_id_curso.Name = "lb_id_curso";
            this.lb_id_curso.Size = new System.Drawing.Size(63, 22);
            this.lb_id_curso.TabIndex = 190;
            this.lb_id_curso.Text = "Curso ";
            // 
            // cb_curso
            // 
            this.cb_curso.BackColor = System.Drawing.Color.White;
            this.cb_curso.DropDownHeight = 200;
            this.cb_curso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_curso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_curso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_curso.ForeColor = System.Drawing.Color.Black;
            this.cb_curso.FormattingEnabled = true;
            this.cb_curso.IntegralHeight = false;
            this.cb_curso.ItemHeight = 16;
            this.cb_curso.Location = new System.Drawing.Point(31, 313);
            this.cb_curso.Name = "cb_curso";
            this.cb_curso.Size = new System.Drawing.Size(98, 24);
            this.cb_curso.TabIndex = 189;
            // 
            // lb_situacao_curso
            // 
            this.lb_situacao_curso.AutoSize = true;
            this.lb_situacao_curso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_situacao_curso.ForeColor = System.Drawing.Color.Black;
            this.lb_situacao_curso.Location = new System.Drawing.Point(149, 290);
            this.lb_situacao_curso.Name = "lb_situacao_curso";
            this.lb_situacao_curso.Size = new System.Drawing.Size(80, 22);
            this.lb_situacao_curso.TabIndex = 192;
            this.lb_situacao_curso.Text = "Situação";
            // 
            // cb_situacao_curso
            // 
            this.cb_situacao_curso.BackColor = System.Drawing.Color.White;
            this.cb_situacao_curso.DropDownHeight = 200;
            this.cb_situacao_curso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_situacao_curso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_situacao_curso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_situacao_curso.ForeColor = System.Drawing.Color.Black;
            this.cb_situacao_curso.FormattingEnabled = true;
            this.cb_situacao_curso.IntegralHeight = false;
            this.cb_situacao_curso.ItemHeight = 16;
            this.cb_situacao_curso.Items.AddRange(new object[] {
            "DETERMINADO",
            "INDETERMINADO"});
            this.cb_situacao_curso.Location = new System.Drawing.Point(153, 313);
            this.cb_situacao_curso.Name = "cb_situacao_curso";
            this.cb_situacao_curso.Size = new System.Drawing.Size(98, 24);
            this.cb_situacao_curso.TabIndex = 191;
            // 
            // btn_excluir
            // 
            this.btn_excluir.BackColor = System.Drawing.Color.Crimson;
            this.btn_excluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_excluir.FlatAppearance.BorderSize = 0;
            this.btn_excluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_excluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_excluir.ForeColor = System.Drawing.Color.White;
            this.btn_excluir.Location = new System.Drawing.Point(483, 611);
            this.btn_excluir.Name = "btn_excluir";
            this.btn_excluir.Size = new System.Drawing.Size(90, 40);
            this.btn_excluir.TabIndex = 196;
            this.btn_excluir.Text = "Excluir";
            this.btn_excluir.UseVisualStyleBackColor = false;
            this.btn_excluir.Click += new System.EventHandler(this.btn_excluir_Click);
            // 
            // btn_alterar
            // 
            this.btn_alterar.BackColor = System.Drawing.Color.BurlyWood;
            this.btn_alterar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_alterar.FlatAppearance.BorderSize = 0;
            this.btn_alterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_alterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_alterar.ForeColor = System.Drawing.Color.White;
            this.btn_alterar.Location = new System.Drawing.Point(579, 611);
            this.btn_alterar.Name = "btn_alterar";
            this.btn_alterar.Size = new System.Drawing.Size(90, 40);
            this.btn_alterar.TabIndex = 195;
            this.btn_alterar.Text = "Alterar";
            this.btn_alterar.UseVisualStyleBackColor = false;
            this.btn_alterar.Click += new System.EventHandler(this.btn_alterar_Click);
            // 
            // F_CadProfessor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 682);
            this.Controls.Add(this.btn_excluir);
            this.Controls.Add(this.btn_alterar);
            this.Controls.Add(this.lb_situacao_curso);
            this.Controls.Add(this.cb_situacao_curso);
            this.Controls.Add(this.lb_id_curso);
            this.Controls.Add(this.cb_curso);
            this.Controls.Add(this.cb_sede_professor);
            this.Controls.Add(this.cb_situacao);
            this.Controls.Add(this.lb_situacao);
            this.Controls.Add(this.cb_cod_instituicao);
            this.Controls.Add(this.lb_cod_instituicao);
            this.Controls.Add(this.dtp_cadastro_professor);
            this.Controls.Add(this.txt_senha_usuario);
            this.Controls.Add(this.lb_senha);
            this.Controls.Add(this.lb_status);
            this.Controls.Add(this.cb_status);
            this.Controls.Add(this.lb_nivel_acesso);
            this.Controls.Add(this.cb_nivel_acesso);
            this.Controls.Add(this.lb_sede);
            this.Controls.Add(this.lb_rm_professor);
            this.Controls.Add(this.nud_rm_professor);
            this.Controls.Add(this.btn_cadastrar);
            this.Controls.Add(this.txt_email_professor);
            this.Controls.Add(this.lb_email_professor);
            this.Controls.Add(this.txt_celular_professor);
            this.Controls.Add(this.lb_celular_professor);
            this.Controls.Add(this.txt_telefone_professor);
            this.Controls.Add(this.lb_telefone_professor);
            this.Controls.Add(this.txt_complemento_professor);
            this.Controls.Add(this.lb_complemento_aluno);
            this.Controls.Add(this.lb_cidade_professor);
            this.Controls.Add(this.cb_cidade_professor);
            this.Controls.Add(this.txt_bairro_professor);
            this.Controls.Add(this.lb_bairro_professor);
            this.Controls.Add(this.txt_numero_residencia_professor);
            this.Controls.Add(this.lb_numero_residencia_professor);
            this.Controls.Add(this.txt_logradouro_professor);
            this.Controls.Add(this.lb_logradouro_professor);
            this.Controls.Add(this.txt_cep_professor);
            this.Controls.Add(this.lb_cep_professor);
            this.Controls.Add(this.lb_data_cadastro_professor);
            this.Controls.Add(this.lb_sexo_professor);
            this.Controls.Add(this.cb_sexo_professor);
            this.Controls.Add(this.txt_cpf_professor);
            this.Controls.Add(this.lb_cpf_professor);
            this.Controls.Add(this.txt_sobrenome_professor);
            this.Controls.Add(this.lb_sobrenome_professor);
            this.Controls.Add(this.txt_nome_professor);
            this.Controls.Add(this.lb_nome_professor);
            this.Controls.Add(this.img_perfil_aluno);
            this.Name = "F_CadProfessor";
            this.Text = "Cadastro Professor";
            this.Load += new System.EventHandler(this.F_CadProfessor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_rm_professor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.img_perfil_aluno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_rm_professor;
        private System.Windows.Forms.NumericUpDown nud_rm_professor;
        private System.Windows.Forms.Button btn_cadastrar;
        private System.Windows.Forms.TextBox txt_email_professor;
        private System.Windows.Forms.Label lb_email_professor;
        private System.Windows.Forms.TextBox txt_celular_professor;
        private System.Windows.Forms.Label lb_celular_professor;
        private System.Windows.Forms.TextBox txt_telefone_professor;
        private System.Windows.Forms.Label lb_telefone_professor;
        private System.Windows.Forms.TextBox txt_complemento_professor;
        private System.Windows.Forms.Label lb_complemento_aluno;
        private System.Windows.Forms.Label lb_cidade_professor;
        private System.Windows.Forms.ComboBox cb_cidade_professor;
        private System.Windows.Forms.TextBox txt_bairro_professor;
        private System.Windows.Forms.Label lb_bairro_professor;
        private System.Windows.Forms.TextBox txt_numero_residencia_professor;
        private System.Windows.Forms.Label lb_numero_residencia_professor;
        private System.Windows.Forms.TextBox txt_logradouro_professor;
        private System.Windows.Forms.Label lb_logradouro_professor;
        private System.Windows.Forms.TextBox txt_cep_professor;
        private System.Windows.Forms.Label lb_cep_professor;
        private System.Windows.Forms.Label lb_data_cadastro_professor;
        private System.Windows.Forms.Label lb_sexo_professor;
        private System.Windows.Forms.ComboBox cb_sexo_professor;
        private System.Windows.Forms.TextBox txt_cpf_professor;
        private System.Windows.Forms.Label lb_cpf_professor;
        private System.Windows.Forms.TextBox txt_sobrenome_professor;
        private System.Windows.Forms.Label lb_sobrenome_professor;
        private System.Windows.Forms.TextBox txt_nome_professor;
        private System.Windows.Forms.Label lb_nome_professor;
        private System.Windows.Forms.PictureBox img_perfil_aluno;
        private System.Windows.Forms.Label lb_sede;
        private System.Windows.Forms.TextBox txt_senha_usuario;
        private System.Windows.Forms.Label lb_senha;
        private System.Windows.Forms.Label lb_status;
        private System.Windows.Forms.ComboBox cb_status;
        private System.Windows.Forms.Label lb_nivel_acesso;
        private System.Windows.Forms.ComboBox cb_nivel_acesso;
        private System.Windows.Forms.DateTimePicker dtp_cadastro_professor;
        private System.Windows.Forms.ComboBox cb_cod_instituicao;
        private System.Windows.Forms.Label lb_cod_instituicao;
        private System.Windows.Forms.ComboBox cb_situacao;
        private System.Windows.Forms.Label lb_situacao;
        private System.Windows.Forms.ComboBox cb_sede_professor;
        private System.Windows.Forms.Label lb_id_curso;
        private System.Windows.Forms.ComboBox cb_curso;
        private System.Windows.Forms.Label lb_situacao_curso;
        private System.Windows.Forms.ComboBox cb_situacao_curso;
        private System.Windows.Forms.Button btn_excluir;
        private System.Windows.Forms.Button btn_alterar;
    }
}