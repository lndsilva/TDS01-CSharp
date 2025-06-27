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




        private void btnAlterar_Click(object sender, EventArgs e)
        {

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
        public int cadastrarProdutos(int codBarra, string descricao,
            int quantidade, string lote,
            int codigoUnidade, DateTime dataEntrada,
            DateTime horaEntrada, DateTime validade)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "insert into tbProdutos(codBarras,descricao,quantidade,lote,dataEntr,horaEntr,validade,codUnid)values(@codBarras,@descricao,@quantidade,@lote,@dataEntr,@horaEntr,@validade,@codUnid);";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();

            comm.Parameters.Add("@codBarras",MySqlDbType.Int32).Value = codBarra;
            comm.Parameters.Add("@descricao",MySqlDbType.VarChar,100).Value = descricao;
            comm.Parameters.Add("@quantidade",MySqlDbType.Int32).Value = quantidade;
            comm.Parameters.Add("@lote",MySqlDbType.VarChar,10).Value = lote;
            comm.Parameters.Add("@dataEntr",MySqlDbType.DateTime).Value = dataEntrada;
            comm.Parameters.Add("@horaEntr",MySqlDbType.DateTime).Value = horaEntrada;
            comm.Parameters.Add("@validade",MySqlDbType.DateTime).Value = validade;
            comm.Parameters.Add("@codUnid",MySqlDbType.Int32).Value = codigoUnidade;
            
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

    }
}
