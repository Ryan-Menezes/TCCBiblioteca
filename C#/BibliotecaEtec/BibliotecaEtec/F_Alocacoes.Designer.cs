namespace BibliotecaEtec
{
    partial class F_Alocacoes
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_relatorio = new FontAwesome.Sharp.IconButton();
            this.btn_filtro = new FontAwesome.Sharp.IconButton();
            this.btn_alocacao = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_visualizar = new FontAwesome.Sharp.IconButton();
            this.tb_pesquisa = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgv_alocacoes = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.img_loading = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_carregarMais = new FontAwesome.Sharp.IconButton();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_alocacoes)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_loading)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.btn_relatorio);
            this.panel3.Controls.Add(this.btn_filtro);
            this.panel3.Controls.Add(this.btn_alocacao);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1219, 535);
            this.panel3.TabIndex = 22;
            // 
            // btn_relatorio
            // 
            this.btn_relatorio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_relatorio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(135)))), ((int)(((byte)(245)))));
            this.btn_relatorio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_relatorio.FlatAppearance.BorderSize = 0;
            this.btn_relatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_relatorio.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btn_relatorio.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_relatorio.ForeColor = System.Drawing.Color.White;
            this.btn_relatorio.IconChar = FontAwesome.Sharp.IconChar.FileExport;
            this.btn_relatorio.IconColor = System.Drawing.Color.White;
            this.btn_relatorio.IconSize = 20;
            this.btn_relatorio.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_relatorio.Location = new System.Drawing.Point(708, 53);
            this.btn_relatorio.Name = "btn_relatorio";
            this.btn_relatorio.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btn_relatorio.Rotation = 0D;
            this.btn_relatorio.Size = new System.Drawing.Size(154, 35);
            this.btn_relatorio.TabIndex = 28;
            this.btn_relatorio.Text = "Emitir Relatório";
            this.btn_relatorio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_relatorio.UseVisualStyleBackColor = false;
            this.btn_relatorio.Click += new System.EventHandler(this.btn_relatorio_Click);
            // 
            // btn_filtro
            // 
            this.btn_filtro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_filtro.BackColor = System.Drawing.Color.Maroon;
            this.btn_filtro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_filtro.FlatAppearance.BorderSize = 0;
            this.btn_filtro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_filtro.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btn_filtro.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_filtro.ForeColor = System.Drawing.Color.White;
            this.btn_filtro.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btn_filtro.IconColor = System.Drawing.Color.White;
            this.btn_filtro.IconSize = 20;
            this.btn_filtro.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_filtro.Location = new System.Drawing.Point(1028, 53);
            this.btn_filtro.Name = "btn_filtro";
            this.btn_filtro.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btn_filtro.Rotation = 0D;
            this.btn_filtro.Size = new System.Drawing.Size(154, 35);
            this.btn_filtro.TabIndex = 27;
            this.btn_filtro.Text = "Selecionar Filtro";
            this.btn_filtro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_filtro.UseVisualStyleBackColor = false;
            this.btn_filtro.Click += new System.EventHandler(this.btn_filtro_Click);
            // 
            // btn_alocacao
            // 
            this.btn_alocacao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_alocacao.BackColor = System.Drawing.Color.Olive;
            this.btn_alocacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_alocacao.FlatAppearance.BorderSize = 0;
            this.btn_alocacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_alocacao.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btn_alocacao.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_alocacao.ForeColor = System.Drawing.Color.White;
            this.btn_alocacao.IconChar = FontAwesome.Sharp.IconChar.Book;
            this.btn_alocacao.IconColor = System.Drawing.Color.White;
            this.btn_alocacao.IconSize = 20;
            this.btn_alocacao.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_alocacao.Location = new System.Drawing.Point(868, 53);
            this.btn_alocacao.Name = "btn_alocacao";
            this.btn_alocacao.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btn_alocacao.Rotation = 0D;
            this.btn_alocacao.Size = new System.Drawing.Size(154, 35);
            this.btn_alocacao.TabIndex = 24;
            this.btn_alocacao.Text = "Adicionar Alocação";
            this.btn_alocacao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_alocacao.UseVisualStyleBackColor = false;
            this.btn_alocacao.Click += new System.EventHandler(this.btn_alocacao_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.panel1.Controls.Add(this.btn_visualizar);
            this.panel1.Controls.Add(this.tb_pesquisa);
            this.panel1.Location = new System.Drawing.Point(38, 53);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(664, 35);
            this.panel1.TabIndex = 23;
            // 
            // btn_visualizar
            // 
            this.btn_visualizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_visualizar.Enabled = false;
            this.btn_visualizar.FlatAppearance.BorderSize = 0;
            this.btn_visualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_visualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_visualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_visualizar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btn_visualizar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_visualizar.IconChar = FontAwesome.Sharp.IconChar.Sistrix;
            this.btn_visualizar.IconColor = System.Drawing.Color.White;
            this.btn_visualizar.IconSize = 20;
            this.btn_visualizar.Location = new System.Drawing.Point(625, 10);
            this.btn_visualizar.Name = "btn_visualizar";
            this.btn_visualizar.Rotation = 0D;
            this.btn_visualizar.Size = new System.Drawing.Size(29, 15);
            this.btn_visualizar.TabIndex = 4;
            this.btn_visualizar.UseVisualStyleBackColor = true;
            // 
            // tb_pesquisa
            // 
            this.tb_pesquisa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_pesquisa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.tb_pesquisa.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_pesquisa.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_pesquisa.ForeColor = System.Drawing.Color.Gray;
            this.tb_pesquisa.Location = new System.Drawing.Point(10, 10);
            this.tb_pesquisa.Name = "tb_pesquisa";
            this.tb_pesquisa.Size = new System.Drawing.Size(609, 15);
            this.tb_pesquisa.TabIndex = 0;
            this.tb_pesquisa.Text = "Pesquisar alocação...";
            this.tb_pesquisa.Enter += new System.EventHandler(this.tb_pesquisa_Enter);
            this.tb_pesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_pesquisa_KeyDown);
            this.tb_pesquisa.Leave += new System.EventHandler(this.tb_pesquisa_Leave);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.dgv_alocacoes);
            this.panel5.Location = new System.Drawing.Point(38, 119);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1144, 304);
            this.panel5.TabIndex = 21;
            // 
            // dgv_alocacoes
            // 
            this.dgv_alocacoes.AllowUserToAddRows = false;
            this.dgv_alocacoes.AllowUserToDeleteRows = false;
            this.dgv_alocacoes.AllowUserToResizeColumns = false;
            this.dgv_alocacoes.AllowUserToResizeRows = false;
            this.dgv_alocacoes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_alocacoes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.dgv_alocacoes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_alocacoes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_alocacoes.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv_alocacoes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_alocacoes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_alocacoes.ColumnHeadersHeight = 50;
            this.dgv_alocacoes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_alocacoes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column13,
            this.Column5,
            this.Column7,
            this.Column1,
            this.Column4,
            this.Column2,
            this.Column6,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column3,
            this.Column9});
            this.dgv_alocacoes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_alocacoes.EnableHeadersVisualStyles = false;
            this.dgv_alocacoes.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgv_alocacoes.Location = new System.Drawing.Point(0, 0);
            this.dgv_alocacoes.MultiSelect = false;
            this.dgv_alocacoes.Name = "dgv_alocacoes";
            this.dgv_alocacoes.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_alocacoes.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_alocacoes.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_alocacoes.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_alocacoes.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_alocacoes.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.dgv_alocacoes.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_alocacoes.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.dgv_alocacoes.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_alocacoes.RowTemplate.Height = 60;
            this.dgv_alocacoes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_alocacoes.Size = new System.Drawing.Size(1144, 304);
            this.dgv_alocacoes.TabIndex = 11;
            this.dgv_alocacoes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_alocacoes_CellContentClick);
            // 
            // Column8
            // 
            this.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column8.HeaderText = "Código";
            this.Column8.MinimumWidth = 50;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            this.Column8.Width = 50;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Seleção";
            this.Column13.Name = "Column13";
            // 
            // Column5
            // 
            this.Column5.FillWeight = 81.21145F;
            this.Column5.HeaderText = "Tombo";
            this.Column5.MinimumWidth = 100;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column7.FillWeight = 147.6982F;
            this.Column7.HeaderText = "Capa";
            this.Column7.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Column7.MinimumWidth = 40;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column7.Width = 40;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 67.24362F;
            this.Column1.HeaderText = "Titulo";
            this.Column1.MinimumWidth = 100;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.HeaderText = "CPF";
            this.Column4.MinimumWidth = 70;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 70;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Usuário";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column6.HeaderText = "Tipo de Usuário";
            this.Column6.MinimumWidth = 80;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 80;
            // 
            // Column10
            // 
            this.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column10.HeaderText = "Data da Alocação";
            this.Column10.MinimumWidth = 90;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 90;
            // 
            // Column11
            // 
            this.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column11.HeaderText = "Data da Devolução";
            this.Column11.MinimumWidth = 90;
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 90;
            // 
            // Column12
            // 
            this.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column12.HeaderText = "Situação";
            this.Column12.MinimumWidth = 80;
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column12.Width = 80;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.FillWeight = 146.0025F;
            this.Column3.HeaderText = "Desalocar";
            this.Column3.Image = global::BibliotecaEtec.Properties.Resources.Trash;
            this.Column3.MinimumWidth = 70;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.Width = 70;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column9.FillWeight = 158.0497F;
            this.Column9.HeaderText = "Editar";
            this.Column9.Image = global::BibliotecaEtec.Properties.Resources.Edicao;
            this.Column9.MinimumWidth = 60;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column9.Width = 60;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.img_loading);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.btn_carregarMais);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 450);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1219, 85);
            this.panel2.TabIndex = 20;
            // 
            // img_loading
            // 
            this.img_loading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.img_loading.ErrorImage = global::BibliotecaEtec.Properties.Resources.loading;
            this.img_loading.Image = global::BibliotecaEtec.Properties.Resources.loading;
            this.img_loading.InitialImage = global::BibliotecaEtec.Properties.Resources.loading;
            this.img_loading.Location = new System.Drawing.Point(595, 18);
            this.img_loading.Name = "img_loading";
            this.img_loading.Size = new System.Drawing.Size(40, 40);
            this.img_loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_loading.TabIndex = 33;
            this.img_loading.TabStop = false;
            this.img_loading.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(38, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 42);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Situação";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel4.Location = new System.Drawing.Point(93, 11);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(2, 25);
            this.panel4.TabIndex = 32;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(39, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 30;
            this.label2.Text = "Normal";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::BibliotecaEtec.Properties.Resources.Verde;
            this.pictureBox2.Location = new System.Drawing.Point(13, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(20, 20);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 31;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(130, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 28;
            this.label1.Text = "Atrasado";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BibliotecaEtec.Properties.Resources.vermelho;
            this.pictureBox1.Location = new System.Drawing.Point(104, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(20, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // btn_carregarMais
            // 
            this.btn_carregarMais.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_carregarMais.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(135)))), ((int)(((byte)(245)))));
            this.btn_carregarMais.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_carregarMais.FlatAppearance.BorderSize = 0;
            this.btn_carregarMais.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_carregarMais.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btn_carregarMais.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_carregarMais.ForeColor = System.Drawing.Color.White;
            this.btn_carregarMais.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btn_carregarMais.IconColor = System.Drawing.Color.White;
            this.btn_carregarMais.IconSize = 28;
            this.btn_carregarMais.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_carregarMais.Location = new System.Drawing.Point(595, 18);
            this.btn_carregarMais.Name = "btn_carregarMais";
            this.btn_carregarMais.Padding = new System.Windows.Forms.Padding(5);
            this.btn_carregarMais.Rotation = 0D;
            this.btn_carregarMais.Size = new System.Drawing.Size(40, 40);
            this.btn_carregarMais.TabIndex = 0;
            this.btn_carregarMais.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_carregarMais.UseVisualStyleBackColor = false;
            this.btn_carregarMais.Click += new System.EventHandler(this.btn_carregarMais_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.FillWeight = 146.0025F;
            this.dataGridViewImageColumn1.HeaderText = "Excluir";
            this.dataGridViewImageColumn1.Image = global::BibliotecaEtec.Properties.Resources.Trash;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.MinimumWidth = 50;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn2.FillWeight = 158.0497F;
            this.dataGridViewImageColumn2.HeaderText = "Editar";
            this.dataGridViewImageColumn2.Image = global::BibliotecaEtec.Properties.Resources.Edicao;
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.MinimumWidth = 50;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.Width = 50;
            // 
            // F_Alocacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.ClientSize = new System.Drawing.Size(1219, 535);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "F_Alocacoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F_Locacoes";
            this.Load += new System.EventHandler(this.F_Alocacoes_Load);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_alocacoes)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.img_loading)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton btn_alocacao;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btn_visualizar;
        private System.Windows.Forms.TextBox tb_pesquisa;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btn_carregarMais;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private FontAwesome.Sharp.IconButton btn_filtro;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox img_loading;
        private FontAwesome.Sharp.IconButton btn_relatorio;
        public System.Windows.Forms.DataGridView dgv_alocacoes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewImageColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewImageColumn Column12;
        private System.Windows.Forms.DataGridViewImageColumn Column3;
        private System.Windows.Forms.DataGridViewImageColumn Column9;
    }
}