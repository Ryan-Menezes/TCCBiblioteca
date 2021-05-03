namespace Biblioteca01
{
    partial class F_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_Login));
            this.btn_logar = new System.Windows.Forms.Button();
            this.lb_esqueciSenha = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_instituicao = new System.Windows.Forms.ComboBox();
            this.lb_senha = new System.Windows.Forms.Label();
            this.lb_rm = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_visualizar = new System.Windows.Forms.Button();
            this.txt_senha = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_rm = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_logar
            // 
            this.btn_logar.Location = new System.Drawing.Point(256, 300);
            this.btn_logar.Name = "btn_logar";
            this.btn_logar.Size = new System.Drawing.Size(388, 39);
            this.btn_logar.TabIndex = 29;
            this.btn_logar.Text = "Logar";
            this.btn_logar.UseVisualStyleBackColor = true;
            this.btn_logar.Click += new System.EventHandler(this.btn_logar_Click);
            // 
            // lb_esqueciSenha
            // 
            this.lb_esqueciSenha.AutoSize = true;
            this.lb_esqueciSenha.Location = new System.Drawing.Point(416, 268);
            this.lb_esqueciSenha.Name = "lb_esqueciSenha";
            this.lb_esqueciSenha.Size = new System.Drawing.Size(58, 13);
            this.lb_esqueciSenha.TabIndex = 28;
            this.lb_esqueciSenha.TabStop = true;
            this.lb_esqueciSenha.Text = "clique aqui";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(253, 268);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Esqueceu sua senha?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(427, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Instituição:";
            // 
            // cb_instituicao
            // 
            this.cb_instituicao.FormattingEnabled = true;
            this.cb_instituicao.Location = new System.Drawing.Point(430, 209);
            this.cb_instituicao.Name = "cb_instituicao";
            this.cb_instituicao.Size = new System.Drawing.Size(214, 21);
            this.cb_instituicao.TabIndex = 25;
            // 
            // lb_senha
            // 
            this.lb_senha.AutoSize = true;
            this.lb_senha.Location = new System.Drawing.Point(263, 163);
            this.lb_senha.Name = "lb_senha";
            this.lb_senha.Size = new System.Drawing.Size(75, 13);
            this.lb_senha.TabIndex = 24;
            this.lb_senha.Text = "Digite a senha";
            // 
            // lb_rm
            // 
            this.lb_rm.AutoSize = true;
            this.lb_rm.Location = new System.Drawing.Point(268, 69);
            this.lb_rm.Name = "lb_rm";
            this.lb_rm.Size = new System.Drawing.Size(63, 13);
            this.lb_rm.TabIndex = 23;
            this.lb_rm.Text = "Digite o RM";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btn_visualizar);
            this.panel3.Controls.Add(this.txt_senha);
            this.panel3.Location = new System.Drawing.Point(256, 120);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10);
            this.panel3.Size = new System.Drawing.Size(388, 40);
            this.panel3.TabIndex = 22;
            // 
            // btn_visualizar
            // 
            this.btn_visualizar.Location = new System.Drawing.Point(352, 10);
            this.btn_visualizar.Name = "btn_visualizar";
            this.btn_visualizar.Size = new System.Drawing.Size(29, 20);
            this.btn_visualizar.TabIndex = 2;
            this.btn_visualizar.UseVisualStyleBackColor = true;
            // 
            // txt_senha
            // 
            this.txt_senha.Location = new System.Drawing.Point(10, 10);
            this.txt_senha.Name = "txt_senha";
            this.txt_senha.PasswordChar = '*';
            this.txt_senha.Size = new System.Drawing.Size(337, 20);
            this.txt_senha.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_rm);
            this.panel2.Location = new System.Drawing.Point(256, 26);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(388, 40);
            this.panel2.TabIndex = 21;
            // 
            // txt_rm
            // 
            this.txt_rm.Location = new System.Drawing.Point(13, 7);
            this.txt_rm.Name = "txt_rm";
            this.txt_rm.Size = new System.Drawing.Size(368, 20);
            this.txt_rm.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(221, 368);
            this.panel1.TabIndex = 20;
            // 
            // pictureBox1
            // 
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(59, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(97, 77);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // F_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 368);
            this.Controls.Add(this.btn_logar);
            this.Controls.Add(this.lb_esqueciSenha);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cb_instituicao);
            this.Controls.Add(this.lb_senha);
            this.Controls.Add(this.lb_rm);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "F_Login";
            this.Text = "F_Login";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_logar;
        private System.Windows.Forms.LinkLabel lb_esqueciSenha;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_instituicao;
        private System.Windows.Forms.Label lb_senha;
        private System.Windows.Forms.Label lb_rm;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_visualizar;
        private System.Windows.Forms.TextBox txt_senha;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_rm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}