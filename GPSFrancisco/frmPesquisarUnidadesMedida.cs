using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace GPSFrancisco
{
    public partial class frmPesquisarUnidadesMedida : Form
    {
        public frmPesquisarUnidadesMedida()
        {
            InitializeComponent();
        }

        private void ltbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string descricao = ltbPesquisar.SelectedItem.ToString();
            frmUnidades abrir = new frmUnidades(descricao);
            abrir.Show();
            this.Hide();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {          
            if (rdbCodigo.Checked)
            {
                buscaPorCodigo(Convert.ToInt32(txtDescricao.Text));
                txtDescricao.Focus();
            }
            if (rdbNome.Checked)
            {
                buscaPorDescricao(txtDescricao.Text);
                txtDescricao.Focus();
            }
        }

        //busca por codigo
        public void buscaPorCodigo(int codUnid)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = $"select * from tbUnidades where codUnid = {codUnid};";
            comm.CommandType = CommandType.Text;
            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;

            DR = comm.ExecuteReader();
            DR.Read();

            ltbPesquisar.Items.Clear();

            ltbPesquisar.Items.Add(DR.GetString(1));

            Conexao.fecharConexao();
        }

        //busca por codigo
        public void buscaPorDescricao(string descricao)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = $"select * from tbunidades where descricao like '%{descricao}%';";
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
