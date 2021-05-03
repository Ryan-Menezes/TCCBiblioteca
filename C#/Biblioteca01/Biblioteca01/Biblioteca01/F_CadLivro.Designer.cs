namespace Biblioteca01
{
    partial class F_CadLivro
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
            this.dtp_insercao = new System.Windows.Forms.DateTimePicker();
            this.lb_insercao = new System.Windows.Forms.Label();
            this.lb_tombo = new System.Windows.Forms.Label();
            this.txt_titulo = new System.Windows.Forms.TextBox();
            this.dtp_ano_publicacao = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lb_titulo = new System.Windows.Forms.Label();
            this.nud_exemplares = new System.Windows.Forms.NumericUpDown();
            this.nud_edicao = new System.Windows.Forms.NumericUpDown();
            this.nud_volume = new System.Windows.Forms.NumericUpDown();
            this.txt_isbn = new System.Windows.Forms.TextBox();
            this.txt_colaboradores = new System.Windows.Forms.TextBox();
            this.cb_idioma = new System.Windows.Forms.ComboBox();
            this.cb_autor = new System.Windows.Forms.ComboBox();
            this.lb_colaborador = new System.Windows.Forms.Label();
            this.cb_editora = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_cadastro_editora = new System.Windows.Forms.Button();
            this.btn_cadastro_autor = new System.Windows.Forms.Button();
            this.lb_genero = new System.Windows.Forms.Label();
            this.cb_genero = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.lbIdioma = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lb_volume = new System.Windows.Forms.Label();
            this.lb_edicao = new System.Windows.Forms.Label();
            this.btn_excluir = new System.Windows.Forms.Button();
            this.btn_alterar = new System.Windows.Forms.Button();
            this.btn_cadastrar = new System.Windows.Forms.Button();
            this.btn_cadastro_genero = new System.Windows.Forms.Button();
            this.lb_id_instituicao = new System.Windows.Forms.Label();
            this.cb_id_instituicao = new System.Windows.Forms.ComboBox();
            this.nud_tombo = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nud_exemplares)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_edicao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_volume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_tombo)).BeginInit();
            this.SuspendLayout();
            // 
            // dtp_insercao
            // 
            this.dtp_insercao.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtp_insercao.CustomFormat = "";
            this.dtp_insercao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtp_insercao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_insercao.Location = new System.Drawing.Point(27, 309);
            this.dtp_insercao.Name = "dtp_insercao";
            this.dtp_insercao.Size = new System.Drawing.Size(161, 27);
            this.dtp_insercao.TabIndex = 68;
            // 
            // lb_insercao
            // 
            this.lb_insercao.AutoSize = true;
            this.lb_insercao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_insercao.ForeColor = System.Drawing.Color.Black;
            this.lb_insercao.Location = new System.Drawing.Point(23, 277);
            this.lb_insercao.Name = "lb_insercao";
            this.lb_insercao.Size = new System.Drawing.Size(126, 22);
            this.lb_insercao.TabIndex = 67;
            this.lb_insercao.Text = "Data Inserção:";
            // 
            // lb_tombo
            // 
            this.lb_tombo.AutoSize = true;
            this.lb_tombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tombo.ForeColor = System.Drawing.Color.Black;
            this.lb_tombo.Location = new System.Drawing.Point(27, 85);
            this.lb_tombo.Name = "lb_tombo";
            this.lb_tombo.Size = new System.Drawing.Size(71, 22);
            this.lb_tombo.TabIndex = 65;
            this.lb_tombo.Text = "Tombo:";
            // 
            // txt_titulo
            // 
            this.txt_titulo.Location = new System.Drawing.Point(27, 166);
            this.txt_titulo.Multiline = true;
            this.txt_titulo.Name = "txt_titulo";
            this.txt_titulo.Size = new System.Drawing.Size(400, 20);
            this.txt_titulo.TabIndex = 64;
            // 
            // dtp_ano_publicacao
            // 
            this.dtp_ano_publicacao.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtp_ano_publicacao.CustomFormat = "";
            this.dtp_ano_publicacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtp_ano_publicacao.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_ano_publicacao.Location = new System.Drawing.Point(27, 231);
            this.dtp_ano_publicacao.Name = "dtp_ano_publicacao";
            this.dtp_ano_publicacao.Size = new System.Drawing.Size(161, 27);
            this.dtp_ano_publicacao.TabIndex = 63;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(23, 199);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 22);
            this.label3.TabIndex = 62;
            this.label3.Text = "Ano de Publicação:";
            // 
            // lb_titulo
            // 
            this.lb_titulo.AutoSize = true;
            this.lb_titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_titulo.ForeColor = System.Drawing.Color.Black;
            this.lb_titulo.Location = new System.Drawing.Point(23, 143);
            this.lb_titulo.Name = "lb_titulo";
            this.lb_titulo.Size = new System.Drawing.Size(60, 22);
            this.lb_titulo.TabIndex = 69;
            this.lb_titulo.Text = "Titulo:";
            // 
            // nud_exemplares
            // 
            this.nud_exemplares.Location = new System.Drawing.Point(27, 515);
            this.nud_exemplares.Name = "nud_exemplares";
            this.nud_exemplares.Size = new System.Drawing.Size(105, 20);
            this.nud_exemplares.TabIndex = 92;
            // 
            // nud_edicao
            // 
            this.nud_edicao.Location = new System.Drawing.Point(27, 457);
            this.nud_edicao.Name = "nud_edicao";
            this.nud_edicao.Size = new System.Drawing.Size(71, 20);
            this.nud_edicao.TabIndex = 91;
            // 
            // nud_volume
            // 
            this.nud_volume.Location = new System.Drawing.Point(27, 387);
            this.nud_volume.Name = "nud_volume";
            this.nud_volume.Size = new System.Drawing.Size(71, 20);
            this.nud_volume.TabIndex = 90;
            // 
            // txt_isbn
            // 
            this.txt_isbn.Location = new System.Drawing.Point(146, 108);
            this.txt_isbn.Name = "txt_isbn";
            this.txt_isbn.Size = new System.Drawing.Size(281, 20);
            this.txt_isbn.TabIndex = 89;
            // 
            // txt_colaboradores
            // 
            this.txt_colaboradores.Location = new System.Drawing.Point(485, 473);
            this.txt_colaboradores.Name = "txt_colaboradores";
            this.txt_colaboradores.Size = new System.Drawing.Size(267, 20);
            this.txt_colaboradores.TabIndex = 88;
            // 
            // cb_idioma
            // 
            this.cb_idioma.BackColor = System.Drawing.Color.White;
            this.cb_idioma.DropDownHeight = 200;
            this.cb_idioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_idioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_idioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_idioma.ForeColor = System.Drawing.Color.Black;
            this.cb_idioma.FormattingEnabled = true;
            this.cb_idioma.IntegralHeight = false;
            this.cb_idioma.ItemHeight = 16;
            this.cb_idioma.Items.AddRange(new object[] {
            "Africâner ",
            "Aimará ",
            "Albanês ",
            "Alemão ",
            "Árabe ",
            "Arménio ",
            "Azeri ",
            "Bielorrusso ",
            "Bengali ",
            "Bislama ",
            "Bósnio ",
            "Búlgaro ",
            "Cazaque ",
            "Catalão ",
            "Checo ",
            "Chinês Mandarim ",
            "Coreano ",
            "Croata ",
            "Curdo ",
            "Dinamarquês  ",
            "Dari ",
            "Dhiveli ",
            "Dzongkha ",
            "Eslovaco ",
            "Espanhol ",
            "Estoniano ",
            "Fijiano",
            "Filipino ",
            "Finlandês ",
            "Frísio ",
            "Georgiano ",
            "Grego ",
            "Guarani ",
            "Hebreu ",
            "Hindi",
            "Hiri motu ",
            "Holandês ",
            "Húngaro ",
            "Indonésio ",
            "Inglês",
            "Irlandês ",
            "Italiano ",
            "Japonês ",
            "Canará ",
            "Khmer ",
            "Laociano",
            "Latim ",
            "Letão ",
            "Lituano ",
            "Macedônio ",
            "Malaio ",
            "Malaiala ",
            "Maori ",
            "Marata ",
            "Moldávio ",
            "Mongol ",
            "Ndebele ",
            "Nepalês ",
            "Sotho setentrional",
            "Norueguês ",
            "Oriá ",
            "Pachto ",
            "Persa ",
            "Polonês ",
            "Português ",
            "Punjabi ",
            "Quíchua ",
            "Quirguiz ",
            "Romeno ",
            "Romanche ",
            "Russo ",
            "Sérvio ",
            "Cingalês ",
            "Somali ",
            "Sueco ",
            "Tajique ",
            "Tâmil ",
            "Tétum ",
            "Tsonga",
            "Tswana ",
            "Turco ",
            "Turcomeno",
            "Ucraniano ",
            "Uzbeque ",
            "Venda ",
            "Vietnamita ",
            "Xhosa ",
            "Zulu "});
            this.cb_idioma.Location = new System.Drawing.Point(485, 231);
            this.cb_idioma.Name = "cb_idioma";
            this.cb_idioma.Size = new System.Drawing.Size(267, 24);
            this.cb_idioma.TabIndex = 85;
            // 
            // cb_autor
            // 
            this.cb_autor.BackColor = System.Drawing.Color.White;
            this.cb_autor.DropDownHeight = 200;
            this.cb_autor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_autor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_autor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_autor.ForeColor = System.Drawing.Color.Black;
            this.cb_autor.FormattingEnabled = true;
            this.cb_autor.IntegralHeight = false;
            this.cb_autor.ItemHeight = 16;
            this.cb_autor.Location = new System.Drawing.Point(485, 422);
            this.cb_autor.Name = "cb_autor";
            this.cb_autor.Size = new System.Drawing.Size(267, 24);
            this.cb_autor.TabIndex = 84;
            // 
            // lb_colaborador
            // 
            this.lb_colaborador.AutoSize = true;
            this.lb_colaborador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_colaborador.ForeColor = System.Drawing.Color.Black;
            this.lb_colaborador.Location = new System.Drawing.Point(481, 448);
            this.lb_colaborador.Name = "lb_colaborador";
            this.lb_colaborador.Size = new System.Drawing.Size(133, 22);
            this.lb_colaborador.TabIndex = 86;
            this.lb_colaborador.Text = "Colaboradores:";
            // 
            // cb_editora
            // 
            this.cb_editora.BackColor = System.Drawing.Color.White;
            this.cb_editora.DropDownHeight = 200;
            this.cb_editora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_editora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_editora.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_editora.ForeColor = System.Drawing.Color.Black;
            this.cb_editora.FormattingEnabled = true;
            this.cb_editora.IntegralHeight = false;
            this.cb_editora.ItemHeight = 16;
            this.cb_editora.Location = new System.Drawing.Point(485, 351);
            this.cb_editora.Name = "cb_editora";
            this.cb_editora.Size = new System.Drawing.Size(267, 24);
            this.cb_editora.TabIndex = 83;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(23, 490);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 22);
            this.label5.TabIndex = 81;
            this.label5.Text = "Exemplares:";
            // 
            // btn_cadastro_editora
            // 
            this.btn_cadastro_editora.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(135)))), ((int)(((byte)(245)))));
            this.btn_cadastro_editora.FlatAppearance.BorderSize = 0;
            this.btn_cadastro_editora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadastro_editora.ForeColor = System.Drawing.Color.White;
            this.btn_cadastro_editora.Location = new System.Drawing.Point(751, 351);
            this.btn_cadastro_editora.Name = "btn_cadastro_editora";
            this.btn_cadastro_editora.Size = new System.Drawing.Size(30, 23);
            this.btn_cadastro_editora.TabIndex = 79;
            this.btn_cadastro_editora.Text = "...";
            this.btn_cadastro_editora.UseVisualStyleBackColor = false;
            this.btn_cadastro_editora.Click += new System.EventHandler(this.btn_cadastro_editora_Click);
            // 
            // btn_cadastro_autor
            // 
            this.btn_cadastro_autor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(135)))), ((int)(((byte)(245)))));
            this.btn_cadastro_autor.FlatAppearance.BorderSize = 0;
            this.btn_cadastro_autor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadastro_autor.ForeColor = System.Drawing.Color.White;
            this.btn_cadastro_autor.Location = new System.Drawing.Point(751, 422);
            this.btn_cadastro_autor.Name = "btn_cadastro_autor";
            this.btn_cadastro_autor.Size = new System.Drawing.Size(30, 23);
            this.btn_cadastro_autor.TabIndex = 78;
            this.btn_cadastro_autor.Text = "...";
            this.btn_cadastro_autor.UseVisualStyleBackColor = false;
            this.btn_cadastro_autor.Click += new System.EventHandler(this.btn_cadastro_autor_Click);
            // 
            // lb_genero
            // 
            this.lb_genero.AutoSize = true;
            this.lb_genero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_genero.ForeColor = System.Drawing.Color.Black;
            this.lb_genero.Location = new System.Drawing.Point(481, 256);
            this.lb_genero.Name = "lb_genero";
            this.lb_genero.Size = new System.Drawing.Size(75, 22);
            this.lb_genero.TabIndex = 77;
            this.lb_genero.Text = "Gênero:";
            // 
            // cb_genero
            // 
            this.cb_genero.BackColor = System.Drawing.Color.White;
            this.cb_genero.DropDownHeight = 200;
            this.cb_genero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_genero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_genero.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_genero.ForeColor = System.Drawing.Color.Black;
            this.cb_genero.FormattingEnabled = true;
            this.cb_genero.IntegralHeight = false;
            this.cb_genero.ItemHeight = 16;
            this.cb_genero.Location = new System.Drawing.Point(485, 288);
            this.cb_genero.Name = "cb_genero";
            this.cb_genero.Size = new System.Drawing.Size(267, 24);
            this.cb_genero.TabIndex = 76;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(481, 388);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 22);
            this.label13.TabIndex = 75;
            this.label13.Text = "Autor:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(481, 316);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 22);
            this.label11.TabIndex = 74;
            this.label11.Text = "Editora:";
            // 
            // lbIdioma
            // 
            this.lbIdioma.AutoSize = true;
            this.lbIdioma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIdioma.ForeColor = System.Drawing.Color.Black;
            this.lbIdioma.Location = new System.Drawing.Point(481, 198);
            this.lbIdioma.Name = "lbIdioma";
            this.lbIdioma.Size = new System.Drawing.Size(62, 22);
            this.lbIdioma.TabIndex = 73;
            this.lbIdioma.Text = "Idioma";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(142, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 22);
            this.label10.TabIndex = 72;
            this.label10.Text = "ISBN:";
            // 
            // lb_volume
            // 
            this.lb_volume.AutoSize = true;
            this.lb_volume.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_volume.ForeColor = System.Drawing.Color.Black;
            this.lb_volume.Location = new System.Drawing.Point(23, 349);
            this.lb_volume.Name = "lb_volume";
            this.lb_volume.Size = new System.Drawing.Size(75, 22);
            this.lb_volume.TabIndex = 71;
            this.lb_volume.Text = "Volume:";
            // 
            // lb_edicao
            // 
            this.lb_edicao.AutoSize = true;
            this.lb_edicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_edicao.ForeColor = System.Drawing.Color.Black;
            this.lb_edicao.Location = new System.Drawing.Point(23, 419);
            this.lb_edicao.Name = "lb_edicao";
            this.lb_edicao.Size = new System.Drawing.Size(65, 22);
            this.lb_edicao.TabIndex = 70;
            this.lb_edicao.Text = "Edição";
            // 
            // btn_excluir
            // 
            this.btn_excluir.BackColor = System.Drawing.Color.Crimson;
            this.btn_excluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_excluir.FlatAppearance.BorderSize = 0;
            this.btn_excluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_excluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_excluir.ForeColor = System.Drawing.Color.White;
            this.btn_excluir.Location = new System.Drawing.Point(470, 579);
            this.btn_excluir.Name = "btn_excluir";
            this.btn_excluir.Size = new System.Drawing.Size(90, 40);
            this.btn_excluir.TabIndex = 95;
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
            this.btn_alterar.Location = new System.Drawing.Point(590, 579);
            this.btn_alterar.Name = "btn_alterar";
            this.btn_alterar.Size = new System.Drawing.Size(90, 40);
            this.btn_alterar.TabIndex = 94;
            this.btn_alterar.Text = "Alterar";
            this.btn_alterar.UseVisualStyleBackColor = false;
            this.btn_alterar.Click += new System.EventHandler(this.btn_alterar_Click);
            // 
            // btn_cadastrar
            // 
            this.btn_cadastrar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_cadastrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cadastrar.FlatAppearance.BorderSize = 0;
            this.btn_cadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_cadastrar.ForeColor = System.Drawing.Color.White;
            this.btn_cadastrar.Location = new System.Drawing.Point(703, 579);
            this.btn_cadastrar.Name = "btn_cadastrar";
            this.btn_cadastrar.Size = new System.Drawing.Size(90, 40);
            this.btn_cadastrar.TabIndex = 93;
            this.btn_cadastrar.Text = "Cadastrar";
            this.btn_cadastrar.UseVisualStyleBackColor = false;
            this.btn_cadastrar.Click += new System.EventHandler(this.btn_cadastrar_Click);
            // 
            // btn_cadastro_genero
            // 
            this.btn_cadastro_genero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(135)))), ((int)(((byte)(245)))));
            this.btn_cadastro_genero.FlatAppearance.BorderSize = 0;
            this.btn_cadastro_genero.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadastro_genero.ForeColor = System.Drawing.Color.White;
            this.btn_cadastro_genero.Location = new System.Drawing.Point(751, 288);
            this.btn_cadastro_genero.Name = "btn_cadastro_genero";
            this.btn_cadastro_genero.Size = new System.Drawing.Size(30, 23);
            this.btn_cadastro_genero.TabIndex = 96;
            this.btn_cadastro_genero.Text = "...";
            this.btn_cadastro_genero.UseVisualStyleBackColor = false;
            this.btn_cadastro_genero.Click += new System.EventHandler(this.btn_cadastro_genero_Click);
            // 
            // lb_id_instituicao
            // 
            this.lb_id_instituicao.AutoSize = true;
            this.lb_id_instituicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_id_instituicao.ForeColor = System.Drawing.Color.Black;
            this.lb_id_instituicao.Location = new System.Drawing.Point(173, 490);
            this.lb_id_instituicao.Name = "lb_id_instituicao";
            this.lb_id_instituicao.Size = new System.Drawing.Size(109, 22);
            this.lb_id_instituicao.TabIndex = 97;
            this.lb_id_instituicao.Text = "Id Instituição";
            // 
            // cb_id_instituicao
            // 
            this.cb_id_instituicao.BackColor = System.Drawing.Color.White;
            this.cb_id_instituicao.DropDownHeight = 200;
            this.cb_id_instituicao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_id_instituicao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_id_instituicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_id_instituicao.ForeColor = System.Drawing.Color.Black;
            this.cb_id_instituicao.FormattingEnabled = true;
            this.cb_id_instituicao.IntegralHeight = false;
            this.cb_id_instituicao.ItemHeight = 16;
            this.cb_id_instituicao.Location = new System.Drawing.Point(177, 515);
            this.cb_id_instituicao.Name = "cb_id_instituicao";
            this.cb_id_instituicao.Size = new System.Drawing.Size(86, 24);
            this.cb_id_instituicao.TabIndex = 98;
            // 
            // nud_tombo
            // 
            this.nud_tombo.Location = new System.Drawing.Point(31, 108);
            this.nud_tombo.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nud_tombo.Name = "nud_tombo";
            this.nud_tombo.Size = new System.Drawing.Size(71, 20);
            this.nud_tombo.TabIndex = 99;
            // 
            // F_CadLivro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 631);
            this.Controls.Add(this.nud_tombo);
            this.Controls.Add(this.cb_id_instituicao);
            this.Controls.Add(this.lb_id_instituicao);
            this.Controls.Add(this.btn_cadastro_genero);
            this.Controls.Add(this.btn_excluir);
            this.Controls.Add(this.btn_alterar);
            this.Controls.Add(this.btn_cadastrar);
            this.Controls.Add(this.nud_exemplares);
            this.Controls.Add(this.nud_edicao);
            this.Controls.Add(this.nud_volume);
            this.Controls.Add(this.txt_isbn);
            this.Controls.Add(this.txt_colaboradores);
            this.Controls.Add(this.cb_idioma);
            this.Controls.Add(this.cb_autor);
            this.Controls.Add(this.lb_colaborador);
            this.Controls.Add(this.cb_editora);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btn_cadastro_editora);
            this.Controls.Add(this.btn_cadastro_autor);
            this.Controls.Add(this.lb_genero);
            this.Controls.Add(this.cb_genero);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbIdioma);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lb_volume);
            this.Controls.Add(this.lb_edicao);
            this.Controls.Add(this.lb_titulo);
            this.Controls.Add(this.dtp_insercao);
            this.Controls.Add(this.lb_insercao);
            this.Controls.Add(this.lb_tombo);
            this.Controls.Add(this.txt_titulo);
            this.Controls.Add(this.dtp_ano_publicacao);
            this.Controls.Add(this.label3);
            this.Name = "F_CadLivro";
            this.Text = "Livro";
            this.Load += new System.EventHandler(this.F_CadLivro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_exemplares)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_edicao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_volume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_tombo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_insercao;
        private System.Windows.Forms.Label lb_insercao;
        private System.Windows.Forms.Label lb_tombo;
        private System.Windows.Forms.TextBox txt_titulo;
        private System.Windows.Forms.DateTimePicker dtp_ano_publicacao;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lb_titulo;
        private System.Windows.Forms.NumericUpDown nud_exemplares;
        private System.Windows.Forms.NumericUpDown nud_edicao;
        private System.Windows.Forms.NumericUpDown nud_volume;
        private System.Windows.Forms.TextBox txt_isbn;
        private System.Windows.Forms.TextBox txt_colaboradores;
        private System.Windows.Forms.ComboBox cb_idioma;
        private System.Windows.Forms.ComboBox cb_autor;
        private System.Windows.Forms.Label lb_colaborador;
        private System.Windows.Forms.ComboBox cb_editora;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_cadastro_editora;
        private System.Windows.Forms.Button btn_cadastro_autor;
        private System.Windows.Forms.Label lb_genero;
        private System.Windows.Forms.ComboBox cb_genero;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbIdioma;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lb_volume;
        private System.Windows.Forms.Label lb_edicao;
        private System.Windows.Forms.Button btn_excluir;
        private System.Windows.Forms.Button btn_alterar;
        private System.Windows.Forms.Button btn_cadastrar;
        private System.Windows.Forms.Button btn_cadastro_genero;
        private System.Windows.Forms.Label lb_id_instituicao;
        private System.Windows.Forms.ComboBox cb_id_instituicao;
        private System.Windows.Forms.NumericUpDown nud_tombo;
    }
}