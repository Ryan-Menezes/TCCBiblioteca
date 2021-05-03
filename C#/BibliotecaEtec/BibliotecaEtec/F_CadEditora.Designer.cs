namespace BibliotecaEtec
{
    partial class F_CadEditora
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
            this.lb_cnpj = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_nome_editora = new System.Windows.Forms.TextBox();
            this.txt_cnpj_editora = new System.Windows.Forms.MaskedTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lb_nome = new System.Windows.Forms.Label();
            this.btn_executa = new System.Windows.Forms.Button();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_cnpj
            // 
            this.lb_cnpj.AutoSize = true;
            this.lb_cnpj.BackColor = System.Drawing.Color.Transparent;
            this.lb_cnpj.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_cnpj.ForeColor = System.Drawing.Color.White;
            this.lb_cnpj.Location = new System.Drawing.Point(28, 173);
            this.lb_cnpj.Name = "lb_cnpj";
            this.lb_cnpj.Size = new System.Drawing.Size(53, 20);
            this.lb_cnpj.TabIndex = 106;
            this.lb_cnpj.Text = "CNPJ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(28, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 20);
            this.label2.TabIndex = 103;
            this.label2.Text = "Nome: ";
            // 
            // txt_nome_editora
            // 
            this.txt_nome_editora.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_nome_editora.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.txt_nome_editora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_nome_editora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F);
            this.txt_nome_editora.ForeColor = System.Drawing.Color.White;
            this.txt_nome_editora.Location = new System.Drawing.Point(32, 116);
            this.txt_nome_editora.Name = "txt_nome_editora";
            this.txt_nome_editora.Size = new System.Drawing.Size(370, 26);
            this.txt_nome_editora.TabIndex = 102;
            this.txt_nome_editora.TextChanged += new System.EventHandler(this.txt_nome_editora_TextChanged);
            // 
            // txt_cnpj_editora
            // 
            this.txt_cnpj_editora.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.txt_cnpj_editora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_cnpj_editora.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txt_cnpj_editora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txt_cnpj_editora.ForeColor = System.Drawing.Color.White;
            this.txt_cnpj_editora.Location = new System.Drawing.Point(32, 209);
            this.txt_cnpj_editora.Mask = "00.000.000/0000-00";
            this.txt_cnpj_editora.Name = "txt_cnpj_editora";
            this.txt_cnpj_editora.Size = new System.Drawing.Size(370, 26);
            this.txt_cnpj_editora.TabIndex = 110;
            this.txt_cnpj_editora.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
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
            this.panel3.Size = new System.Drawing.Size(433, 52);
            this.panel3.TabIndex = 111;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.Image = global::BibliotecaEtec.Properties.Resources.LogoJKCircular;
            this.pictureBox4.Location = new System.Drawing.Point(390, 12);
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
            this.pictureBox3.Location = new System.Drawing.Point(354, 12);
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
            this.label1.Size = new System.Drawing.Size(174, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Biblioteca - Cadastar Editora";
            // 
            // lb_nome
            // 
            this.lb_nome.AutoSize = true;
            this.lb_nome.BackColor = System.Drawing.Color.Transparent;
            this.lb_nome.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nome.ForeColor = System.Drawing.Color.Maroon;
            this.lb_nome.Location = new System.Drawing.Point(29, 145);
            this.lb_nome.Name = "lb_nome";
            this.lb_nome.Size = new System.Drawing.Size(142, 15);
            this.lb_nome.TabIndex = 112;
            this.lb_nome.Text = "Digite o nome da editora";
            this.lb_nome.Visible = false;
            // 
            // btn_executa
            // 
            this.btn_executa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(135)))), ((int)(((byte)(245)))));
            this.btn_executa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_executa.FlatAppearance.BorderSize = 0;
            this.btn_executa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_executa.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_executa.ForeColor = System.Drawing.Color.White;
            this.btn_executa.Location = new System.Drawing.Point(31, 281);
            this.btn_executa.Name = "btn_executa";
            this.btn_executa.Size = new System.Drawing.Size(140, 35);
            this.btn_executa.TabIndex = 113;
            this.btn_executa.Text = "Cadastrar Editora";
            this.btn_executa.UseVisualStyleBackColor = false;
            this.btn_executa.Click += new System.EventHandler(this.btn_executa_Click);
            // 
            // F_CadEditora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(7)))), ((int)(((byte)(7)))));
            this.ClientSize = new System.Drawing.Size(433, 349);
            this.Controls.Add(this.btn_executa);
            this.Controls.Add(this.lb_nome);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.txt_cnpj_editora);
            this.Controls.Add(this.lb_cnpj);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_nome_editora);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "F_CadEditora";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Biblioteca - Cadastro Editora";
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb_cnpj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_nome_editora;
        private System.Windows.Forms.MaskedTextBox txt_cnpj_editora;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_nome;
        private System.Windows.Forms.Button btn_executa;
    }
}