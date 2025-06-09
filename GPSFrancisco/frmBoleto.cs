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
    public partial class frmBoleto : Form
    {
        public frmBoleto()
        {
            InitializeComponent();
        }

        private void btnCalculaBoleto_Click(object sender, EventArgs e)
        {
            DateTime agora = dtpEmissaoBoleto.Value;

            Boleto meuBoleto = new Boleto(agora,Convert.ToInt32(txtDiasBoleto.Text));

            DateTime dataVencimento = meuBoleto.CalcularDataVencimento();

            MessageBox.Show("Data da emissão: " + agora + " Data vencimento: " + dataVencimento);

        }

        private void btnCalculaParcelas_Click(object sender, EventArgs e)
        {
            double valorTotal = Convert.ToDouble(txtValorTotal.Text);
            int numParcelas = Convert.ToInt32(txtDiasBoleto.Text);
            DateTime dataPrimeiroVencimento = dtpEmissaoBoleto.Value;


            double valorParcela = Math.Round(valorTotal / numParcelas, 2);
            double valorDiferenca = valorTotal - valorParcela * numParcelas;

            for (int i = 0; i < numParcelas; i++)
            {

                //Calculo dos valores;
                string parcela = (i + 1).ToString().PadLeft(2, '0');
                string valor = !(i + 1 == numParcelas) ? valorParcela.ToString() : (valorParcela + valorDiferenca).ToString();
                string dataVencimento = dataPrimeiroVencimento.AddMonths(i).ToShortDateString();


                //Exemplo do resultado
                lstParcelas.Items.Add(parcela + " | " + valor + " | " + dataVencimento);
            }
        }
    }
}
