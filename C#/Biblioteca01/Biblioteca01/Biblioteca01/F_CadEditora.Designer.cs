namespace Biblioteca01
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txt_cnpj_editora = new System.Windows.Forms.TextBox();
            this.txt_nome_editora = new System.Windows.Forms.TextBox();
            this.lb_cnpj_editora = new System.Windows.Forms.Label();
            this.lb_nome_editora = new System.Windows.Forms.Label();
            this.btn_excluir = new System.Windows.Forms.Button();
            this.btn_alterar = new System.Windows.Forms.Button();
            this.btn_cadastrar = new System.Windows.Forms.Button();
            this.dgv_editora = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_editora)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_cnpj_editora
            // 
            this.txt_cnpj_editora.Location = new System.Drawing.Point(25, 121);
            this.txt_cnpj_editora.Name = "txt_cnpj_editora";
            this.txt_cnpj_editora.Size = new System.Drawing.Size(194, 20);
            this.txt_cnpj_editora.TabIndex = 60;
            // 
            // txt_nome_editora
            // 
            this.txt_nome_editora.Location = new System.Drawing.Point(25, 75);
            this.txt_nome_editora.Name = "txt_nome_editora";
            this.txt_nome_editora.Size = new System.Drawing.Size(194, 20);
            this.txt_nome_editora.TabIndex = 59;
            // 
            // lb_cnpj_editora
            // 
            this.lb_cnpj_editora.AutoSize = true;
            this.lb_cnpj_editora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_cnpj_editora.ForeColor = System.Drawing.Color.Black;
            this.lb_cnpj_editora.Location = new System.Drawing.Point(21, 98);
            this.lb_cnpj_editora.Name = "lb_cnpj_editora";
            this.lb_cnpj_editora.Size = new System.Drawing.Size(52, 22);
            this.lb_cnpj_editora.TabIndex = 58;
            this.lb_cnpj_editora.Text = "Cnpj:";
            // 
            // lb_nome_editora
            // 
            this.lb_nome_editora.AutoSize = true;
            this.lb_nome_editora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_nome_editora.ForeColor = System.Drawing.Color.Black;
            this.lb_nome_editora.Location = new System.Drawing.Point(21, 47);
            this.lb_nome_editora.Name = "lb_nome_editora";
            this.lb_nome_editora.Size = new System.Drawing.Size(62, 22);
            this.lb_nome_editora.TabIndex = 57;
            this.lb_nome_editora.Text = "Nome:";
            // 
            // btn_excluir
            // 
            this.btn_excluir.BackColor = System.Drawing.Color.Crimson;
            this.btn_excluir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_excluir.FlatAppearance.BorderSize = 0;
            this.btn_excluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_excluir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_excluir.ForeColor = System.Drawing.Color.White;
            this.btn_excluir.Location = new System.Drawing.Point(11, 257);
            this.btn_excluir.Name = "btn_excluir";
            this.btn_excluir.Size = new System.Drawing.Size(90, 40);
            this.btn_excluir.TabIndex = 98;
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
            this.btn_alterar.Location = new System.Drawing.Point(131, 257);
            this.btn_alterar.Name = "btn_alterar";
            this.btn_alterar.Size = new System.Drawing.Size(90, 40);
            this.btn_alterar.TabIndex = 97;
            this.btn_alterar.Text = "Alterar";
            this.btn_alterar.UseVisualStyleBackColor = false;
            // 
            // btn_cadastrar
            // 
            this.btn_cadastrar.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.btn_cadastrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_cadastrar.FlatAppearance.BorderSize = 0;
            this.btn_cadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadastrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_cadastrar.ForeColor = System.Drawing.Color.White;
            this.btn_cadastrar.Location = new System.Drawing.Point(244, 257);
            this.btn_cadastrar.Name = "btn_cadastrar";
            this.btn_cadastrar.Size = new System.Drawing.Size(90, 40);
            this.btn_cadastrar.TabIndex = 96;
            this.btn_cadastrar.Text = "Cadastrar";
            this.btn_cadastrar.UseVisualStyleBackColor = false;
            this.btn_cadastrar.Click += new System.EventHandler(this.btn_cadastrar_Click);
            // 
            // dgv_editora
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.471698F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_editora.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_editora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_editora.EnableHeadersVisualStyles = false;
            this.dgv_editora.Location = new System.Drawing.Point(340, 12);
            this.dgv_editora.MultiSelect = false;
            this.dgv_editora.Name = "dgv_editora";
            this.dgv_editora.RowHeadersVisible = false;
            this.dgv_editora.RowHeadersWidth = 45;
            this.dgv_editora.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_editora.Size = new System.Drawing.Size(358, 240);
            this.dgv_editora.TabIndex = 100;
            // 
            // F_CadEditora
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 309);
            this.Controls.Add(this.dgv_editora);
            this.Controls.Add(this.btn_excluir);
            this.Controls.Add(this.btn_alterar);
            this.Controls.Add(this.btn_cadastrar);
            this.Controls.Add(this.txt_cnpj_editora);
            this.Controls.Add(this.txt_nome_editora);
            this.Controls.Add(this.lb_cnpj_editora);
            this.Controls.Add(this.lb_nome_editora);
            this.Name = "F_CadEditora";
            this.Text = "F_CadEditora";
            this.Load += new System.EventHandler(this.F_CadEditora_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_editora)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_cnpj_editora;
        private System.Windows.Forms.TextBox txt_nome_editora;
        private System.Windows.Forms.Label lb_cnpj_editora;
        private System.Windows.Forms.Label lb_nome_editora;
        private System.Windows.Forms.Button btn_excluir;
        private System.Windows.Forms.Button btn_alterar;
        private System.Windows.Forms.Button btn_cadastrar;
        private System.Windows.Forms.DataGridView dgv_editora;
    }
}