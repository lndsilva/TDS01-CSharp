using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GPSFrancisco
{
    public partial class frmPesquisarProdutos : Form
    {
        public frmPesquisarProdutos()
        {
            InitializeComponent();
        }

        private void ltbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string codigoBarras = ltbPesquisar.SelectedItem.ToString();

            frmGerenciarProdutos abrir = new frmGerenciarProdutos(codigoBarras);
            abrir.Show();
            this.Hide();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            if (rdbCodigo.Checked == false && rdbNome.Checked == false)
            {
                MessageBox.Show("Favor selecionar um item",
                    "Mensagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }
            else if (txtDescricao.Text.Equals(""))
            {
                MessageBox.Show("Favor inserir um valor",
                    "Mensagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                txtDescricao.Focus();
            }
            else
            {
                if (rdbCodigo.Checked)
                {
                    buscaProdutosPorCodigoBarras(txtDescricao.Text);
                }
                if (rdbNome.Checked)
                {
                    buscaProdutosDescricao(txtDescricao.Text);
                }
            }
        }

        //busca voluntários por código
        public void buscaProdutosPorCodigoBarras(string codProdBarras)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbProdutos where codBarras = @codBarras;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@codBarras", MySqlDbType.VarChar, 255).Value = codProdBarras;
            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            ltbPesquisar.Items.Clear();

            ltbPesquisar.Items.Add(DR.GetString(1));

            Conexao.fecharConexao();

        }
        public void buscaProdutosDescricao(string descricao)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbProdutos where descricao like '%" + descricao + "%';";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();

            ltbPesquisar.Items.Clear();

            while (DR.Read())
            {
                ltbPesquisar.Items.Add(DR.GetString(1));
            }

            Conexao.fecharConexao();

        }
    }
}
