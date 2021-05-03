namespace BibliotecaEtec
{
    partial class TelaLogin
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.barra_senha = new System.Windows.Forms.Panel();
            this.lb_senha = new System.Windows.Forms.Label();
            this.lb_esqueciSenha = new System.Windows.Forms.LinkLabel();
            this.btn_logar = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.btn_visualizar = new FontAwesome.Sharp.IconButton();
            this.tb_senha = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.barra_rm = new System.Windows.Forms.Panel();
            this.lb_rm = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.tb_rm = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(6)))), ((int)(((byte)(6)))));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.barra_senha);
            this.panel2.Controls.Add(this.lb_senha);
            this.panel2.Controls.Add(this.lb_esqueciSenha);
            this.panel2.Controls.Add(this.btn_logar);
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(179, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(40);
            this.panel2.Size = new System.Drawing.Size(512, 381);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(37, 267);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 14);
            this.label2.TabIndex = 9;
            this.label2.Text = "Esqueceu sua senha? ";
            // 
            // barra_senha
            // 
            this.barra_senha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(62)))), ((int)(((byte)(2)))));
            this.barra_senha.Dock = System.Windows.Forms.DockStyle.Top;
            this.barra_senha.Location = new System.Drawing.Point(40, 156);
            this.barra_senha.Name = "barra_senha";
            this.barra_senha.Size = new System.Drawing.Size(432, 1);
            this.barra_senha.TabIndex = 7;
            this.barra_senha.Visible = false;
            // 
            // lb_senha
            // 
            this.lb_senha.AutoSize = true;
            this.lb_senha.BackColor = System.Drawing.Color.Transparent;
            this.lb_senha.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_senha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(62)))), ((int)(((byte)(2)))));
            this.lb_senha.Location = new System.Drawing.Point(37, 173);
            this.lb_senha.Name = "lb_senha";
            this.lb_senha.Size = new System.Drawing.Size(87, 15);
            this.lb_senha.TabIndex = 6;
            this.lb_senha.Text = "Digite a senha";
            this.lb_senha.Visible = false;
            // 
            // lb_esqueciSenha
            // 
            this.lb_esqueciSenha.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(91)))), ((int)(((byte)(148)))));
            this.lb_esqueciSenha.AutoSize = true;
            this.lb_esqueciSenha.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lb_esqueciSenha.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_esqueciSenha.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(91)))), ((int)(((byte)(148)))));
            this.lb_esqueciSenha.Location = new System.Drawing.Point(151, 267);
            this.lb_esqueciSenha.Name = "lb_esqueciSenha";
            this.lb_esqueciSenha.Size = new System.Drawing.Size(58, 14);
            this.lb_esqueciSenha.TabIndex = 4;
            this.lb_esqueciSenha.TabStop = true;
            this.lb_esqueciSenha.Text = "clique aqui";
            this.lb_esqueciSenha.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lb_esqueciSenha_LinkClicked);
            // 
            // btn_logar
            // 
            this.btn_logar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(62)))), ((int)(((byte)(2)))));
            this.btn_logar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_logar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btn_logar.FlatAppearance.BorderSize = 0;
            this.btn_logar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(41)))), ((int)(((byte)(0)))));
            this.btn_logar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(41)))), ((int)(((byte)(0)))));
            this.btn_logar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_logar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_logar.ForeColor = System.Drawing.Color.White;
            this.btn_logar.Location = new System.Drawing.Point(40, 302);
            this.btn_logar.Name = "btn_logar";
            this.btn_logar.Size = new System.Drawing.Size(432, 39);
            this.btn_logar.TabIndex = 3;
            this.btn_logar.Text = "Logar";
            this.btn_logar.UseVisualStyleBackColor = false;
            this.btn_logar.Click += new System.EventHandler(this.btn_logar_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(27)))));
            this.panel5.Controls.Add(this.iconButton1);
            this.panel5.Controls.Add(this.btn_visualizar);
            this.panel5.Controls.Add(this.tb_senha);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(40, 120);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(10);
            this.panel5.Size = new System.Drawing.Size(432, 36);
            this.panel5.TabIndex = 2;
            // 
            // iconButton1
            // 
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconSize = 19;
            this.iconButton1.Location = new System.Drawing.Point(10, 10);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Rotation = 0D;
            this.iconButton1.Size = new System.Drawing.Size(18, 16);
            this.iconButton1.TabIndex = 5;
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // btn_visualizar
            // 
            this.btn_visualizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_visualizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_visualizar.FlatAppearance.BorderSize = 0;
            this.btn_visualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btn_visualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btn_visualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_visualizar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btn_visualizar.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_visualizar.IconChar = FontAwesome.Sharp.IconChar.Eye;
            this.btn_visualizar.IconColor = System.Drawing.Color.White;
            this.btn_visualizar.IconSize = 24;
            this.btn_visualizar.Location = new System.Drawing.Point(397, 10);
            this.btn_visualizar.Name = "btn_visualizar";
            this.btn_visualizar.Rotation = 0D;
            this.btn_visualizar.Size = new System.Drawing.Size(25, 16);
            this.btn_visualizar.TabIndex = 4;
            this.btn_visualizar.UseVisualStyleBackColor = true;
            this.btn_visualizar.Click += new System.EventHandler(this.btn_visualizar_Click);
            // 
            // tb_senha
            // 
            this.tb_senha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_senha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(27)))));
            this.tb_senha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_senha.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_senha.ForeColor = System.Drawing.Color.Gray;
            this.tb_senha.Location = new System.Drawing.Point(43, 10);
            this.tb_senha.Name = "tb_senha";
            this.tb_senha.Size = new System.Drawing.Size(344, 15);
            this.tb_senha.TabIndex = 0;
            this.tb_senha.Text = "Senha";
            this.tb_senha.TextChanged += new System.EventHandler(this.tb_senha_TextChanged);
            this.tb_senha.Enter += new System.EventHandler(this.tb_senha_Enter);
            this.tb_senha.Leave += new System.EventHandler(this.tb_senha_Leave);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.barra_rm);
            this.panel4.Controls.Add(this.lb_rm);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(40, 76);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(432, 44);
            this.panel4.TabIndex = 1;
            // 
            // barra_rm
            // 
            this.barra_rm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(62)))), ((int)(((byte)(2)))));
            this.barra_rm.Dock = System.Windows.Forms.DockStyle.Top;
            this.barra_rm.Location = new System.Drawing.Point(0, 0);
            this.barra_rm.Name = "barra_rm";
            this.barra_rm.Size = new System.Drawing.Size(432, 1);
            this.barra_rm.TabIndex = 8;
            this.barra_rm.Visible = false;
            // 
            // lb_rm
            // 
            this.lb_rm.AutoSize = true;
            this.lb_rm.BackColor = System.Drawing.Color.Transparent;
            this.lb_rm.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_rm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(62)))), ((int)(((byte)(2)))));
            this.lb_rm.Location = new System.Drawing.Point(-3, 15);
            this.lb_rm.Name = "lb_rm";
            this.lb_rm.Size = new System.Drawing.Size(70, 15);
            this.lb_rm.TabIndex = 7;
            this.lb_rm.Text = "Digite o RM";
            this.lb_rm.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(27)))));
            this.panel3.Controls.Add(this.iconButton2);
            this.panel3.Controls.Add(this.tb_rm);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(40, 40);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10);
            this.panel3.Size = new System.Drawing.Size(432, 36);
            this.panel3.TabIndex = 0;
            // 
            // iconButton2
            // 
            this.iconButton2.Dock = System.Windows.Forms.DockStyle.Left;
            this.iconButton2.FlatAppearance.BorderSize = 0;
            this.iconButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.iconButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton2.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.Key;
            this.iconButton2.IconColor = System.Drawing.Color.White;
            this.iconButton2.IconSize = 19;
            this.iconButton2.Location = new System.Drawing.Point(10, 10);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Rotation = 0D;
            this.iconButton2.Size = new System.Drawing.Size(18, 16);
            this.iconButton2.TabIndex = 6;
            this.iconButton2.UseVisualStyleBackColor = true;
            // 
            // tb_rm
            // 
            this.tb_rm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(28)))), ((int)(((byte)(27)))));
            this.tb_rm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_rm.Dock = System.Windows.Forms.DockStyle.Right;
            this.tb_rm.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_rm.ForeColor = System.Drawing.Color.Gray;
            this.tb_rm.Location = new System.Drawing.Point(43, 10);
            this.tb_rm.Name = "tb_rm";
            this.tb_rm.Size = new System.Drawing.Size(379, 15);
            this.tb_rm.TabIndex = 1;
            this.tb_rm.Text = "RM";
            this.tb_rm.TextChanged += new System.EventHandler(this.tb_rm_TextChanged);
            this.tb_rm.Enter += new System.EventHandler(this.tb_rm_Enter);
            this.tb_rm.Leave += new System.EventHandler(this.tb_rm_Leave);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::BibliotecaEtec.Properties.Resources.destaque;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(179, 381);
            this.panel1.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(62)))), ((int)(((byte)(2)))));
            this.panel6.Controls.Add(this.pictureBox1);
            this.panel6.Location = new System.Drawing.Point(46, 40);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(90, 90);
            this.panel6.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.ErrorImage = global::BibliotecaEtec.Properties.Resources.cadeado;
            this.pictureBox1.Image = global::BibliotecaEtec.Properties.Resources.cadeado;
            this.pictureBox1.InitialImage = global::BibliotecaEtec.Properties.Resources.cadeado;
            this.pictureBox1.Location = new System.Drawing.Point(23, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // TelaLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.ClientSize = new System.Drawing.Size(691, 381);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "TelaLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biblioteca - Login";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TelaLogin_FormClosed);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox tb_senha;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_logar;
        private FontAwesome.Sharp.IconButton btn_visualizar;
        private System.Windows.Forms.TextBox tb_rm;
        private System.Windows.Forms.LinkLabel lb_esqueciSenha;
        private System.Windows.Forms.Label lb_senha;
        private System.Windows.Forms.Label lb_rm;
        private System.Windows.Forms.Panel barra_senha;
        private System.Windows.Forms.Panel barra_rm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton2;
    }
}