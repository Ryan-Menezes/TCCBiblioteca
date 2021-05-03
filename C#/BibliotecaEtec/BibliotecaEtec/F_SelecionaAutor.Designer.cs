namespace BibliotecaEtec
{
    partial class F_SelecionaAutor
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
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dgv_autor = new System.Windows.Forms.DataGridView();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nacionalidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_carregarMais = new FontAwesome.Sharp.IconButton();
            this.btn_autor = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_visualizar = new FontAwesome.Sharp.IconButton();
            this.tb_pesquisa = new System.Windows.Forms.TextBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_autor)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.panel3.Size = new System.Drawing.Size(613, 52);
            this.panel3.TabIndex = 30;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.Image = global::BibliotecaEtec.Properties.Resources.LogoJKCircular;
            this.pictureBox4.Location = new System.Drawing.Point(570, 12);
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
            this.pictureBox3.Location = new System.Drawing.Point(534, 12);
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
            this.label1.Size = new System.Drawing.Size(172, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Biblioteca - Selecionar Autor";
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.dgv_autor);
            this.panel5.Location = new System.Drawing.Point(29, 132);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(554, 262);
            this.panel5.TabIndex = 33;
            // 
            // dgv_autor
            // 
            this.dgv_autor.AllowUserToAddRows = false;
            this.dgv_autor.AllowUserToDeleteRows = false;
            this.dgv_autor.AllowUserToResizeColumns = false;
            this.dgv_autor.AllowUserToResizeRows = false;
            this.dgv_autor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_autor.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.dgv_autor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_autor.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_autor.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dgv_autor.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(10)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_autor.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_autor.ColumnHeadersHeight = 50;
            this.dgv_autor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_autor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column5,
            this.Column2,
            this.Column1,
            this.Column4,
            this.Nacionalidade,
            this.Column3,
            this.Column9});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_autor.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_autor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_autor.EnableHeadersVisualStyles = false;
            this.dgv_autor.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgv_autor.Location = new System.Drawing.Point(0, 0);
            this.dgv_autor.MultiSelect = false;
            this.dgv_autor.Name = "dgv_autor";
            this.dgv_autor.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_autor.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_autor.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_autor.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_autor.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgv_autor.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.dgv_autor.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgv_autor.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.dgv_autor.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgv_autor.RowTemplate.Height = 50;
            this.dgv_autor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_autor.Size = new System.Drawing.Size(554, 262);
            this.dgv_autor.TabIndex = 25;
            this.dgv_autor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_autor_CellContentClick);
            this.dgv_autor.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_autor_CellMouseDoubleClick);
            // 
            // Column5
            // 
            this.Column5.FillWeight = 81.21145F;
            this.Column5.HeaderText = "Id";
            this.Column5.MinimumWidth = 100;
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "id_colaboradores";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Visible = false;
            // 
            // Column1
            // 
            this.Column1.FillWeight = 67.24362F;
            this.Column1.HeaderText = "Nome";
            this.Column1.MinimumWidth = 100;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.HeaderText = "Colaboradores";
            this.Column4.MinimumWidth = 100;
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Nacionalidade
            // 
            this.Nacionalidade.HeaderText = "Nacionalidade";
            this.Nacionalidade.Name = "Nacionalidade";
            this.Nacionalidade.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.FillWeight = 146.0025F;
            this.Column3.HeaderText = "Excluir";
            this.Column3.Image = global::BibliotecaEtec.Properties.Resources.Trash;
            this.Column3.MinimumWidth = 80;
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column3.Width = 80;
            // 
            // Column9
            // 
            this.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column9.FillWeight = 158.0497F;
            this.Column9.HeaderText = "Editar";
            this.Column9.Image = global::BibliotecaEtec.Properties.Resources.Edicao;
            this.Column9.MinimumWidth = 80;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column9.Width = 80;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_carregarMais);
            this.panel2.Controls.Add(this.btn_autor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 400);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(613, 85);
            this.panel2.TabIndex = 32;
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
            this.btn_carregarMais.Location = new System.Drawing.Point(284, 18);
            this.btn_carregarMais.Name = "btn_carregarMais";
            this.btn_carregarMais.Padding = new System.Windows.Forms.Padding(5);
            this.btn_carregarMais.Rotation = 0D;
            this.btn_carregarMais.Size = new System.Drawing.Size(40, 40);
            this.btn_carregarMais.TabIndex = 0;
            this.btn_carregarMais.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_carregarMais.UseVisualStyleBackColor = false;
            this.btn_carregarMais.Click += new System.EventHandler(this.btn_carregarMais_Click);
            // 
            // btn_autor
            // 
            this.btn_autor.BackColor = System.Drawing.Color.Maroon;
            this.btn_autor.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_autor.FlatAppearance.BorderSize = 0;
            this.btn_autor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_autor.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btn_autor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btn_autor.ForeColor = System.Drawing.Color.White;
            this.btn_autor.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btn_autor.IconColor = System.Drawing.Color.White;
            this.btn_autor.IconSize = 20;
            this.btn_autor.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_autor.Location = new System.Drawing.Point(29, 21);
            this.btn_autor.Name = "btn_autor";
            this.btn_autor.Padding = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.btn_autor.Rotation = 0D;
            this.btn_autor.Size = new System.Drawing.Size(154, 35);
            this.btn_autor.TabIndex = 26;
            this.btn_autor.Text = "Adicionar Autor";
            this.btn_autor.UseVisualStyleBackColor = false;
            this.btn_autor.Click += new System.EventHandler(this.btn_autor_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.panel1.Controls.Add(this.btn_visualizar);
            this.panel1.Controls.Add(this.tb_pesquisa);
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(29, 76);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(554, 37);
            this.panel1.TabIndex = 34;
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
            this.btn_visualizar.Location = new System.Drawing.Point(515, 10);
            this.btn_visualizar.Name = "btn_visualizar";
            this.btn_visualizar.Rotation = 0D;
            this.btn_visualizar.Size = new System.Drawing.Size(29, 17);
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
            this.tb_pesquisa.Size = new System.Drawing.Size(499, 15);
            this.tb_pesquisa.TabIndex = 0;
            this.tb_pesquisa.Text = "Pesquisar autor...";
            this.tb_pesquisa.Enter += new System.EventHandler(this.tb_pesquisa_Enter);
            this.tb_pesquisa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_pesquisa_KeyDown);
            this.tb_pesquisa.Leave += new System.EventHandler(this.tb_pesquisa_Leave);
            // 
            // F_SelecionaAutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.ClientSize = new System.Drawing.Size(613, 485);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "F_SelecionaAutor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biblioteca - Selecionar Autor";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_autor)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton btn_carregarMais;
        private FontAwesome.Sharp.IconButton btn_autor;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton btn_visualizar;
        private System.Windows.Forms.TextBox tb_pesquisa;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nacionalidade;
        private System.Windows.Forms.DataGridViewImageColumn Column3;
        private System.Windows.Forms.DataGridViewImageColumn Column9;
        public System.Windows.Forms.DataGridView dgv_autor;
    }
}