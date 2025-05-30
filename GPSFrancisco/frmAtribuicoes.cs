using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GPSFrancisco
{
    public partial class frmAtribuicoes : Form
    {
        //Criando variáveis para controle do menu
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);

        public frmAtribuicoes()
        {
            InitializeComponent();
            desabilitarCampos();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal();
            abrir.Show();
            this.Hide();
        }

        private void frmAtribuicoes_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);

        }
        public void limparCampos()
        {
            txtCodigo.Clear();
            txtNome.Clear();
        }
        public void desabilitarCampos()
        {
            txtCodigo.Enabled = false;
            txtNome.Enabled = false;
            btnCadastrar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = false;

        }
        public void habilitarCamposNovo()
        {
            txtCodigo.Enabled = false;
            txtNome.Enabled = true;
            btnCadastrar.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = true;
            btnPesquisar.Enabled = true;
            txtNome.Focus();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCamposNovo();
            btnNovo.Enabled = false;

        }

        //criando o metodo cadastrar atribuições
        public int cadastrarAtribuicoes(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "insert into tbAtribuicoes(nome)values(@nome);";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = nome;

            comm.Connection = Conexao.obterConexao();

            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;
        }

        //criando o metodo alterar atribuições
        public int alterarAtribuicoes(int codigo, string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "update tbAtribuicoes set nome = @nome where codAtr = " + codigo;
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = nome;

            comm.Connection = Conexao.obterConexao();

            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;
        }

        //criando o metodo excluir atribuições
        public int excluirAtribuicoes(int codigo)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "delete from tbAtribuicoes where codAtr = @codAtr;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@codAtr", MySqlDbType.VarChar, 100).Value = codigo;

            comm.Connection = Conexao.obterConexao();

            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
            desabilitarCampos();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Equals(""))
            {
                MessageBox.Show("Favor inserir valores.",
                    "Mensagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1
                    );
                limparCampos();
                txtNome.Focus();
            }
            else
            {
                if (cadastrarAtribuicoes(txtNome.Text) == 1)
                {
                    MessageBox.Show("Atribuição cadastrada com sucesso.",
                        "Mensagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1
                    );
                    limparCampos();
                    desabilitarCampos();
                    btnNovo.Enabled = true;
                }

            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            prtAtribuicoes.Print();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (alterarAtribuicoes(Convert.ToInt32(txtCodigo.Text), txtNome.Text) == 1)
            {
                MessageBox.Show("Atribuição alterada com sucesso.",
                       "Mensagem do sistema",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   MessageBoxDefaultButton.Button1
                   );
                limparCampos();
                desabilitarCampos();
                btnNovo.Enabled = true;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Deseja excluir a atribuição?.",
                       "Mensagem do sistema",
                   MessageBoxButtons.YesNo,
                   MessageBoxIcon.Question,
                   MessageBoxDefaultButton.Button2
                   );
            if (result == DialogResult.Yes)
            {
                if (excluirAtribuicoes(Convert.ToInt32(txtCodigo.Text)) == 1)
                {
                    MessageBox.Show("Atribuição excluída com sucesso.",
                           "Mensagem do sistema",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Error,
                       MessageBoxDefaultButton.Button1
                       );
                    limparCampos();
                    desabilitarCampos();
                    btnNovo.Enabled = true;
                }
            }
            else
            {

                MessageBox.Show("Erro ao excluir.",
                       "Mensagem do sistema",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   MessageBoxDefaultButton.Button1
                   );
            }

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisarAtribuicoes abrir = new frmPesquisarAtribuicoes();
            abrir.Show();
            this.Hide();
        }
    }
}
