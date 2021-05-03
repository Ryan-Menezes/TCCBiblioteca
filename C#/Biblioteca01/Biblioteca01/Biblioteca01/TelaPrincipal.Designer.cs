namespace Biblioteca01
{
    partial class TelaPrincipal
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
            this.panel4 = new System.Windows.Forms.Panel();
            this.lb_nome_usuario = new System.Windows.Forms.Label();
            this.lb_nome = new System.Windows.Forms.Label();
            this.img_perfil = new System.Windows.Forms.PictureBox();
            this.btn_inicio = new System.Windows.Forms.Button();
            this.btn_cursos = new System.Windows.Forms.Button();
            this.btn_livros = new System.Windows.Forms.Button();
            this.btn_alunos = new System.Windows.Forms.Button();
            this.btn_professores = new System.Windows.Forms.Button();
            this.btn_locacoes = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_funcionario = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_perfil)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.lb_nome_usuario);
            this.panel4.Controls.Add(this.lb_nome);
            this.panel4.Controls.Add(this.img_perfil);
            this.panel4.Location = new System.Drawing.Point(1, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(205, 216);
            this.panel4.TabIndex = 0;
            // 
            // lb_nome_usuario
            // 
            this.lb_nome_usuario.AutoSize = true;
            this.lb_nome_usuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nome_usuario.ForeColor = System.Drawing.Color.Black;
            this.lb_nome_usuario.Location = new System.Drawing.Point(89, 184);
            this.lb_nome_usuario.Name = "lb_nome_usuario";
            this.lb_nome_usuario.Size = new System.Drawing.Size(38, 22);
            this.lb_nome_usuario.TabIndex = 139;
            this.lb_nome_usuario.Text = "- - -";
            // 
            // lb_nome
            // 
            this.lb_nome.AutoSize = true;
            this.lb_nome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nome.ForeColor = System.Drawing.Color.Black;
            this.lb_nome.Location = new System.Drawing.Point(11, 184);
            this.lb_nome.Name = "lb_nome";
            this.lb_nome.Size = new System.Drawing.Size(72, 22);
            this.lb_nome.TabIndex = 138;
            this.lb_nome.Text = "Usuario";
            // 
            // img_perfil
            // 
            this.img_perfil.Location = new System.Drawing.Point(49, 43);
            this.img_perfil.Name = "img_perfil";
            this.img_perfil.Size = new System.Drawing.Size(106, 117);
            this.img_perfil.TabIndex = 0;
            this.img_perfil.TabStop = false;
            // 
            // btn_inicio
            // 
            this.btn_inicio.Location = new System.Drawing.Point(1, 223);
            this.btn_inicio.Name = "btn_inicio";
            this.btn_inicio.Size = new System.Drawing.Size(205, 42);
            this.btn_inicio.TabIndex = 1;
            this.btn_inicio.Text = "Inicio";
            this.btn_inicio.UseVisualStyleBackColor = true;
            // 
            // btn_cursos
            // 
            this.btn_cursos.Location = new System.Drawing.Point(1, 314);
            this.btn_cursos.Name = "btn_cursos";
            this.btn_cursos.Size = new System.Drawing.Size(205, 40);
            this.btn_cursos.TabIndex = 2;
            this.btn_cursos.Text = "Cursos";
            this.btn_cursos.UseVisualStyleBackColor = true;
            this.btn_cursos.Click += new System.EventHandler(this.btn_cursos_Click_1);
            // 
            // btn_livros
            // 
            this.btn_livros.Location = new System.Drawing.Point(1, 360);
            this.btn_livros.Name = "btn_livros";
            this.btn_livros.Size = new System.Drawing.Size(205, 40);
            this.btn_livros.TabIndex = 3;
            this.btn_livros.Text = "Livros";
            this.btn_livros.UseVisualStyleBackColor = true;
            this.btn_livros.Click += new System.EventHandler(this.btn_livros_Click);
            // 
            // btn_alunos
            // 
            this.btn_alunos.Location = new System.Drawing.Point(1, 406);
            this.btn_alunos.Name = "btn_alunos";
            this.btn_alunos.Size = new System.Drawing.Size(205, 39);
            this.btn_alunos.TabIndex = 4;
            this.btn_alunos.Text = "Alunos";
            this.btn_alunos.UseVisualStyleBackColor = true;
            this.btn_alunos.Click += new System.EventHandler(this.btn_alunos_Click);
            // 
            // btn_professores
            // 
            this.btn_professores.Location = new System.Drawing.Point(1, 451);
            this.btn_professores.Name = "btn_professores";
            this.btn_professores.Size = new System.Drawing.Size(205, 38);
            this.btn_professores.TabIndex = 5;
            this.btn_professores.Text = "Professores";
            this.btn_professores.UseVisualStyleBackColor = true;
            this.btn_professores.Click += new System.EventHandler(this.btn_professores_Click);
            // 
            // btn_locacoes
            // 
            this.btn_locacoes.Location = new System.Drawing.Point(1, 271);
            this.btn_locacoes.Name = "btn_locacoes";
            this.btn_locacoes.Size = new System.Drawing.Size(205, 37);
            this.btn_locacoes.TabIndex = 7;
            this.btn_locacoes.Text = "Locações";
            this.btn_locacoes.UseVisualStyleBackColor = true;
            this.btn_locacoes.Click += new System.EventHandler(this.btn_locacoes_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(223, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(645, 74);
            this.panel2.TabIndex = 8;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(583, 11);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 40);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(522, 11);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(27, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(87, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Biblioteca - Etec";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(223, 81);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(645, 491);
            this.panel3.TabIndex = 9;
            // 
            // btn_funcionario
            // 
            this.btn_funcionario.Location = new System.Drawing.Point(1, 495);
            this.btn_funcionario.Name = "btn_funcionario";
            this.btn_funcionario.Size = new System.Drawing.Size(205, 38);
            this.btn_funcionario.TabIndex = 10;
            this.btn_funcionario.Text = "Funcionários ";
            this.btn_funcionario.UseVisualStyleBackColor = true;
            this.btn_funcionario.Click += new System.EventHandler(this.btn_funcionario_Click);
            // 
            // TelaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 592);
            this.Controls.Add(this.btn_funcionario);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_locacoes);
            this.Controls.Add(this.btn_professores);
            this.Controls.Add(this.btn_alunos);
            this.Controls.Add(this.btn_livros);
            this.Controls.Add(this.btn_cursos);
            this.Controls.Add(this.btn_inicio);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "TelaPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TelaPrincipal";
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img_perfil)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox img_perfil;
        private System.Windows.Forms.Button btn_inicio;
        private System.Windows.Forms.Button btn_cursos;
        private System.Windows.Forms.Button btn_livros;
        private System.Windows.Forms.Button btn_alunos;
        private System.Windows.Forms.Button btn_professores;
        private System.Windows.Forms.Button btn_locacoes;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_funcionario;
        private System.Windows.Forms.Label lb_nome;
        public System.Windows.Forms.Label lb_nome_usuario;
    }
}