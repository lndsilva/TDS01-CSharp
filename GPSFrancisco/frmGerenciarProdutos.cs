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
using GenCode128;
using QRCoder;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GPSFrancisco
{
    public partial class frmGerenciarProdutos : Form
    {
        //Criando variáveis para controle do menu
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);

        public frmGerenciarProdutos()
        {
            InitializeComponent();
            buscarUnidadesMedida();
            desabilitarCampos();
        }
        public frmGerenciarProdutos(string descricao)
        {
            InitializeComponent();
            buscarUnidadesMedida();
            desabilitarCampos();
            txtDescricao.Text = descricao;
            carregaProdutosPorDescricao(txtDescricao.Text);
        }

        private void btnUnidade_Click(object sender, EventArgs e)
        {
            frmUnidades abrir = new frmUnidades();
            abrir.Show();
            this.Hide();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuPrincipal abrir = new frmMenuPrincipal();
            abrir.Show();
            this.Hide();
        }

        private void frmGerenciarProdutos_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
        }

        //buscar unidades de medida
        public void buscarUnidadesMedida()
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbunidades order by unidade;";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();

            while (DR.Read())
            {
                cbbUnidade.Items.Add(DR.GetString(2));
            }
            Conexao.fecharConexao();

        }

        private void txtCodigoBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Image imgCodigoBarras =
                    Code128Rendering.
                    MakeBarcodeImage
                    (txtCodigoBarras.Text, 2, true);
                pctCodigoBarras.Image = imgCodigoBarras;
            }
        }
        int codigoUnidade;
        //cadastrar produtos
        public int cadastrarProdutos(string codBarra, string descricao,
            int quantidade, string lote,
            int codigoUnidade, DateTime dataEntrada,
            DateTime horaEntrada, DateTime validade, byte[] fotoProd)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "insert into tbProdutos(codBarras,descricao,quantidade,lote,dataEntr,horaEntr,validade,codUnid,fotoProd)values(@codBarras,@descricao,@quantidade,@lote,@dataEntr,@horaEntr,@validade,@codUnid,@fotoProd);";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();

            comm.Parameters.Add("@codBarras", MySqlDbType.VarChar, 255).Value = codBarra;
            comm.Parameters.Add("@descricao", MySqlDbType.VarChar, 100).Value = descricao;
            comm.Parameters.Add("@quantidade", MySqlDbType.Int32).Value = quantidade;
            comm.Parameters.Add("@lote", MySqlDbType.VarChar, 10).Value = lote;
            comm.Parameters.Add("@dataEntr", MySqlDbType.DateTime).Value = dataEntrada;
            comm.Parameters.Add("@horaEntr", MySqlDbType.DateTime).Value = horaEntrada;
            comm.Parameters.Add("@validade", MySqlDbType.DateTime).Value = validade;
            comm.Parameters.Add("@codUnid", MySqlDbType.Int32).Value = codigoUnidade;
            comm.Parameters.Add("@fotoProd", MySqlDbType.LongBlob).Value = fotoProd;


            comm.Connection = Conexao.obterConexao();

            int resp = comm.ExecuteNonQuery();

            return resp;
        }
        //alterar produtos
        public int alterarProdutos(int codBarra, string descricao,
            int quantidade, string lote,
            int codigoUnidade, DateTime dataEntrada,
            DateTime horaEntrada, DateTime validade)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "update tbProdutos set codBarras = @codBarras,descricao=@descricao,quantidade=@quantidade,lote=@lote,dataEntr=@dataEntr,horaEntr=@horaEntr,validade=@validade,codUnid=@codUnid where codBarras = @codBarras;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();

            comm.Parameters.Add("@codBarras", MySqlDbType.Int32).Value = codBarra;
            comm.Parameters.Add("@descricao", MySqlDbType.VarChar, 100).Value = descricao;
            comm.Parameters.Add("@quantidade", MySqlDbType.Int32).Value = quantidade;
            comm.Parameters.Add("@lote", MySqlDbType.VarChar, 10).Value = lote;
            comm.Parameters.Add("@dataEntr", MySqlDbType.DateTime).Value = dataEntrada;
            comm.Parameters.Add("@horaEntr", MySqlDbType.DateTime).Value = horaEntrada;
            comm.Parameters.Add("@validade", MySqlDbType.DateTime).Value = validade;
            comm.Parameters.Add("@codUnid", MySqlDbType.Int32).Value = codigoUnidade;

            comm.Connection = Conexao.obterConexao();

            int resp = comm.ExecuteNonQuery();

            return resp;
        }
        //excluir produtos
        public int excluirProdutos(int codBarra)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "delete from tbProdutos where codBarra = @codBarra;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();

            comm.Parameters.Add("@codBarras", MySqlDbType.Int32).Value = codBarra;

            comm.Connection = Conexao.obterConexao();

            int resp = comm.ExecuteNonQuery();

            return resp;
        }
        //carrega endereço da foto para reservar memória
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
                pcbFotoProduto.ImageLocation = foto;

            }
        }
        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (cadastrarProdutos(txtCodigoBarras.Text, txtDescricao.Text, Convert.ToInt32(txtQuantidade.Text), txtLote.Text, codigoUnidade, dtpDataEntrada.Value, dtpHoraEntrada.Value, dtpValidade.Value, salvarFotos()) == 1)
            {
                MessageBox.Show("Cadastrado com sucesso.",
                    "Messagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information,
                    MessageBoxDefaultButton.Button1);
                limparCamposAlterar();
                desabilitarCampos();

            }
            else
            {
                MessageBox.Show("Erro ao cadastrar.",
                    "Messagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
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

        private void cbbUnidade_SelectedIndexChanged(object sender, EventArgs e)
        {
            codigoUnidade = buscaCodigoUnidades(cbbUnidade.SelectedItem.ToString());
        }

        //buscando código da atribuição carregada na combo
        public int buscaCodigoUnidades(string unidade)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select codUnid from tbunidades where unidade = @unidade;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@unidade", MySqlDbType.VarChar, 100).Value = unidade;

            comm.Connection = Conexao.obterConexao();
            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();
            int codUnidade = DR.GetInt32(0);
            Conexao.fecharConexao();

            return codUnidade;
        }

        public void limparCamposAlterar()
        {
            txtCodigoBarras.Clear();
            txtDescricao.Clear();
            txtLote.Clear();
            txtQuantidade.Clear();

            pctCodigoBarras.Image = null;
            pcbFotoProduto.Image = null;

            cbbUnidade.Text = "";

            dtpDataEntrada.Value = DateTime.Now;
            dtpValidade.Value = DateTime.Now;
            dtpHoraEntrada.Value = DateTime.Now;

        }
        public void desabilitarCampos()
        {
            txtCodigoBarras.Enabled = false;
            txtDescricao.Enabled = false;
            txtLote.Enabled = false;
            txtQuantidade.Enabled = false;

            pctCodigoBarras.Image = null;
            pcbFotoProduto.Image = null;

            cbbUnidade.Enabled = false;

            dtpDataEntrada.Enabled = false;
            dtpValidade.Enabled = false;
            dtpHoraEntrada.Enabled = false;

            btnNovo.Enabled = true;
            btnInserir.Enabled = false;
            btnExcluir.Enabled = false;
            btnCadastrar.Enabled = false;
            btnAlterar.Enabled = false;
            btnLimpar.Enabled = false;

        }
        public void habilitarCampos()
        {
            txtCodigoBarras.Enabled = true;
            txtDescricao.Enabled = true;
            txtLote.Enabled = true;
            txtQuantidade.Enabled = true;

            pctCodigoBarras.Image = null;
            pcbFotoProduto.Image = null;

            cbbUnidade.Enabled = true;

            dtpDataEntrada.Enabled = true;
            dtpValidade.Enabled = true;
            dtpHoraEntrada.Enabled = true;

            btnAlterar.Enabled = false;
            btnExcluir.Enabled = false;
            btnNovo.Enabled = false;
            btnInserir.Enabled = true;

            btnCadastrar.Enabled = true;

            txtCodigoBarras.Focus();

        }
        public void habilitarCamposAlterar()
        {
            txtCodigoBarras.Enabled = true;
            txtDescricao.Enabled = true;
            txtLote.Enabled = true;
            txtQuantidade.Enabled = true;

            //pctCodigoBarras.Image = null;
            //pcbFotoProduto.Image = null;

            cbbUnidade.Enabled = true;

            dtpDataEntrada.Enabled = true;
            dtpValidade.Enabled = true;
            dtpHoraEntrada.Enabled = true;

            btnAlterar.Enabled = true;
            btnExcluir.Enabled = true;
            btnNovo.Enabled = false;
            btnInserir.Enabled = true;

            btnCadastrar.Enabled = false;

            txtCodigoBarras.Focus();

            btnInserir.Text = "Alterar";

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisarProdutos abrir = new frmPesquisarProdutos();
            abrir.Show();
            this.Hide();
        }
        public void carregaProdutosPorDescricao(string descricao)
        {

            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select codBarras, prod.descricao, quantidade, lote, dataEntr, horaEntr, validade, fotoProd, unidade from tbProdutos as prod inner join tbUnidades as uni on prod.codUnid = uni.codUnid where prod.descricao = @prod.descricao;";
            comm.CommandType = CommandType.Text;
            comm.Parameters.Clear();
            comm.Parameters.Add("@prod.descricao", MySqlDbType.VarChar, 100).Value = descricao;


            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            txtCodigoBarras.Text = DR.GetString(0);
            txtDescricao.Text = DR.GetString(1);
            txtQuantidade.Text = Convert.ToString(DR.GetInt32(2));
            txtLote.Text = DR.GetString(3);
            dtpDataEntrada.Value = DR.GetDateTime(4);
            dtpHoraEntrada.Value = DR.GetDateTime(5);
            dtpValidade.Value = DR.GetDateTime(6);

            byte[] imageData = (byte[])DR.GetValue(7);
            MemoryStream ms = new MemoryStream(imageData);
            pcbFotoProduto.Image = Image.FromStream(ms);

            cbbUnidade.Text = DR.GetString(8);

            Conexao.fecharConexao();

            habilitarCamposAlterar();

        }
        public void limparCamposGeral()
        {
            txtCodigoBarras.Clear();
            txtDescricao.Clear();
            txtLote.Clear();
            txtQuantidade.Clear();

            pctCodigoBarras.Image = null;
            pcbFotoProduto.Image = null;

            cbbUnidade.Text = "";

            dtpDataEntrada.Value = DateTime.Now;
            dtpValidade.Value = DateTime.Now;
            dtpHoraEntrada.Value = DateTime.Now;

        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCamposGeral();
            desabilitarCampos();
        }
    }
}
