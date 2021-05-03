namespace BibliotecaEtec
{
    partial class F_CursosInstituicao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.cb_instituicao = new System.Windows.Forms.ComboBox();
            this.btn_cadastro = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_visualizar = new FontAwesome.Sharp.IconButton();
            this.tb_pesquisa = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgv_cursosInstituicao = new System.Windows.Forms.DataGridView();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.img_loading = new System.Windows.Forms.PictureBox();
            this.btn_carregarMais = new FontAwesome.Sharp.IconButton();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cursosInstituicao)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_loading)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.cb_instituicao);
            this.panel3.Controls.Add(this.btn_cadastro);
            this.panel3.Controls.Add(this.panel1);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(921, 497);
            this.panel3.TabIndex = 21;
            // 
            // cb_instituicao
            // 
            this.cb_instituicao.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_instituicao.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.cb_instituicao.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_instituicao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_instituicao.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_instituicao.ForeColor = System.Drawing.Color.White;
            this.cb_instituicao.FormattingEnabled = true;
            this.cb_instituicao.Items.AddRange(new object[] {
            "Etec Juscelino",
            "Etec Juscelino",
            "Etec Juscelino",
            "Etec Juscelino",
            "Etec Juscelino"});
            this.cb_instituicao.Location = new System.Drawing.Point(730, 60);
            this.cb_instituicao.Name = "cb_instituicao";
            this.cb_instituicao.Size = new System.Drawing.Size(154, 24);
            this.cb_instituicao.TabIndex = 35;
            this.cb_instituicao.SelectedValueChanged += new System.EventHandler(this.cb_instituicao_SelectedValueChanged);
            // 
            // btn_cadastro
            // 
            this.btn_cadastro.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cadastro.BackColor = System.Drawing.Color.Olive;
            this.btn_cadastro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cadastro.FlatAppearance.BorderSize = 0;
            this.btn_cadastro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadastro.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btn_cadastro.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cadastro.ForeColor = System.Drawing.Color.White;
            this.btn_cadastro.IconChar = FontAwesome.Sharp.IconChar.ChalkboardTeacher;
            this.btn_cadastro.IconColor = System.Drawing.Color.White;
            this.btn_cadastro.IconSize = 20;
            this.btn_cadastro.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_cadastro.Location = new System.Drawing.Point(570, 54);
            this.btn_cadastro.Name = "btn_cadastro";
            this.btn_cadastro.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btn_cadastro.Rotation = 0D;
            this.btn_cadastro.Size = new System.Drawing.Size(154, 35);
            this.btn_cadastro.TabIndex = 24;
            this.btn_cadastro.Text = "Cadastrar Curso";
            this.btn_cadastro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cadastro.UseVisualStyleBackColor = false;
            this.btn_cadastro.Click += new System.EventHandler(this.btn_cadastro_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.panel1.Controls.Add(this.btn_visualizar);
            this.panel1.Controls.Add(this.tb_pesquisa);
            this.panel1.Location = new System.Drawing.Point(38, 54);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(526, 35);
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
            this.btn_visualizar.IconChar = FontAwesome.Sharp.IconChar.Sistrix;
            this.btn_visualizar.IconColor = System.Drawing.Color.White;
            this.btn_visualizar.IconSize = 20;
            this.btn_visualizar.Location = new System.Drawing.Point(487, 10);
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
            this.tb_pesquisa.Size = new System.Drawing.Size(471, 15);
            this.tb_pesquisa.TabIndex = 0;
            this.tb_pesquisa.Text = "Pesquisar curso...";
            this.tb_pesquisa.Enter += new System.EventHandler(this.tb_pesquisa_Enter);
            this.tb_pesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_pesquisa_KeyDown);
            this.tb_pesquisa.Leave += new System.EventHandler(this.tb_pesquisa_Leave);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.dgv_cursosInstituicao);
            this.panel5.Location = new System.Drawing.Point(38, 121);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(846, 292);
            this.panel5.TabIndex = 21;
            // 
            // dgv_cursosInstituicao
            // 
            this.dgv_cursosInstituicao.AllowUserToAddRows = false;
            this.dgv_cursosInstituicao.AllowUserToDeleteRows = false;
            this.dgv_cursosInstituicao.AllowUserToResizeColumns = false;
            this.dgv_cursosInstituicao.AllowUserToResizeRows = false;
            this.dgv_cursosInstituicao.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_cursosInstituicao.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.dgv_cursosInstituicao.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_cursosInstituicao.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_cursosInstituicao.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv_cursosInstituicao.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_cursosInstituicao.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_cursosInstituicao.ColumnHeadersHeight = 50;
            this.dgv_cursosInstituicao.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_cursosInstituicao.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column12,
            this.Column1,
            this.Column5,
            this.Column2,
            this.Column4,
            this.Column6,
            this.Column10,
            this.Column3,
            this.Column9});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_cursosInstituicao.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_cursosInstituicao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_cursosInstituicao.EnableHeadersVisualStyles = false;
            this.dgv_cursosInstituicao.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgv_cursosInstituicao.Location = new System.Drawing.Point(0, 0);
            this.dgv_cursosInstituicao.MultiSelect = false;
            this.dgv_cursosInstituicao.Name = "dgv_cursosInstituicao";
            this.dgv_cursosInstituicao.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_cursosInstituicao.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_cursosInstituicao.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_cursosInstituicao.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_cursosInstituicao.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_cursosInstituicao.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.dgv_cursosInstituicao.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_cursosInstituicao.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.dgv_cursosInstituicao.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_cursosInstituicao.RowTemplate.Height = 40;
            this.dgv_cursosInstituicao.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_cursosInstituicao.Size = new System.Drawing.Size(846, 292);
            this.dgv_cursosInstituicao.TabIndex = 11;
            this.dgv_cursosInstituicao.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_cursosInstituicao_CellContentClick);
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Codigo Curso";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Visible = false;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 72.39117F;
            this.Column1.HeaderText = "Nome";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.FillWeight = 87.42824F;
            this.Column5.HeaderText = "Módulo/Série";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.FillWeight = 72.39117F;
            this.Column2.HeaderText = "Periodo";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.FillWeight = 132.4342F;
            this.Column4.HeaderText = "Turma";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.FillWeight = 54.30807F;
            this.Column6.HeaderText = "Tipo";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column10
            // 
            this.Column10.FillWeight = 90.98708F;
            this.Column10.HeaderText = "Instituição";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.FillWeight = 146.0025F;
            this.Column3.HeaderText = "Excluir";
            this.Column3.Image = global::BibliotecaEtec.Properties.Resources.Trash;
            this.Column3.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Column3.MinimumWidth = 50;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.Width = 50;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column9.FillWeight = 158.0497F;
            this.Column9.HeaderText = "Editar";
            this.Column9.Image = global::BibliotecaEtec.Properties.Resources.Edicao;
            this.Column9.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Column9.MinimumWidth = 50;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column9.Width = 50;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.img_loading);
            this.panel2.Controls.Add(this.btn_carregarMais);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 418);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(921, 79);
            this.panel2.TabIndex = 20;
            // 
            // img_loading
            // 
            this.img_loading.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.img_loading.ErrorImage = global::BibliotecaEtec.Properties.Resources.loading;
            this.img_loading.Image = global::BibliotecaEtec.Properties.Resources.loading;
            this.img_loading.InitialImage = global::BibliotecaEtec.Properties.Resources.loading;
            this.img_loading.Location = new System.Drawing.Point(446, 15);
            this.img_loading.Name = "img_loading";
            this.img_loading.Size = new System.Drawing.Size(40, 40);
            this.img_loading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_loading.TabIndex = 2;
            this.img_loading.TabStop = false;
            this.img_loading.Visible = false;
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
            this.btn_carregarMais.Location = new System.Drawing.Point(446, 15);
            this.btn_carregarMais.Name = "btn_carregarMais";
            this.btn_carregarMais.Padding = new System.Windows.Forms.Padding(5);
            this.btn_carregarMais.Rotation = 0D;
            this.btn_carregarMais.Size = new System.Drawing.Size(40, 40);
            this.btn_carregarMais.TabIndex = 0;
            this.btn_carregarMais.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_carregarMais.UseVisualStyleBackColor = false;
            this.btn_carregarMais.Click += new System.EventHandler(this.btn_carregarMais_Click);
            // 
            // F_CursosInstituicao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.ClientSize = new System.Drawing.Size(921, 497);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "F_CursosInstituicao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biblioteca - Cursos da Instituição";
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cursosInstituicao)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.img_loading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private FontAwesome.Sharp.IconButton btn_cadastro;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btn_visualizar;
        private System.Windows.Forms.TextBox tb_pesquisa;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox img_loading;
        private FontAwesome.Sharp.IconButton btn_carregarMais;
        private System.Windows.Forms.ComboBox cb_instituicao;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewImageColumn Column3;
        private System.Windows.Forms.DataGridViewImageColumn Column9;
        public System.Windows.Forms.DataGridView dgv_cursosInstituicao;
    }
}