namespace Biblioteca01
{
    partial class F_Aluno
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
            this.btn_sair = new System.Windows.Forms.Button();
            this.btn_relatorio_aluno = new System.Windows.Forms.Button();
            this.btn_cad_aluno = new System.Windows.Forms.Button();
            this.dgv_aluno = new System.Windows.Forms.DataGridView();
            this.txt_pesquisar = new System.Windows.Forms.TextBox();
            this.btn_pesquisar = new System.Windows.Forms.Button();
            this.btn_atualizar = new System.Windows.Forms.Button();
            this.txt_pesquisa_neutra = new System.Windows.Forms.TextBox();
            this.lb_numeros = new System.Windows.Forms.Label();
            this.lb_letras = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_aluno)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_sair
            // 
            this.btn_sair.BackColor = System.Drawing.Color.Crimson;
            this.btn_sair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sair.FlatAppearance.BorderSize = 0;
            this.btn_sair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sair.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_sair.ForeColor = System.Drawing.Color.White;
            this.btn_sair.Location = new System.Drawing.Point(786, 69);
            this.btn_sair.Name = "btn_sair";
            this.btn_sair.Size = new System.Drawing.Size(122, 26);
            this.btn_sair.TabIndex = 101;
            this.btn_sair.Text = "Sair";
            this.btn_sair.UseVisualStyleBackColor = false;
            // 
            // btn_relatorio_aluno
            // 
            this.btn_relatorio_aluno.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_relatorio_aluno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_relatorio_aluno.FlatAppearance.BorderSize = 0;
            this.btn_relatorio_aluno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_relatorio_aluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_relatorio_aluno.ForeColor = System.Drawing.Color.White;
            this.btn_relatorio_aluno.Location = new System.Drawing.Point(646, 25);
            this.btn_relatorio_aluno.Name = "btn_relatorio_aluno";
            this.btn_relatorio_aluno.Size = new System.Drawing.Size(120, 26);
            this.btn_relatorio_aluno.TabIndex = 100;
            this.btn_relatorio_aluno.Text = "Emitir Relatório";
            this.btn_relatorio_aluno.UseVisualStyleBackColor = false;
            this.btn_relatorio_aluno.Click += new System.EventHandler(this.btn_relatorio_aluno_Click);
            // 
            // btn_cad_aluno
            // 
            this.btn_cad_aluno.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_cad_aluno.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cad_aluno.FlatAppearance.BorderSize = 0;
            this.btn_cad_aluno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cad_aluno.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_cad_aluno.ForeColor = System.Drawing.Color.White;
            this.btn_cad_aluno.Location = new System.Drawing.Point(786, 25);
            this.btn_cad_aluno.Name = "btn_cad_aluno";
            this.btn_cad_aluno.Size = new System.Drawing.Size(123, 26);
            this.btn_cad_aluno.TabIndex = 99;
            this.btn_cad_aluno.Text = "Cadastrar";
            this.btn_cad_aluno.UseVisualStyleBackColor = false;
            this.btn_cad_aluno.Click += new System.EventHandler(this.btn_cad_aluno_Click);
            // 
            // dgv_aluno
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.471698F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_aluno.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_aluno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_aluno.EnableHeadersVisualStyles = false;
            this.dgv_aluno.Location = new System.Drawing.Point(11, 186);
            this.dgv_aluno.MultiSelect = false;
            this.dgv_aluno.Name = "dgv_aluno";
            this.dgv_aluno.RowHeadersVisible = false;
            this.dgv_aluno.RowHeadersWidth = 45;
            this.dgv_aluno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv_aluno.Size = new System.Drawing.Size(898, 308);
            this.dgv_aluno.TabIndex = 102;
            // 
            // txt_pesquisar
            // 
            this.txt_pesquisar.Location = new System.Drawing.Point(11, 157);
            this.txt_pesquisar.Name = "txt_pesquisar";
            this.txt_pesquisar.Size = new System.Drawing.Size(109, 20);
            this.txt_pesquisar.TabIndex = 105;
            // 
            // btn_pesquisar
            // 
            this.btn_pesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_pesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_pesquisar.FlatAppearance.BorderSize = 0;
            this.btn_pesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_pesquisar.ForeColor = System.Drawing.Color.White;
            this.btn_pesquisar.Location = new System.Drawing.Point(268, 151);
            this.btn_pesquisar.Name = "btn_pesquisar";
            this.btn_pesquisar.Size = new System.Drawing.Size(115, 29);
            this.btn_pesquisar.TabIndex = 106;
            this.btn_pesquisar.Text = "Pesquisar";
            this.btn_pesquisar.UseVisualStyleBackColor = false;
            this.btn_pesquisar.Click += new System.EventHandler(this.btn_pesquisar_Click);
            // 
            // btn_atualizar
            // 
            this.btn_atualizar.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_atualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_atualizar.FlatAppearance.BorderSize = 0;
            this.btn_atualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_atualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_atualizar.ForeColor = System.Drawing.Color.White;
            this.btn_atualizar.Location = new System.Drawing.Point(389, 151);
            this.btn_atualizar.Name = "btn_atualizar";
            this.btn_atualizar.Size = new System.Drawing.Size(38, 29);
            this.btn_atualizar.TabIndex = 107;
            this.btn_atualizar.UseVisualStyleBackColor = false;
            this.btn_atualizar.Click += new System.EventHandler(this.btn_atualizar_Click);
            // 
            // txt_pesquisa_neutra
            // 
            this.txt_pesquisa_neutra.Location = new System.Drawing.Point(147, 157);
            this.txt_pesquisa_neutra.Name = "txt_pesquisa_neutra";
            this.txt_pesquisa_neutra.Size = new System.Drawing.Size(104, 20);
            this.txt_pesquisa_neutra.TabIndex = 108;
            // 
            // lb_numeros
            // 
            this.lb_numeros.AutoSize = true;
            this.lb_numeros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_numeros.ForeColor = System.Drawing.Color.Black;
            this.lb_numeros.Location = new System.Drawing.Point(12, 132);
            this.lb_numeros.Name = "lb_numeros";
            this.lb_numeros.Size = new System.Drawing.Size(82, 22);
            this.lb_numeros.TabIndex = 117;
            this.lb_numeros.Text = "Números";
            // 
            // lb_letras
            // 
            this.lb_letras.AutoSize = true;
            this.lb_letras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_letras.ForeColor = System.Drawing.Color.Black;
            this.lb_letras.Location = new System.Drawing.Point(143, 132);
            this.lb_letras.Name = "lb_letras";
            this.lb_letras.Size = new System.Drawing.Size(60, 22);
            this.lb_letras.TabIndex = 118;
            this.lb_letras.Text = "Letras";
            // 
            // F_Aluno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 500);
            this.Controls.Add(this.lb_letras);
            this.Controls.Add(this.lb_numeros);
            this.Controls.Add(this.txt_pesquisa_neutra);
            this.Controls.Add(this.btn_atualizar);
            this.Controls.Add(this.btn_pesquisar);
            this.Controls.Add(this.txt_pesquisar);
            this.Controls.Add(this.dgv_aluno);
            this.Controls.Add(this.btn_sair);
            this.Controls.Add(this.btn_relatorio_aluno);
            this.Controls.Add(this.btn_cad_aluno);
            this.Name = "F_Aluno";
            this.Text = "Aluno";
            this.Load += new System.EventHandler(this.F_Aluno_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_aluno)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_sair;
        private System.Windows.Forms.Button btn_relatorio_aluno;
        private System.Windows.Forms.Button btn_cad_aluno;
        private System.Windows.Forms.DataGridView dgv_aluno;
        public System.Windows.Forms.TextBox txt_pesquisar;
        private System.Windows.Forms.Button btn_pesquisar;
        private System.Windows.Forms.Button btn_atualizar;
        public System.Windows.Forms.TextBox txt_pesquisa_neutra;
        private System.Windows.Forms.Label lb_numeros;
        private System.Windows.Forms.Label lb_letras;
    }
}