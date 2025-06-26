using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MySql.Data.MySqlClient;

namespace GPSFrancisco
{
    public partial class frmUnidades : Form
    {
        //Criando variáveis para controle do menu
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);

        public frmUnidades()
        {
            InitializeComponent();
            desabilitarCampos();
        }
        public frmUnidades(string descricao)
        {
            InitializeComponent();
            desabilitarCampos();
            txtDescricao.Text = descricao;
            pesquisarPorNome(txtDescricao.Text);
        }
        private void frmUnidades_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmGerenciarProdutos abrir = new frmGerenciarProdutos();
            abrir.Show();
            this.Hide();
        }

        //desabilitar campos
        public void desabilitarCampos()
        {
            txtCodigo.Enabled = false;
            txtDescricao.Enabled = false;
            txtUnidade.Enabled = false;

            btnCadastrar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = false;

        }
        //habilitar campos
        public void habilitarCamposNovo()
        {
            txtCodigo.Enabled = false;
            txtDescricao.Enabled = true;
            txtUnidade.Enabled = true;

            btnNovo.Enabled = false;
            btnCadastrar.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = false;
            txtDescricao.Focus();

        }

        //limpar campos
        public void limparCampos()
        {
            txtCodigo.Clear();
            txtDescricao.Clear();
            txtUnidade.Clear();

            btnNovo.Enabled = true;
            btnCadastrar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = false;

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCamposNovo();            
        }
        //cadastrando unidades
        public int cadastrarUnidades(string descricao, string unidade)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "insert into tbUnidades (descricao,unidade)values(@descricao,@unidade);";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@descricao", MySqlDbType.VarChar, 50).Value = descricao;
            comm.Parameters.Add("@unidade", MySqlDbType.VarChar, 2).Value = unidade;

            comm.Connection = Conexao.obterConexao();

            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;
        }
        //alterar unidades
        public int alterarUnidades(string descricao, string unidade, int codUnid)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "update set tbUnidades descricao=@descricao, unidade=@unidade where codUnid=@codUnid;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@descricao", MySqlDbType.VarChar, 50).Value = descricao;
            comm.Parameters.Add("@unidade", MySqlDbType.VarChar, 2).Value = unidade;
            comm.Parameters.Add("@codUnid", MySqlDbType.Int32).Value = codUnid;

            comm.Connection = Conexao.obterConexao();

            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;
        }
        //excluir unidades
        public int excluirUnidades(int codUnid)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "delete from tbUnidades where codUnid=@codUnid;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@codUnid", MySqlDbType.Int32).Value = codUnid;


            comm.Connection = Conexao.obterConexao();

            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;
        }

        //Pesquisar por nome
        public void pesquisarPorNome(string descricao)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbUnidades where descricao = @descricao";
            comm.CommandType= CommandType.Text;

            comm.Parameters.Clear();

            comm.Parameters.Add("@descricao",MySqlDbType.VarChar,50).Value = descricao;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            txtCodigo.Text = Convert.ToString(DR.GetInt32(0));
            txtDescricao.Text = Convert.ToString(DR.GetString(1));
            txtUnidade.Text = Convert.ToString(DR.GetString(2));

            Conexao.fecharConexao();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtDescricao.Text.Equals("") ||
                txtUnidade.Text.Equals(""))
            {
                MessageBox.Show("Favor inserir valores",
                    "Mensagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                txtDescricao.Focus();
                
            }
            else
            {
                int resp = cadastrarUnidades(txtDescricao.Text, txtUnidade.Text);
                if (resp == 1)
                {
                    MessageBox.Show("Cadastrado com sucesso.",
                        "Mensagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                    desabilitarCampos();
                    limparCampos();
                    btnNovo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar.",
                        "Mensagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                    limparCampos();
                }
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            int resp = alterarUnidades(txtDescricao.Text,
                txtUnidade.Text,Convert.ToInt32(txtCodigo.Text));

            if (resp == 1)
            {
                MessageBox.Show("Alterado com sucesso.",
                       "Mensagem do sistema",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information,
                   MessageBoxDefaultButton.Button1);
                desabilitarCampos();
                limparCampos();
                btnNovo.Enabled = true;
            }
            else
            {
                MessageBox.Show("Erro ao alterar.",
                       "Mensagem do sistema",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   MessageBoxDefaultButton.Button1);
                limparCampos();
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisarUnidadesMedida abrir = new frmPesquisarUnidadesMedida();
            abrir.Show();
            this.Hide();
        }
    }
}
