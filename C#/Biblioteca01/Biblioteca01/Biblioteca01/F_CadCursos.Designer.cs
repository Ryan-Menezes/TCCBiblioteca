namespace Biblioteca01
{
    partial class F_CadCursos
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
            this.txt_nome_curso = new System.Windows.Forms.TextBox();
            this.lb_nome_curso = new System.Windows.Forms.Label();
            this.txt_nome_turma = new System.Windows.Forms.TextBox();
            this.lb_turma = new System.Windows.Forms.Label();
            this.lb_tipo_curso = new System.Windows.Forms.Label();
            this.cb_periodo = new System.Windows.Forms.ComboBox();
            this.lb_periodo = new System.Windows.Forms.Label();
            this.cb_quantidade_modulos = new System.Windows.Forms.ComboBox();
            this.lb_quantidade_modulos = new System.Windows.Forms.Label();
            this.txt_tipo_curso = new System.Windows.Forms.TextBox();
            this.btn_cadastrar = new System.Windows.Forms.Button();
            this.cb_cod_instituicao = new System.Windows.Forms.ComboBox();
            this.lb_cod_instituicao = new System.Windows.Forms.Label();
            this.lb_cod_curso = new System.Windows.Forms.Label();
            this.nud_cod_curso = new System.Windows.Forms.NumericUpDown();
            this.btn_excluir = new System.Windows.Forms.Button();
            this.btn_alterar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.nud_cod_curso)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_nome_curso
            // 
            this.txt_nome_curso.Location = new System.Drawing.Point(37, 115);
            this.txt_nome_curso.Multiline = true;
            this.txt_nome_curso.Name = "txt_nome_curso";
            this.txt_nome_curso.Size = new System.Drawing.Size(201, 20);
            this.txt_nome_curso.TabIndex = 140;
            this.txt_nome_curso.TabStop = false;
            // 
            // lb_nome_curso
            // 
            this.lb_nome_curso.AutoSize = true;
            this.lb_nome_curso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nome_curso.ForeColor = System.Drawing.Color.Black;
            this.lb_nome_curso.Location = new System.Drawing.Point(36, 90);
            this.lb_nome_curso.Name = "lb_nome_curso";
            this.lb_nome_curso.Size = new System.Drawing.Size(110, 22);
            this.lb_nome_curso.TabIndex = 139;
            this.lb_nome_curso.Text = "Nome Curso";
            // 
            // txt_nome_turma
            // 
            this.txt_nome_turma.Location = new System.Drawing.Point(181, 63);
            this.txt_nome_turma.Multiline = true;
            this.txt_nome_turma.Name = "txt_nome_turma";
            this.txt_nome_turma.Size = new System.Drawing.Size(110, 20);
            this.txt_nome_turma.TabIndex = 142;
            this.txt_nome_turma.TabStop = false;
            // 
            // lb_turma
            // 
            this.lb_turma.AutoSize = true;
            this.lb_turma.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_turma.ForeColor = System.Drawing.Color.Black;
            this.lb_turma.Location = new System.Drawing.Point(177, 38);
            this.lb_turma.Name = "lb_turma";
            this.lb_turma.Size = new System.Drawing.Size(114, 22);
            this.lb_turma.TabIndex = 141;
            this.lb_turma.Text = "Nome Turma";
            // 
            // lb_tipo_curso
            // 
            this.lb_tipo_curso.AutoSize = true;
            this.lb_tipo_curso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_tipo_curso.ForeColor = System.Drawing.Color.Black;
            this.lb_tipo_curso.Location = new System.Drawing.Point(33, 333);
            this.lb_tipo_curso.Name = "lb_tipo_curso";
            this.lb_tipo_curso.Size = new System.Drawing.Size(46, 22);
            this.lb_tipo_curso.TabIndex = 186;
            this.lb_tipo_curso.Text = "Tipo";
            // 
            // cb_periodo
            // 
            this.cb_periodo.BackColor = System.Drawing.Color.White;
            this.cb_periodo.DropDownHeight = 200;
            this.cb_periodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_periodo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_periodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_periodo.ForeColor = System.Drawing.Color.Black;
            this.cb_periodo.FormattingEnabled = true;
            this.cb_periodo.IntegralHeight = false;
            this.cb_periodo.ItemHeight = 16;
            this.cb_periodo.Items.AddRange(new object[] {
            "M",
            "T",
            "N",
            " I"});
            this.cb_periodo.Location = new System.Drawing.Point(37, 289);
            this.cb_periodo.Name = "cb_periodo";
            this.cb_periodo.Size = new System.Drawing.Size(103, 24);
            this.cb_periodo.TabIndex = 189;
            // 
            // lb_periodo
            // 
            this.lb_periodo.AutoSize = true;
            this.lb_periodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_periodo.ForeColor = System.Drawing.Color.Black;
            this.lb_periodo.Location = new System.Drawing.Point(36, 264);
            this.lb_periodo.Name = "lb_periodo";
            this.lb_periodo.Size = new System.Drawing.Size(72, 22);
            this.lb_periodo.TabIndex = 188;
            this.lb_periodo.Text = "Periodo";
            // 
            // cb_quantidade_modulos
            // 
            this.cb_quantidade_modulos.BackColor = System.Drawing.Color.White;
            this.cb_quantidade_modulos.DropDownHeight = 200;
            this.cb_quantidade_modulos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_quantidade_modulos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_quantidade_modulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_quantidade_modulos.ForeColor = System.Drawing.Color.Black;
            this.cb_quantidade_modulos.FormattingEnabled = true;
            this.cb_quantidade_modulos.IntegralHeight = false;
            this.cb_quantidade_modulos.ItemHeight = 16;
            this.cb_quantidade_modulos.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cb_quantidade_modulos.Location = new System.Drawing.Point(37, 224);
            this.cb_quantidade_modulos.Name = "cb_quantidade_modulos";
            this.cb_quantidade_modulos.Size = new System.Drawing.Size(103, 24);
            this.cb_quantidade_modulos.TabIndex = 191;
            // 
            // lb_quantidade_modulos
            // 
            this.lb_quantidade_modulos.AutoSize = true;
            this.lb_quantidade_modulos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_quantidade_modulos.ForeColor = System.Drawing.Color.Black;
            this.lb_quantidade_modulos.Location = new System.Drawing.Point(33, 203);
            this.lb_quantidade_modulos.Name = "lb_quantidade_modulos";
            this.lb_quantidade_modulos.Size = new System.Drawing.Size(77, 22);
            this.lb_quantidade_modulos.TabIndex = 190;
            this.lb_quantidade_modulos.Text = "Módulos";
            // 
            // txt_tipo_curso
            // 
            this.txt_tipo_curso.Location = new System.Drawing.Point(38, 358);
            this.txt_tipo_curso.Multiline = true;
            this.txt_tipo_curso.Name = "txt_tipo_curso";
            this.txt_tipo_curso.Size = new System.Drawing.Size(110, 20);
            this.txt_tipo_curso.TabIndex = 192;
            this.txt_tipo_curso.TabStop = false;
            // 
            // btn_cadastrar
            // 
            this.btn_cadastrar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_cadastrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cadastrar.FlatAppearance.BorderSize = 0;
            this.btn_cadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_cadastrar.ForeColor = System.Drawing.Color.White;
            this.btn_cadastrar.Location = new System.Drawing.Point(317, 421);
            this.btn_cadastrar.Name = "btn_cadastrar";
            this.btn_cadastrar.Size = new System.Drawing.Size(90, 40);
            this.btn_cadastrar.TabIndex = 193;
            this.btn_cadastrar.Text = "Cadastrar";
            this.btn_cadastrar.UseVisualStyleBackColor = false;
            this.btn_cadastrar.Click += new System.EventHandler(this.btn_cadastrar_Click);
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
            this.cb_cod_instituicao.Location = new System.Drawing.Point(37, 170);
            this.cb_cod_instituicao.Name = "cb_cod_instituicao";
            this.cb_cod_instituicao.Size = new System.Drawing.Size(103, 24);
            this.cb_cod_instituicao.TabIndex = 195;
            // 
            // lb_cod_instituicao
            // 
            this.lb_cod_instituicao.AutoSize = true;
            this.lb_cod_instituicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_cod_instituicao.ForeColor = System.Drawing.Color.Black;
            this.lb_cod_instituicao.Location = new System.Drawing.Point(33, 149);
            this.lb_cod_instituicao.Name = "lb_cod_instituicao";
            this.lb_cod_instituicao.Size = new System.Drawing.Size(128, 22);
            this.lb_cod_instituicao.TabIndex = 194;
            this.lb_cod_instituicao.Text = "Cod Instituição";
            // 
            // lb_cod_curso
            // 
            this.lb_cod_curso.AutoSize = true;
            this.lb_cod_curso.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_cod_curso.ForeColor = System.Drawing.Color.Black;
            this.lb_cod_curso.Location = new System.Drawing.Point(33, 38);
            this.lb_cod_curso.Name = "lb_cod_curso";
            this.lb_cod_curso.Size = new System.Drawing.Size(120, 22);
            this.lb_cod_curso.TabIndex = 197;
            this.lb_cod_curso.Text = "Codigo Curso";
            // 
            // nud_cod_curso
            // 
            this.nud_cod_curso.Location = new System.Drawing.Point(37, 63);
            this.nud_cod_curso.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nud_cod_curso.Name = "nud_cod_curso";
            this.nud_cod_curso.Size = new System.Drawing.Size(98, 20);
            this.nud_cod_curso.TabIndex = 196;
            // 
            // btn_excluir
            // 
            this.btn_excluir.BackColor = System.Drawing.Color.Crimson;
            this.btn_excluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_excluir.FlatAppearance.BorderSize = 0;
            this.btn_excluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_excluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_excluir.ForeColor = System.Drawing.Color.White;
            this.btn_excluir.Location = new System.Drawing.Point(86, 421);
            this.btn_excluir.Name = "btn_excluir";
            this.btn_excluir.Size = new System.Drawing.Size(90, 40);
            this.btn_excluir.TabIndex = 199;
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
            this.btn_alterar.Location = new System.Drawing.Point(200, 421);
            this.btn_alterar.Name = "btn_alterar";
            this.btn_alterar.Size = new System.Drawing.Size(90, 40);
            this.btn_alterar.TabIndex = 198;
            this.btn_alterar.Text = "Alterar";
            this.btn_alterar.UseVisualStyleBackColor = false;
            // 
            // F_CadCursos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 473);
            this.Controls.Add(this.btn_excluir);
            this.Controls.Add(this.btn_alterar);
            this.Controls.Add(this.lb_cod_curso);
            this.Controls.Add(this.nud_cod_curso);
            this.Controls.Add(this.cb_cod_instituicao);
            this.Controls.Add(this.lb_cod_instituicao);
            this.Controls.Add(this.btn_cadastrar);
            this.Controls.Add(this.txt_tipo_curso);
            this.Controls.Add(this.cb_quantidade_modulos);
            this.Controls.Add(this.lb_quantidade_modulos);
            this.Controls.Add(this.cb_periodo);
            this.Controls.Add(this.lb_periodo);
            this.Controls.Add(this.lb_tipo_curso);
            this.Controls.Add(this.txt_nome_turma);
            this.Controls.Add(this.lb_turma);
            this.Controls.Add(this.txt_nome_curso);
            this.Controls.Add(this.lb_nome_curso);
            this.Name = "F_CadCursos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F_CadCursos";
            this.Load += new System.EventHandler(this.F_CadCursos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_cod_curso)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_nome_curso;
        private System.Windows.Forms.Label lb_nome_curso;
        private System.Windows.Forms.TextBox txt_nome_turma;
        private System.Windows.Forms.Label lb_turma;
        private System.Windows.Forms.Label lb_tipo_curso;
        private System.Windows.Forms.ComboBox cb_periodo;
        private System.Windows.Forms.Label lb_periodo;
        private System.Windows.Forms.ComboBox cb_quantidade_modulos;
        private System.Windows.Forms.Label lb_quantidade_modulos;
        private System.Windows.Forms.TextBox txt_tipo_curso;
        private System.Windows.Forms.Button btn_cadastrar;
        private System.Windows.Forms.ComboBox cb_cod_instituicao;
        private System.Windows.Forms.Label lb_cod_instituicao;
        private System.Windows.Forms.Label lb_cod_curso;
        private System.Windows.Forms.NumericUpDown nud_cod_curso;
        private System.Windows.Forms.Button btn_excluir;
        private System.Windows.Forms.Button btn_alterar;
    }
}