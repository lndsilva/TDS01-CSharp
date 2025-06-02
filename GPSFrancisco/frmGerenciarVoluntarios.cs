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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.ConstrainedExecution;
using Org.BouncyCastle.Asn1.Cms;
using MosaicoSolutions.ViaCep;

namespace GPSFrancisco
{
    public partial class frmGerenciarVoluntarios : Form
    {
        //Criando variáveis para controle do menu
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);
        public frmGerenciarVoluntarios()
        {
            InitializeComponent();
            carregaAtribuicoes();
            desabilitarCamposNovo();
        }

        //criando método construtor com parâmetros
        public frmGerenciarVoluntarios(string nome)
        {
            InitializeComponent();
            carregaAtribuicoes();
            desabilitarCamposNovo();
            txtNome.Text = nome;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal();
            abrir.Show();
            this.Hide();
        }

        private void frmGerenciarVoluntarios_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            //verificando se os campos foram preenchidos
            if (txtNome.Text.Equals("") ||
                txtEmail.Text.Equals("") ||
                mskTelefone.Text.Equals("(  )      -") ||
                txtEndereco.Text.Equals("") ||
                txtNumero.Text.Equals("") ||
                mskCEP.Text.Equals("     -") ||
                txtBairro.Text.Equals("") ||
                txtCidade.Text.Equals("") ||
                cbbEstado.Text.Equals("") ||
                cbbAtribuicoes.Text.Equals("") ||
                ckbAtivo.Checked == false
                )
            {
                MessageBox.Show("Favor preencher os campos",
                    "Messagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                txtNome.Focus();
            }
            else
            {
                MessageBox.Show("Cadastrado com sucesso.",
                    "Messagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                limparCampos();
                desabilitarCamposNovo();
            }

        }

        public int cadastrarVoluntarios(string nome, string email, string telCel,
            string endereco, string numero, string cep, string bairro,
            string cidade, string estado,
            DateTime data, DateTime hora, int status)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "insert into tbVoluntarios(nome,email,telCel,endereco,numero,cep,bairro,cidade,estado,codAtr,data,hora,status)values(@nome,@email,@telCel,@endereco,@numero,@cep,@bairro,@cidade,@estado,@codAtr,@data,@hora,@status);";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = nome;
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = email;
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 15).Value = telCel;
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = endereco;
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 5).Value = numero;
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 9).Value = cep;
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = bairro;
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = cidade;
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 2).Value = estado;
            comm.Parameters.Add("@nome", MySqlDbType.Int32).Value = codigoAtribucao;
            comm.Parameters.Add("@nome", MySqlDbType.Date, 100).Value = data;
            comm.Parameters.Add("@nome", MySqlDbType.Time, 100).Value = hora;
            comm.Parameters.Add("@nome", MySqlDbType.Bit, 100).Value = status;

            comm.Connection = Conexao.obterConexao();

            int resp = comm.ExecuteNonQuery();

            Conexao.fecharConexao();

            return resp;
        }

        //buscando atribuições para carregar na combo
        public void carregaAtribuicoes()
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbAtribuicoes order by nome;";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();
            MySqlDataReader DR;
            DR = comm.ExecuteReader();

            while (DR.Read())
            {
                cbbAtribuicoes.Items.Add(DR.GetString(1));
            }
            Conexao.fecharConexao();
        }

        //buscando código da atribuição carregada na combo
        public int buscaCodigoAtribuicoes(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select codAtr from tbatribuicoes where nome = @nome;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = nome;

            comm.Connection = Conexao.obterConexao();
            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();
            int codAtr = DR.GetInt32(0);
            Conexao.fecharConexao();

            return codAtr;
        }

        int codigoAtribucao;
        private void cbbAtribuicoes_SelectedIndexChanged(object sender, EventArgs e)
        {
            codigoAtribucao = buscaCodigoAtribuicoes(cbbAtribuicoes.SelectedItem.ToString());
        }
        //desabilitar campos
        public void desabilitarCamposNovo()
        {
            txtCodigo.Enabled = false;
            txtNome.Enabled = false;
            txtEmail.Enabled = false;
            txtEndereco.Enabled = false;
            txtBairro.Enabled = false;
            txtCidade.Enabled = false;
            txtNumero.Enabled = false;
            txtComplemento.Enabled = false;
            mskCEP.Enabled = false;
            mskTelefone.Enabled = false;
            cbbAtribuicoes.Enabled = false;
            cbbEstado.Enabled = false;
            dtpData.Enabled = false;
            dtpHora.Enabled = false;
            btnCadastrar.Enabled = false;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnLimpar.Enabled = false;
            ckbAtivo.Enabled = false;

        }

        //habilitar campos
        public void habilitarCamposNovo()
        {
            txtCodigo.Enabled = false;
            txtNome.Enabled = true;
            txtEmail.Enabled = true;
            txtEndereco.Enabled = true;
            txtBairro.Enabled = true;
            txtCidade.Enabled = true;
            txtNumero.Enabled = true;
            txtComplemento.Enabled = true;
            mskCEP.Enabled = true;
            mskTelefone.Enabled = true;
            cbbAtribuicoes.Enabled = true;
            cbbEstado.Enabled = true;
            ckbAtivo.Enabled = true;
            dtpData.Enabled = true;
            dtpHora.Enabled = true;
            btnCadastrar.Enabled = true;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnLimpar.Enabled = true;
            txtNome.Focus();

        }

        //limpar campos
        public void limparCampos()
        {
            txtCodigo.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            txtEndereco.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtNumero.Clear();
            txtComplemento.Clear();
            mskCEP.Clear();
            mskTelefone.Clear();
            cbbAtribuicoes.Text = "";
            cbbEstado.Text = "";
            ckbAtivo.Checked = false;
            dtpData.Value = DateTime.Now;
            dtpHora.Value = DateTime.Now;
            btnCadastrar.Enabled = false;
            btnExcluir.Enabled = false;
            btnAlterar.Enabled = false;
            btnLimpar.Enabled = true;
            txtNome.Focus();


        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCamposNovo();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
            desabilitarCamposNovo();
        }

        //método para buscar o CEP
        public void buscaCEP(string cep)
        {
            var viaCEPService = ViaCepService.Default();
            try
            {
                var endereco = viaCEPService.ObterEndereco(cep);

                txtEndereco.Text = endereco.Logradouro.ToString();
                txtCidade.Text = endereco.Localidade.ToString();
                txtBairro.Text = endereco.Bairro.ToString();
                cbbEstado.Text = endereco.UF.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("CEP não encontrado.",
                   "Messagem do sistema",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   MessageBoxDefaultButton.Button1);
                mskCEP.Focus();
                mskCEP.Text = "";

            }
        }

        private void mskCEP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buscaCEP(mskCEP.Text);
                txtNumero.Focus();
            }          
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisarVolutarios abrir = new frmPesquisarVolutarios();
            abrir.Show();
            this.Hide();
        }
    }
}
