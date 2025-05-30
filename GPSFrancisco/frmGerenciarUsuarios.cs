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
using System.Diagnostics.Eventing.Reader;
using MySql.Data.MySqlClient;

namespace GPSFrancisco
{
    public partial class frmGerenciarUsuarios : Form
    {
        //Criando variáveis para controle do menu
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);

        public frmGerenciarUsuarios()
        {
            InitializeComponent();
            //executando o método desabilitar campos
            desabilitarCampos();
        }

        public frmGerenciarUsuarios(string nome)
        {
            InitializeComponent();
            //executando o método desabilitar campos
            desabilitarCampos();
            txtUsuario.Text = nome;
            buscaUsuarioExistente(txtUsuario.Text);

        }

        //desabilitar campos
        public void desabilitarCampos()
        {
            txtUsuario.Enabled = false;
            txtSenha.Enabled = false;
            txtValidaSenha.Enabled = false;
            btnCadastrar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = false;
        }

        //habilitar campos
        public void habilitarCampos()
        {
            txtUsuario.Enabled = true;
            txtSenha.Enabled = true;
            txtValidaSenha.Enabled = true;
            btnCadastrar.Enabled = true;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = true;
            btnNovo.Enabled = false;
            txtUsuario.Focus();
        }

        //desabilitar campos cadastrar
        public void desabilitarCamposCadastrar()
        {
            txtUsuario.Enabled = false;
            txtSenha.Enabled = false;
            txtValidaSenha.Enabled = false;
            btnCadastrar.Enabled = false;
            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnLimpar.Enabled = false;
            btnNovo.Enabled = true;
            txtUsuario.Clear();
            txtSenha.Clear();
            txtValidaSenha.Clear();
        }

        //habilitar campos usuarios existentes
        public void habilitarCamposUsuarioExistente()
        {
            txtUsuario.Enabled = true;
            txtSenha.Enabled = true;
            txtValidaSenha.Enabled = true;
            btnCadastrar.Enabled = false;
            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnLimpar.Enabled = false;
            btnNovo.Enabled = false;
            txtUsuario.Focus();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal();
            abrir.Show();
            this.Hide();
        }

        private void frmGerenciarUsuarios_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            //executando o método limpar campos
            limparCampos();
        }
        //criando o método limpar campos
        public void limparCampos()
        {
            txtCodigo.Clear();
            txtUsuario.Clear();
            txtSenha.Clear();
            txtValidaSenha.Clear();
            txtUsuario.Focus();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text.Equals("")
                || txtSenha.Text.Equals("")
                || txtValidaSenha.Text.Equals(""))
            {
                MessageBox.Show("Favor inserir valores.",
                    "Mensagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1
                    );
                limparCampos();
            }
            else
            {
                if (txtSenha.Text.Length < 12 || txtValidaSenha.Text.Length < 12)
                {
                    MessageBox.Show("A senha tem que ser igual a 12 caracteres",
                       "Mensagem do sistema",
                      MessageBoxButtons.OK,
                      MessageBoxIcon.Error,
                      MessageBoxDefaultButton.Button1
                      );
                }
                else
                {
                    if (txtSenha.Text.Equals(txtValidaSenha.Text))
                    {
                        if (cadatrarUsuario(txtUsuario.Text, txtSenha.Text) == 1)
                        {
                            MessageBox.Show("Cadastrado com sucesso.",
                             "Mensagem do sistema",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information,
                            MessageBoxDefaultButton.Button1
                            );
                            desabilitarCamposCadastrar();
                            buscarUsuariosCadastrados();
                        }
                        else
                        {
                            MessageBox.Show("Erro ao cadastrar.",
                            "Mensagem do sistema",
                           MessageBoxButtons.OK,
                           MessageBoxIcon.Error,
                           MessageBoxDefaultButton.Button1
                           );
                        }
                    }
                    else
                    {
                        MessageBox.Show("A senha não é igual.",
                             "Mensagem do sistema",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error,
                            MessageBoxDefaultButton.Button1
                            );
                        txtSenha.Clear();
                        txtValidaSenha.Clear();
                        txtSenha.Focus();
                    }
                }



            }
        }

        private void txtValidaSenha_TextChanged(object sender, EventArgs e)
        {
            if (txtValidaSenha.Text.Equals(txtSenha.Text))
            {
                btnChecked.Visible = true;
            }
            else
            {
                if (txtValidaSenha.Text.Length == 12)
                {
                    btnCheckedFalse.Visible = true;
                }
            }
        }

        //criar os métodos do crud da janela usuários

        //método cadastrar usuário
        public int cadatrarUsuario(string usuario, string senha)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "insert into tbUsuarios(nome,senha)values(@nome,@senha);";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = usuario;
            comm.Parameters.Add("@senha", MySqlDbType.VarChar, 12).Value = senha;

            comm.Connection = Conexao.obterConexao();

            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;
        }

        //buscar usuarios cadastrados
        public void buscarUsuariosCadastrados()
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select nome from tbusuarios order by nome asc;";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();

            cbbUsuariosCadastrados.Items.Clear();

            while (DR.Read())
            {
                cbbUsuariosCadastrados.Items.Add(DR.GetString(0));
            }

            Conexao.fecharConexao();
        }

        //método alterar usuário
        public int alterarUsuario(string usuario, string senha, int codUsu)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "update tbUsuarios set nome = @nome, senha = @senha where codUsu = " + codUsu;
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = usuario;
            comm.Parameters.Add("@senha", MySqlDbType.VarChar, 12).Value = senha;

            comm.Connection = Conexao.obterConexao();

            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;

        }

        //excluir usuário
        public int excluirUsuario(int codUsu)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "delete from tbUsuarios where codusu = @codusu;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@codusu", MySqlDbType.Int32).Value = codUsu;

            comm.Connection = Conexao.obterConexao();

            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            desabilitarCampos();
            limparCampos();

            return resp;
        }


        //busca usuário por código
        public void buscaUsuarioCodigo()
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbusuarios where codusu = 1;";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();

            DR.Read();

            txtCodigo.Text = DR.GetString(0);
            txtUsuario.Text = DR.GetString(1);
            txtSenha.Text = DR.GetString(2);

            Conexao.fecharConexao();

        }
        //Busca usuário pesquisado e existente
        public void buscaUsuarioExistente(string usuario)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbUsuarios where nome = @nome;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = usuario;

            comm.Connection = Conexao.obterConexao();
            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            txtCodigo.Text = Convert.ToString(DR.GetInt32(0));
            txtUsuario.Text = DR.GetString(1);
            txtSenha.Text = DR.GetString(2);

            Conexao.fecharConexao();

            habilitarCamposUsuarioExistente();
        }



        private void cbbUsuariosCadastrados_Click(object sender, EventArgs e)
        {
            buscarUsuariosCadastrados();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (alterarUsuario(txtUsuario.Text, txtSenha.Text, Convert.ToInt32(txtCodigo.Text)) == 1)
            {
                MessageBox.Show("Usuário alterado com sucesso.",
                    "Mensagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1
                    );
                desabilitarCampos();
                limparCampos();
            }
            else
            {
                MessageBox.Show("Erro ao alterar.",
                    "Mensagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1
                    );
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisarUsuario abrir = new frmPesquisarUsuario();
            abrir.Show();
            this.Hide();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resp = MessageBox.Show("Deseja excluir?",
                "Mensagem do sistema",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (resp == DialogResult.Yes)
            {
                if (excluirUsuario(Convert.ToInt32(txtCodigo.Text)) == 1)
                {
                    MessageBox.Show("Usuário excluído com sucesso.",
                "Mensagem do sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information,
                MessageBoxDefaultButton.Button1);
                }
                else
                {
                    MessageBox.Show("Erro ao excluir.",
                "Mensagem do sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                }
            }
            else
            {

            }
        }
    }
}
