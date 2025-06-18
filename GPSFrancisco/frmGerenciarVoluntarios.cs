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
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using Image = System.Drawing.Image;
using System.IO;

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
            carregaVolutariosPorNome(txtNome.Text);
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
                ckbAtivo.Checked == false ||
                pcbFoto.Image == null
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
                int status = 0;
                if (ckbAtivo.Checked)
                {
                    status = 1;
                }
                else
                {
                    status = 0;
                }
                if (cadastrarVoluntarios(
                    txtNome.Text, txtEmail.Text, mskTelefone.Text,
                    txtEndereco.Text, txtNumero.Text, mskCEP.Text,
                    txtBairro.Text, txtCidade.Text, cbbEstado.Text,
                    codigoAtribucao, dtpData.Value,
                    dtpHora.Value, status,salvarFotos().LongLength) == 1)
                {

                }

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
            string cidade, string estado, int codAtr,
            DateTime data, DateTime hora, int status, long foto)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "insert into tbVoluntarios(nome,email,telCel,endereco,numero,cep,bairro,cidade,estado,codAtr,data,hora,status,foto)values(@nome,@email,@telCel,@endereco,@numero,@cep,@bairro,@cidade,@estado,@codAtr,@data,@hora,@status,@foto);";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = nome;
            comm.Parameters.Add("@email", MySqlDbType.VarChar, 100).Value = email;
            comm.Parameters.Add("@telCel", MySqlDbType.VarChar, 15).Value = telCel;
            comm.Parameters.Add("@endereco", MySqlDbType.VarChar, 100).Value = endereco;
            comm.Parameters.Add("@numero", MySqlDbType.VarChar, 5).Value = numero;
            comm.Parameters.Add("@cep", MySqlDbType.VarChar, 9).Value = cep;
            comm.Parameters.Add("@bairro", MySqlDbType.VarChar, 100).Value = bairro;
            comm.Parameters.Add("@cidade", MySqlDbType.VarChar, 100).Value = cidade;
            comm.Parameters.Add("@estado", MySqlDbType.VarChar, 2).Value = estado;
            comm.Parameters.Add("@codAtr", MySqlDbType.Int32).Value = codigoAtribucao;
            comm.Parameters.Add("@data", MySqlDbType.DateTime, 100).Value = data;
            comm.Parameters.Add("@hora", MySqlDbType.DateTime, 100).Value = hora;
            comm.Parameters.Add("@status", MySqlDbType.Int32).Value = status;
            comm.Parameters.Add("@foto", MySqlDbType.LongBlob).Value = foto;

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
            btnInserir.Enabled = false;

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
            btnInserir.Enabled = true;
            txtNome.Focus();
        }

        //habilitar campos Alterar
        public void habilitarCamposAlterar()
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
            btnNovo.Enabled = false;
            btnCadastrar.Enabled = false;
            btnExcluir.Enabled = true;
            btnAlterar.Enabled = true;
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
            pcbFoto.Image = null;
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCamposNovo();
            btnNovo.Enabled = false;
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

        //busca voluntarios alterar/deletar

        public void carregaVolutariosPorNome(string nome)
        {
            bool status = false;


            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbVoluntarios where nome = @nome;";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 100).Value = nome;


            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            if (DR.GetInt32(13) == 1)
            {
                status = true;
            }
            if (DR.GetInt32(13) == 0)
            {
                status = false;
            }

            txtCodigo.Text = Convert.ToString(DR.GetInt32(0));
            txtNome.Text = DR.GetString(1);
            txtEmail.Text = DR.GetString(2);
            mskTelefone.Text = DR.GetString(3);
            txtEndereco.Text = DR.GetString(4);
            txtNumero.Text = DR.GetString(5);
            mskCEP.Text = DR.GetString(6);
            txtBairro.Text = DR.GetString(7);
            txtCidade.Text = DR.GetString(8);
            cbbEstado.Text = DR.GetString(9);
            codigoAtribucao = DR.GetInt32(10);
            dtpData.Value = DR.GetDateTime(11);
            dtpHora.Value = DR.GetDateTime(12);
            ckbAtivo.Checked = status;
          // pcbFoto.Image = DR.GetBytes(14);

            Conexao.fecharConexao();

            habilitarCamposAlterar();

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
        string enderecoFoto;

        private void btnInserir_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "JPG Files(*.jpg)|*.jpg|" +
                "PNG Files(*.png)|*.png|AllFiles(*.*) | *.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string foto = dialog.FileName.ToString();
                enderecoFoto = foto;
                pcbFoto.ImageLocation = foto;
                txtNome.Focus();
            }
        }
        public byte[] salvarFotos()
        {
            byte[] imagem_byte = null;

            FileStream fs = new FileStream(enderecoFoto, 
                FileMode.Open, FileAccess.Read);

            BinaryReader br = new BinaryReader(fs);

            imagem_byte = br.ReadBytes((int)fs.Length);

            return imagem_byte;
        }

    }
}
