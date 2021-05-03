using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace BibliotecaEtec
{
    public partial class Form1 : Form
    {
        int voltas = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tempo.Enabled = true;
            tempo.Start();
        }

        private void tempo_Tick(object sender, EventArgs e)
        {
            if(voltas < 5)
            {
                if (!trabalhoFundo.IsBusy)
                {
                    trabalhoFundo.RunWorkerAsync();
                }
            }
            else
            {
                tempo.Stop();
                tempo.Enabled = false;
                this.Visible = false;

                Globais.TelaLogin.Show();
            }
        }

        private void trabalhoFundo_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1000);
            voltas++;
            trabalhoFundo.ReportProgress(0);
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Globais.logado)
            {
                Globais.tela.Visible = true;
                Globais.tela.WindowState = FormWindowState.Maximized;
            }
            else
            {
                MessageBox.Show("Acesso negado, você não fez o login!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Definindo movimentação do form

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
