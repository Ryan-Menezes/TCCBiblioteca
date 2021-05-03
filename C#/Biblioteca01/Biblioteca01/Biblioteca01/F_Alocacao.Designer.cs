namespace Biblioteca01
{
    partial class F_Alocacao
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtp_data_devolucao = new System.Windows.Forms.DateTimePicker();
            this.lb_insercao = new System.Windows.Forms.Label();
            this.lb_data_emprestimo = new System.Windows.Forms.Label();
            this.lb_tombo = new System.Windows.Forms.Label();
            this.lb_rm_aluno_alocacao = new System.Windows.Forms.Label();
            this.lb_tombo_alocacao = new System.Windows.Forms.Label();
            this.cb_status = new System.Windows.Forms.ComboBox();
            this.lb_status_alocacao = new System.Windows.Forms.Label();
            this.dtp_data_emprestimo = new System.Windows.Forms.DateTimePicker();
            this.btn_excluir_alocacao = new System.Windows.Forms.Button();
            this.btn_alterar_alocacao = new System.Windows.Forms.Button();
            this.btn_cadastrar_alocacao = new System.Windows.Forms.Button();
            this.btn_atualizar = new System.Windows.Forms.Button();
            this.dgv_alocao_livros = new System.Windows.Forms.DataGridView();
            this.nud_tombo_locacao = new System.Windows.Forms.NumericUpDown();
            this.nud_rm_aluno_locacao = new System.Windows.Forms.NumericUpDown();
            this.nud_rm_admin_locacao = new System.Windows.Forms.NumericUpDown();
            this.btn_pesquisar = new System.Windows.Forms.Button();
            this.txt_pesquisar_numeros = new System.Windows.Forms.TextBox();
            this.txt_pesquisar_letra = new System.Windows.Forms.TextBox();
            this.nud_id_locacao = new System.Windows.Forms.NumericUpDown();
            this.lb_id_locacao = new System.Windows.Forms.Label();
            this.btn_relatorio = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_alocao_livros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_tombo_locacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_rm_aluno_locacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_rm_admin_locacao)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_id_locacao)).BeginInit();
            this.SuspendLayout();
            // 
            // dtp_data_devolucao
            // 
            this.dtp_data_devolucao.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtp_data_devolucao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtp_data_devolucao.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_data_devolucao.Location = new System.Drawing.Point(186, 100);
            this.dtp_data_devolucao.Name = "dtp_data_devolucao";
            this.dtp_data_devolucao.Size = new System.Drawing.Size(133, 27);
            this.dtp_data_devolucao.TabIndex = 72;
            // 
            // lb_insercao
            // 
            this.lb_insercao.AutoSize = true;
            this.lb_insercao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_insercao.ForeColor = System.Drawing.Color.Black;
            this.lb_insercao.Location = new System.Drawing.Point(182, 75);
            this.lb_insercao.Name = "lb_insercao";
            this.lb_insercao.Size = new System.Drawing.Size(138, 22);
            this.lb_insercao.TabIndex = 71;
            this.lb_insercao.Text = "Data Devolução";
            // 
            // lb_data_emprestimo
            // 
            this.lb_data_emprestimo.AutoSize = true;
            this.lb_data_emprestimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_data_emprestimo.ForeColor = System.Drawing.Color.Black;
            this.lb_data_emprestimo.Location = new System.Drawing.Point(11, 75);
            this.lb_data_emprestimo.Name = "lb_data_emprestimo";
            this.lb_data_emprestimo.Size = new System.Drawing.Size(147, 22);
            this.lb_data_emprestimo.TabIndex = 69;
            this.lb_data_emprestimo.Text = "Data Emprestimo";
            // 
            // lb_tombo
            // 
            this.lb_tombo.AutoSize = true;
            this.lb_tombo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tombo.ForeColor = System.Drawing.Color.Black;
            this.lb_tombo.Location = new System.Drawing.Point(305, 18);
            this.lb_tombo.Name = "lb_tombo";
            this.lb_tombo.Size = new System.Drawing.Size(92, 22);
            this.lb_tombo.TabIndex = 73;
            this.lb_tombo.Text = "Rm Admin";
            // 
            // lb_rm_aluno_alocacao
            // 
            this.lb_rm_aluno_alocacao.AutoSize = true;
            this.lb_rm_aluno_alocacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_rm_aluno_alocacao.ForeColor = System.Drawing.Color.Black;
            this.lb_rm_aluno_alocacao.Location = new System.Drawing.Point(184, 18);
            this.lb_rm_aluno_alocacao.Name = "lb_rm_aluno_alocacao";
            this.lb_rm_aluno_alocacao.Size = new System.Drawing.Size(88, 22);
            this.lb_rm_aluno_alocacao.TabIndex = 75;
            this.lb_rm_aluno_alocacao.Text = "Rm Aluno";
            // 
            // lb_tombo_alocacao
            // 
            this.lb_tombo_alocacao.AutoSize = true;
            this.lb_tombo_alocacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tombo_alocacao.ForeColor = System.Drawing.Color.Black;
            this.lb_tombo_alocacao.Location = new System.Drawing.Point(64, 18);
            this.lb_tombo_alocacao.Name = "lb_tombo_alocacao";
            this.lb_tombo_alocacao.Size = new System.Drawing.Size(71, 22);
            this.lb_tombo_alocacao.TabIndex = 77;
            this.lb_tombo_alocacao.Text = "Tombo:";
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
            "ATRASADO",
            "ENTREGUE",
            "RENOVADO"});
            this.cb_status.Location = new System.Drawing.Point(359, 103);
            this.cb_status.Name = "cb_status";
            this.cb_status.Size = new System.Drawing.Size(103, 24);
            this.cb_status.TabIndex = 84;
            // 
            // lb_status_alocacao
            // 
            this.lb_status_alocacao.AutoSize = true;
            this.lb_status_alocacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_status_alocacao.ForeColor = System.Drawing.Color.Black;
            this.lb_status_alocacao.Location = new System.Drawing.Point(355, 78);
            this.lb_status_alocacao.Name = "lb_status_alocacao";
            this.lb_status_alocacao.Size = new System.Drawing.Size(61, 22);
            this.lb_status_alocacao.TabIndex = 85;
            this.lb_status_alocacao.Text = "Status";
            // 
            // dtp_data_emprestimo
            // 
            this.dtp_data_emprestimo.CalendarMonthBackground = System.Drawing.Color.White;
            this.dtp_data_emprestimo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtp_data_emprestimo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_data_emprestimo.Location = new System.Drawing.Point(15, 100);
            this.dtp_data_emprestimo.Name = "dtp_data_emprestimo";
            this.dtp_data_emprestimo.Size = new System.Drawing.Size(133, 27);
            this.dtp_data_emprestimo.TabIndex = 86;
            // 
            // btn_excluir_alocacao
            // 
            this.btn_excluir_alocacao.BackColor = System.Drawing.Color.Crimson;
            this.btn_excluir_alocacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_excluir_alocacao.FlatAppearance.BorderSize = 0;
            this.btn_excluir_alocacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_excluir_alocacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_excluir_alocacao.ForeColor = System.Drawing.Color.White;
            this.btn_excluir_alocacao.Location = new System.Drawing.Point(614, 595);
            this.btn_excluir_alocacao.Name = "btn_excluir_alocacao";
            this.btn_excluir_alocacao.Size = new System.Drawing.Size(90, 24);
            this.btn_excluir_alocacao.TabIndex = 98;
            this.btn_excluir_alocacao.Text = "Excluir";
            this.btn_excluir_alocacao.UseVisualStyleBackColor = false;
            this.btn_excluir_alocacao.Click += new System.EventHandler(this.btn_excluir_alocacao_Click);
            // 
            // btn_alterar_alocacao
            // 
            this.btn_alterar_alocacao.BackColor = System.Drawing.Color.BurlyWood;
            this.btn_alterar_alocacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_alterar_alocacao.FlatAppearance.BorderSize = 0;
            this.btn_alterar_alocacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_alterar_alocacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_alterar_alocacao.ForeColor = System.Drawing.Color.White;
            this.btn_alterar_alocacao.Location = new System.Drawing.Point(710, 595);
            this.btn_alterar_alocacao.Name = "btn_alterar_alocacao";
            this.btn_alterar_alocacao.Size = new System.Drawing.Size(90, 24);
            this.btn_alterar_alocacao.TabIndex = 97;
            this.btn_alterar_alocacao.Text = "Alterar";
            this.btn_alterar_alocacao.UseVisualStyleBackColor = false;
            this.btn_alterar_alocacao.Click += new System.EventHandler(this.btn_alterar_alocacao_Click);
            // 
            // btn_cadastrar_alocacao
            // 
            this.btn_cadastrar_alocacao.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_cadastrar_alocacao.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cadastrar_alocacao.FlatAppearance.BorderSize = 0;
            this.btn_cadastrar_alocacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadastrar_alocacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_cadastrar_alocacao.ForeColor = System.Drawing.Color.White;
            this.btn_cadastrar_alocacao.Location = new System.Drawing.Point(806, 595);
            this.btn_cadastrar_alocacao.Name = "btn_cadastrar_alocacao";
            this.btn_cadastrar_alocacao.Size = new System.Drawing.Size(90, 24);
            this.btn_cadastrar_alocacao.TabIndex = 96;
            this.btn_cadastrar_alocacao.Text = "Cadastrar";
            this.btn_cadastrar_alocacao.UseVisualStyleBackColor = false;
            this.btn_cadastrar_alocacao.Click += new System.EventHandler(this.btn_cadastrar_alocacao_Click);
            // 
            // btn_atualizar
            // 
            this.btn_atualizar.BackColor = System.Drawing.Color.RoyalBlue;
            this.btn_atualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_atualizar.FlatAppearance.BorderSize = 0;
            this.btn_atualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_atualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_atualizar.ForeColor = System.Drawing.Color.White;
            this.btn_atualizar.Location = new System.Drawing.Point(574, 595);
            this.btn_atualizar.Name = "btn_atualizar";
            this.btn_atualizar.Size = new System.Drawing.Size(34, 24);
            this.btn_atualizar.TabIndex = 99;
            this.btn_atualizar.UseVisualStyleBackColor = false;
            this.btn_atualizar.Click += new System.EventHandler(this.btn_atualizar_Click);
            // 
            // dgv_alocao_livros
            // 
            this.dgv_alocao_livros.AllowUserToAddRows = false;
            this.dgv_alocao_livros.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.471698F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_alocao_livros.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_alocao_livros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_alocao_livros.EnableHeadersVisualStyles = false;
            this.dgv_alocao_livros.Location = new System.Drawing.Point(12, 217);
            this.dgv_alocao_livros.MultiSelect = false;
            this.dgv_alocao_livros.Name = "dgv_alocao_livros";
            this.dgv_alocao_livros.ReadOnly = true;
            this.dgv_alocao_livros.RowHeadersVisible = false;
            this.dgv_alocao_livros.RowHeadersWidth = 45;
            this.dgv_alocao_livros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_alocao_livros.Size = new System.Drawing.Size(884, 356);
            this.dgv_alocao_livros.TabIndex = 100;
            this.dgv_alocao_livros.SelectionChanged += new System.EventHandler(this.dgv_alocao_livros_SelectionChanged);
            // 
            // nud_tombo_locacao
            // 
            this.nud_tombo_locacao.Location = new System.Drawing.Point(68, 50);
            this.nud_tombo_locacao.Maximum = new decimal(new int[] {
            1410065407,
            2,
            0,
            0});
            this.nud_tombo_locacao.Name = "nud_tombo_locacao";
            this.nud_tombo_locacao.Size = new System.Drawing.Size(81, 20);
            this.nud_tombo_locacao.TabIndex = 133;
            // 
            // nud_rm_aluno_locacao
            // 
            this.nud_rm_aluno_locacao.Location = new System.Drawing.Point(188, 50);
            this.nud_rm_aluno_locacao.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nud_rm_aluno_locacao.Name = "nud_rm_aluno_locacao";
            this.nud_rm_aluno_locacao.Size = new System.Drawing.Size(81, 20);
            this.nud_rm_aluno_locacao.TabIndex = 134;
            // 
            // nud_rm_admin_locacao
            // 
            this.nud_rm_admin_locacao.Location = new System.Drawing.Point(309, 50);
            this.nud_rm_admin_locacao.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nud_rm_admin_locacao.Name = "nud_rm_admin_locacao";
            this.nud_rm_admin_locacao.Size = new System.Drawing.Size(81, 20);
            this.nud_rm_admin_locacao.TabIndex = 135;
            // 
            // btn_pesquisar
            // 
            this.btn_pesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_pesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_pesquisar.FlatAppearance.BorderSize = 0;
            this.btn_pesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_pesquisar.ForeColor = System.Drawing.Color.White;
            this.btn_pesquisar.Location = new System.Drawing.Point(773, 182);
            this.btn_pesquisar.Name = "btn_pesquisar";
            this.btn_pesquisar.Size = new System.Drawing.Size(115, 29);
            this.btn_pesquisar.TabIndex = 140;
            this.btn_pesquisar.Text = "Pesquisar";
            this.btn_pesquisar.UseVisualStyleBackColor = false;
            this.btn_pesquisar.Click += new System.EventHandler(this.btn_pesquisar_Click);
            // 
            // txt_pesquisar_numeros
            // 
            this.txt_pesquisar_numeros.Location = new System.Drawing.Point(488, 191);
            this.txt_pesquisar_numeros.Name = "txt_pesquisar_numeros";
            this.txt_pesquisar_numeros.Size = new System.Drawing.Size(135, 20);
            this.txt_pesquisar_numeros.TabIndex = 142;
            this.txt_pesquisar_numeros.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_pesquisar_numeros_KeyPress);
            // 
            // txt_pesquisar_letra
            // 
            this.txt_pesquisar_letra.Location = new System.Drawing.Point(629, 191);
            this.txt_pesquisar_letra.Name = "txt_pesquisar_letra";
            this.txt_pesquisar_letra.Size = new System.Drawing.Size(135, 20);
            this.txt_pesquisar_letra.TabIndex = 143;
            this.txt_pesquisar_letra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_pesquisar_letra_KeyPress);
            // 
            // nud_id_locacao
            // 
            this.nud_id_locacao.Location = new System.Drawing.Point(12, 50);
            this.nud_id_locacao.Maximum = new decimal(new int[] {
            999999999,
            0,
            0,
            0});
            this.nud_id_locacao.Name = "nud_id_locacao";
            this.nud_id_locacao.Size = new System.Drawing.Size(43, 20);
            this.nud_id_locacao.TabIndex = 144;
            // 
            // lb_id_locacao
            // 
            this.lb_id_locacao.AutoSize = true;
            this.lb_id_locacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_id_locacao.ForeColor = System.Drawing.Color.Black;
            this.lb_id_locacao.Location = new System.Drawing.Point(8, 18);
            this.lb_id_locacao.Name = "lb_id_locacao";
            this.lb_id_locacao.Size = new System.Drawing.Size(24, 22);
            this.lb_id_locacao.TabIndex = 145;
            this.lb_id_locacao.Text = "Id";
            // 
            // btn_relatorio
            // 
            this.btn_relatorio.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_relatorio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_relatorio.FlatAppearance.BorderSize = 0;
            this.btn_relatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_relatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_relatorio.ForeColor = System.Drawing.Color.White;
            this.btn_relatorio.Location = new System.Drawing.Point(776, 18);
            this.btn_relatorio.Name = "btn_relatorio";
            this.btn_relatorio.Size = new System.Drawing.Size(120, 26);
            this.btn_relatorio.TabIndex = 146;
            this.btn_relatorio.Text = "Emitir Relatório";
            this.btn_relatorio.UseVisualStyleBackColor = false;
            this.btn_relatorio.Click += new System.EventHandler(this.btn_relatorio_Click);
            // 
            // F_Alocacao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 631);
            this.Controls.Add(this.btn_relatorio);
            this.Controls.Add(this.lb_id_locacao);
            this.Controls.Add(this.nud_id_locacao);
            this.Controls.Add(this.txt_pesquisar_letra);
            this.Controls.Add(this.txt_pesquisar_numeros);
            this.Controls.Add(this.btn_pesquisar);
            this.Controls.Add(this.nud_rm_admin_locacao);
            this.Controls.Add(this.nud_rm_aluno_locacao);
            this.Controls.Add(this.nud_tombo_locacao);
            this.Controls.Add(this.dgv_alocao_livros);
            this.Controls.Add(this.btn_atualizar);
            this.Controls.Add(this.btn_excluir_alocacao);
            this.Controls.Add(this.btn_alterar_alocacao);
            this.Controls.Add(this.btn_cadastrar_alocacao);
            this.Controls.Add(this.dtp_data_emprestimo);
            this.Controls.Add(this.lb_status_alocacao);
            this.Controls.Add(this.cb_status);
            this.Controls.Add(this.lb_tombo_alocacao);
            this.Controls.Add(this.lb_rm_aluno_alocacao);
            this.Controls.Add(this.lb_tombo);
            this.Controls.Add(this.dtp_data_devolucao);
            this.Controls.Add(this.lb_insercao);
            this.Controls.Add(this.lb_data_emprestimo);
            this.Name = "F_Alocacao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F_Alocacao";
            this.Load += new System.EventHandler(this.F_Alocacao_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_alocao_livros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_tombo_locacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_rm_aluno_locacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_rm_admin_locacao)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_id_locacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtp_data_devolucao;
        private System.Windows.Forms.Label lb_insercao;
        private System.Windows.Forms.Label lb_data_emprestimo;
        private System.Windows.Forms.Label lb_tombo;
        private System.Windows.Forms.Label lb_rm_aluno_alocacao;
        private System.Windows.Forms.Label lb_tombo_alocacao;
        private System.Windows.Forms.ComboBox cb_status;
        private System.Windows.Forms.Label lb_status_alocacao;
        private System.Windows.Forms.DateTimePicker dtp_data_emprestimo;
        private System.Windows.Forms.Button btn_excluir_alocacao;
        private System.Windows.Forms.Button btn_alterar_alocacao;
        private System.Windows.Forms.Button btn_cadastrar_alocacao;
        private System.Windows.Forms.Button btn_atualizar;
        private System.Windows.Forms.DataGridView dgv_alocao_livros;
        private System.Windows.Forms.NumericUpDown nud_tombo_locacao;
        private System.Windows.Forms.NumericUpDown nud_rm_aluno_locacao;
        private System.Windows.Forms.NumericUpDown nud_rm_admin_locacao;
        private System.Windows.Forms.Button btn_pesquisar;
        public System.Windows.Forms.TextBox txt_pesquisar_numeros;
        public System.Windows.Forms.TextBox txt_pesquisar_letra;
        private System.Windows.Forms.NumericUpDown nud_id_locacao;
        private System.Windows.Forms.Label lb_id_locacao;
        private System.Windows.Forms.Button btn_relatorio;
    }
}