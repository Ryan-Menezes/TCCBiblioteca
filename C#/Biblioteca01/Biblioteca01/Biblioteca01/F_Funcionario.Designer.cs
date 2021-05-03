namespace Biblioteca01
{
    partial class F_Funcionario
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
            this.btn_sair = new System.Windows.Forms.Button();
            this.btn_relatorio = new System.Windows.Forms.Button();
            this.btn_cad_cursos = new System.Windows.Forms.Button();
            this.dgv_funcionario = new System.Windows.Forms.DataGridView();
            this.btn_atualizar = new System.Windows.Forms.Button();
            this.btn_pesquisar = new System.Windows.Forms.Button();
            this.lb_letras = new System.Windows.Forms.Label();
            this.lb_numeros = new System.Windows.Forms.Label();
            this.txt_pesquisa_neutra = new System.Windows.Forms.TextBox();
            this.txt_pesquisar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_funcionario)).BeginInit();
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
            // btn_relatorio
            // 
            this.btn_relatorio.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_relatorio.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_relatorio.FlatAppearance.BorderSize = 0;
            this.btn_relatorio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_relatorio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_relatorio.ForeColor = System.Drawing.Color.White;
            this.btn_relatorio.Location = new System.Drawing.Point(646, 25);
            this.btn_relatorio.Name = "btn_relatorio";
            this.btn_relatorio.Size = new System.Drawing.Size(120, 26);
            this.btn_relatorio.TabIndex = 100;
            this.btn_relatorio.Text = "Emitir Relatório";
            this.btn_relatorio.UseVisualStyleBackColor = false;
            this.btn_relatorio.Click += new System.EventHandler(this.btn_relatorio_Click);
            // 
            // btn_cad_cursos
            // 
            this.btn_cad_cursos.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_cad_cursos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cad_cursos.FlatAppearance.BorderSize = 0;
            this.btn_cad_cursos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cad_cursos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_cad_cursos.ForeColor = System.Drawing.Color.White;
            this.btn_cad_cursos.Location = new System.Drawing.Point(786, 25);
            this.btn_cad_cursos.Name = "btn_cad_cursos";
            this.btn_cad_cursos.Size = new System.Drawing.Size(123, 26);
            this.btn_cad_cursos.TabIndex = 99;
            this.btn_cad_cursos.Text = "Cadastrar";
            this.btn_cad_cursos.UseVisualStyleBackColor = false;
            this.btn_cad_cursos.Click += new System.EventHandler(this.btn_cad_funcionario_Click);
            // 
            // dgv_funcionario
            // 
            this.dgv_funcionario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_funcionario.Location = new System.Drawing.Point(12, 176);
            this.dgv_funcionario.Name = "dgv_funcionario";
            this.dgv_funcionario.RowHeadersWidth = 45;
            this.dgv_funcionario.Size = new System.Drawing.Size(897, 308);
            this.dgv_funcionario.TabIndex = 102;
            // 
            // btn_atualizar
            // 
            this.btn_atualizar.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_atualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_atualizar.FlatAppearance.BorderSize = 0;
            this.btn_atualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_atualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_atualizar.ForeColor = System.Drawing.Color.White;
            this.btn_atualizar.Location = new System.Drawing.Point(387, 141);
            this.btn_atualizar.Name = "btn_atualizar";
            this.btn_atualizar.Size = new System.Drawing.Size(38, 29);
            this.btn_atualizar.TabIndex = 110;
            this.btn_atualizar.UseVisualStyleBackColor = false;
            this.btn_atualizar.Click += new System.EventHandler(this.btn_atualizar_Click);
            // 
            // btn_pesquisar
            // 
            this.btn_pesquisar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_pesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_pesquisar.FlatAppearance.BorderSize = 0;
            this.btn_pesquisar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_pesquisar.ForeColor = System.Drawing.Color.White;
            this.btn_pesquisar.Location = new System.Drawing.Point(266, 141);
            this.btn_pesquisar.Name = "btn_pesquisar";
            this.btn_pesquisar.Size = new System.Drawing.Size(115, 29);
            this.btn_pesquisar.TabIndex = 109;
            this.btn_pesquisar.Text = "Pesquisar";
            this.btn_pesquisar.UseVisualStyleBackColor = false;
            this.btn_pesquisar.Click += new System.EventHandler(this.btn_pesquisar_Click);
            // 
            // lb_letras
            // 
            this.lb_letras.AutoSize = true;
            this.lb_letras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_letras.ForeColor = System.Drawing.Color.Black;
            this.lb_letras.Location = new System.Drawing.Point(144, 124);
            this.lb_letras.Name = "lb_letras";
            this.lb_letras.Size = new System.Drawing.Size(60, 22);
            this.lb_letras.TabIndex = 122;
            this.lb_letras.Text = "Letras";
            // 
            // lb_numeros
            // 
            this.lb_numeros.AutoSize = true;
            this.lb_numeros.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_numeros.ForeColor = System.Drawing.Color.Black;
            this.lb_numeros.Location = new System.Drawing.Point(13, 124);
            this.lb_numeros.Name = "lb_numeros";
            this.lb_numeros.Size = new System.Drawing.Size(82, 22);
            this.lb_numeros.TabIndex = 121;
            this.lb_numeros.Text = "Números";
            // 
            // txt_pesquisa_neutra
            // 
            this.txt_pesquisa_neutra.Location = new System.Drawing.Point(148, 149);
            this.txt_pesquisa_neutra.Name = "txt_pesquisa_neutra";
            this.txt_pesquisa_neutra.Size = new System.Drawing.Size(104, 20);
            this.txt_pesquisa_neutra.TabIndex = 120;
            // 
            // txt_pesquisar
            // 
            this.txt_pesquisar.Location = new System.Drawing.Point(12, 149);
            this.txt_pesquisar.Name = "txt_pesquisar";
            this.txt_pesquisar.Size = new System.Drawing.Size(109, 20);
            this.txt_pesquisar.TabIndex = 119;
            // 
            // F_Funcionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 494);
            this.Controls.Add(this.lb_letras);
            this.Controls.Add(this.lb_numeros);
            this.Controls.Add(this.txt_pesquisa_neutra);
            this.Controls.Add(this.txt_pesquisar);
            this.Controls.Add(this.btn_atualizar);
            this.Controls.Add(this.btn_pesquisar);
            this.Controls.Add(this.dgv_funcionario);
            this.Controls.Add(this.btn_sair);
            this.Controls.Add(this.btn_relatorio);
            this.Controls.Add(this.btn_cad_cursos);
            this.Name = "F_Funcionario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F_Funcionario";
            this.Load += new System.EventHandler(this.F_Funcionario_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_funcionario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_sair;
        private System.Windows.Forms.Button btn_relatorio;
        private System.Windows.Forms.Button btn_cad_cursos;
        private System.Windows.Forms.DataGridView dgv_funcionario;
        private System.Windows.Forms.Button btn_atualizar;
        private System.Windows.Forms.Button btn_pesquisar;
        private System.Windows.Forms.Label lb_letras;
        private System.Windows.Forms.Label lb_numeros;
        public System.Windows.Forms.TextBox txt_pesquisa_neutra;
        public System.Windows.Forms.TextBox txt_pesquisar;
    }
}