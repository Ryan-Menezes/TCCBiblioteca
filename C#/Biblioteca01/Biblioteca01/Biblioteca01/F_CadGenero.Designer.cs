namespace Biblioteca01
{
    partial class F_CadGenero
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
            this.txt_genero = new System.Windows.Forms.TextBox();
            this.lb_genero = new System.Windows.Forms.Label();
            this.btn_cadastrar = new System.Windows.Forms.Button();
            this.bt_cancelar = new System.Windows.Forms.Button();
            this.btn_excluir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_genero
            // 
            this.txt_genero.Location = new System.Drawing.Point(52, 81);
            this.txt_genero.Name = "txt_genero";
            this.txt_genero.Size = new System.Drawing.Size(188, 20);
            this.txt_genero.TabIndex = 57;
            // 
            // lb_genero
            // 
            this.lb_genero.AutoSize = true;
            this.lb_genero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_genero.ForeColor = System.Drawing.Color.Black;
            this.lb_genero.Location = new System.Drawing.Point(48, 58);
            this.lb_genero.Name = "lb_genero";
            this.lb_genero.Size = new System.Drawing.Size(67, 20);
            this.lb_genero.TabIndex = 56;
            this.lb_genero.Text = "Gênero:";
            // 
            // btn_cadastrar
            // 
            this.btn_cadastrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(135)))), ((int)(((byte)(245)))));
            this.btn_cadastrar.FlatAppearance.BorderSize = 0;
            this.btn_cadastrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cadastrar.ForeColor = System.Drawing.Color.White;
            this.btn_cadastrar.Location = new System.Drawing.Point(231, 133);
            this.btn_cadastrar.Name = "btn_cadastrar";
            this.btn_cadastrar.Size = new System.Drawing.Size(72, 30);
            this.btn_cadastrar.TabIndex = 55;
            this.btn_cadastrar.Text = "Cadastrar";
            this.btn_cadastrar.UseVisualStyleBackColor = false;
            this.btn_cadastrar.Click += new System.EventHandler(this.btn_cadastrar_Click);
            // 
            // bt_cancelar
            // 
            this.bt_cancelar.BackColor = System.Drawing.Color.Gold;
            this.bt_cancelar.FlatAppearance.BorderSize = 0;
            this.bt_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_cancelar.ForeColor = System.Drawing.Color.White;
            this.bt_cancelar.Location = new System.Drawing.Point(21, 133);
            this.bt_cancelar.Name = "bt_cancelar";
            this.bt_cancelar.Size = new System.Drawing.Size(77, 30);
            this.bt_cancelar.TabIndex = 54;
            this.bt_cancelar.Text = "Cancelar";
            this.bt_cancelar.UseVisualStyleBackColor = false;
            this.bt_cancelar.Click += new System.EventHandler(this.bt_cancelar_Click);
            // 
            // btn_excluir
            // 
            this.btn_excluir.BackColor = System.Drawing.Color.Red;
            this.btn_excluir.FlatAppearance.BorderSize = 0;
            this.btn_excluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_excluir.ForeColor = System.Drawing.Color.White;
            this.btn_excluir.Location = new System.Drawing.Point(131, 133);
            this.btn_excluir.Name = "btn_excluir";
            this.btn_excluir.Size = new System.Drawing.Size(72, 30);
            this.btn_excluir.TabIndex = 58;
            this.btn_excluir.Text = "Excluir";
            this.btn_excluir.UseVisualStyleBackColor = false;
            this.btn_excluir.Click += new System.EventHandler(this.btn_excluir_Click);
            // 
            // F_CadGenero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 185);
            this.Controls.Add(this.btn_excluir);
            this.Controls.Add(this.txt_genero);
            this.Controls.Add(this.lb_genero);
            this.Controls.Add(this.btn_cadastrar);
            this.Controls.Add(this.bt_cancelar);
            this.Name = "F_CadGenero";
            this.Text = "F_CadGenero";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_genero;
        private System.Windows.Forms.Label lb_genero;
        private System.Windows.Forms.Button btn_cadastrar;
        private System.Windows.Forms.Button bt_cancelar;
        private System.Windows.Forms.Button btn_excluir;
    }
}