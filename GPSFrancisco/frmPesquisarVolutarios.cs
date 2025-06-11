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
    public partial class frmPesquisarVolutarios : Form
    {
        public frmPesquisarVolutarios()
        {
            InitializeComponent();
        }

        private void ltbPesquisar_SelectedIndexChanged(object sender, EventArgs e)
        {
            string nome = ltbPesquisar.SelectedItem.ToString();

            frmGerenciarVoluntarios abrir = new frmGerenciarVoluntarios(nome);
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
                    buscaVoluntariosPorCodigo( Convert.ToInt32(txtDescricao.Text));
                }
                if (rdbNome.Checked)
                {
                    buscaVoluntariosPorNome(txtDescricao.Text);
                }
            }

        }
        //busca voluntários por código
        public void buscaVoluntariosPorCodigo(int codVol)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbvoluntarios where codVol = @codVol;";
            comm.CommandType = CommandType.Text;

            comm.Parameters.Clear();
            comm.Parameters.Add("@codVol", MySqlDbType.Int32).Value = codVol;
            comm.Connection = Conexao.obterConexao();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();
            DR.Read();

            ltbPesquisar.Items.Clear();

            ltbPesquisar.Items.Add(DR.GetString(1));

            Conexao.fecharConexao();

        }

        //busca voluntários por nome
        public void buscaVoluntariosPorNome(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbvoluntarios where nome like '%" + nome + "%';";
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

        private void rdbCodigo_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbCodigo.Checked)
            {
                habilitarCampos();
            }
        }
        //habilitar campos
        public void habilitarCampos()
        {
            txtDescricao.Enabled = true;
            ltbPesquisar.Enabled = true;
            btnLimpar.Enabled = true;
            btnPesquisar.Enabled = true;
            txtDescricao.Focus();
        }

        private void rdbNome_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNome.Checked)
            {
                habilitarCampos();
            }
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }
        //limpar campos
        public void limparCampos()
        {
            txtDescricao.Clear();
            ltbPesquisar.Items.Clear();
            rdbCodigo.Checked = false;
            rdbNome.Checked = false;
            txtDescricao.Focus();

        }
    }
}
