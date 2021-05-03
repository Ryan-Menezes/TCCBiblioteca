namespace Biblioteca01
{
    partial class F_Cursos
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
            this.dgv_cursos = new System.Windows.Forms.DataGridView();
            this.btn_sair = new System.Windows.Forms.Button();
            this.btn_relatorio = new System.Windows.Forms.Button();
            this.btn_cad_curso = new System.Windows.Forms.Button();
            this.lb_letras = new System.Windows.Forms.Label();
            this.lb_numeros = new System.Windows.Forms.Label();
            this.btn_atualizar = new System.Windows.Forms.Button();
            this.btn_pesquisar = new System.Windows.Forms.Button();
            this.txt_pesquisa_neutra = new System.Windows.Forms.TextBox();
            this.txt_pesquisar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cursos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_cursos
            // 
            this.dgv_cursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cursos.Location = new System.Drawing.Point(12, 174);
            this.dgv_cursos.Name = "dgv_cursos";
            this.dgv_cursos.RowHeadersWidth = 45;
            this.dgv_cursos.Size = new System.Drawing.Size(897, 308);
            this.dgv_cursos.TabIndex = 103;
            // 
            // btn_sair
            // 
            this.btn_sair.BackColor = System.Drawing.Color.Crimson;
            this.btn_sair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_sair.FlatAppearance.BorderSize = 0;
            this.btn_sair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sair.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_sair.ForeColor = System.Drawing.Color.White;
            this.btn_sair.Location = new System.Drawing.Point(786, 67);
            this.btn_sair.Name = "btn_sair";
            this.btn_sair.Size = new System.Drawing.Size(122, 26);
            this.btn_sair.TabIndex = 106;
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
            this.btn_relatorio.Location = new System.Drawing.Point(646, 23);
            this.btn_relatorio.Name = "btn_relatorio";
            this.btn_relatorio.Size = new System.Drawing.Size(120, 26);
            this.btn_relatorio.TabIndex = 105;
            this.btn_relatorio.Text = "Emitir Relatório";
            this.btn_relatorio.UseVisualStyleBackColor = false;
            this.btn_relatorio.Click += new System.EventHandler(this.btn_relatorio_Click);
            // 
            // btn_cad_curso
            // 
            this.btn_cad_curso.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_cad_curso.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cad_curso.FlatAppearance.BorderSize = 0;
            this.btn_cad_curso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cad_curso.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_cad_curso.ForeColor = System.Drawing.Color.White;
            this.btn_cad_curso.Location = new System.Drawing.Point(786, 23);
            this.btn_cad_curso.Name = "btn_cad_curso";
            this.btn_cad_curso.Size = new System.Drawing.Size(123, 26);
            this.btn_cad_curso.TabIndex = 104;
            this.btn_cad_curso.Text = "Cadastrar";
            this.btn_cad_curso.UseVisualStyleBackColor = false;
            this.btn_cad_curso.Click += new System.EventHandler(this.btn_cad_curso_Click);
            // 
            // lb_letras
            // 
            this.lb_letras.AutoSize = true;
            this.lb_letras.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_letras.ForeColor = System.Drawing.Color.Black;
            this.lb_letras.Location = new System.Drawing.Point(158, 110);
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
            this.lb_numeros.Location = new System.Drawing.Point(27, 110);
            this.lb_numeros.Name = "lb_numeros";
            this.lb_numeros.Size = new System.Drawing.Size(82, 22);
            this.lb_numeros.TabIndex = 121;
            this.lb_numeros.Text = "Números";
            // 
            // btn_atualizar
            // 
            this.btn_atualizar.BackColor = System.Drawing.Color.SteelBlue;
            this.btn_atualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_atualizar.FlatAppearance.BorderSize = 0;
            this.btn_atualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_atualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_atualizar.ForeColor = System.Drawing.Color.White;
            this.btn_atualizar.Location = new System.Drawing.Point(404, 132);
            this.btn_atualizar.Name = "btn_atualizar";
            this.btn_atualizar.Size = new System.Drawing.Size(38, 29);
            this.btn_atualizar.TabIndex = 120;
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
            this.btn_pesquisar.Location = new System.Drawing.Point(283, 132);
            this.btn_pesquisar.Name = "btn_pesquisar";
            this.btn_pesquisar.Size = new System.Drawing.Size(115, 29);
            this.btn_pesquisar.TabIndex = 119;
            this.btn_pesquisar.Text = "Pesquisar";
            this.btn_pesquisar.UseVisualStyleBackColor = false;
            this.btn_pesquisar.Click += new System.EventHandler(this.btn_pesquisar_Click);
            // 
            // txt_pesquisa_neutra
            // 
            this.txt_pesquisa_neutra.Location = new System.Drawing.Point(162, 138);
            this.txt_pesquisa_neutra.Name = "txt_pesquisa_neutra";
            this.txt_pesquisa_neutra.Size = new System.Drawing.Size(104, 20);
            this.txt_pesquisa_neutra.TabIndex = 124;
            // 
            // txt_pesquisar
            // 
            this.txt_pesquisar.Location = new System.Drawing.Point(26, 138);
            this.txt_pesquisar.Name = "txt_pesquisar";
            this.txt_pesquisar.Size = new System.Drawing.Size(109, 20);
            this.txt_pesquisar.TabIndex = 123;
            // 
            // F_Cursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(921, 494);
            this.Controls.Add(this.txt_pesquisa_neutra);
            this.Controls.Add(this.txt_pesquisar);
            this.Controls.Add(this.lb_letras);
            this.Controls.Add(this.lb_numeros);
            this.Controls.Add(this.btn_atualizar);
            this.Controls.Add(this.btn_pesquisar);
            this.Controls.Add(this.btn_sair);
            this.Controls.Add(this.btn_relatorio);
            this.Controls.Add(this.btn_cad_curso);
            this.Controls.Add(this.dgv_cursos);
            this.Name = "F_Cursos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F_Cursos";
            this.Load += new System.EventHandler(this.F_Cursos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cursos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_cursos;
        private System.Windows.Forms.Button btn_sair;
        private System.Windows.Forms.Button btn_relatorio;
        private System.Windows.Forms.Button btn_cad_curso;
        private System.Windows.Forms.Label lb_letras;
        private System.Windows.Forms.Label lb_numeros;
        private System.Windows.Forms.Button btn_atualizar;
        private System.Windows.Forms.Button btn_pesquisar;
        public System.Windows.Forms.TextBox txt_pesquisa_neutra;
        public System.Windows.Forms.TextBox txt_pesquisar;
    }
}