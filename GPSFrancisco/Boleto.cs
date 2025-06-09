using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPSFrancisco
{
    public class Boleto
    {
        public DateTime DataEmissao { get; set; }
        public int PrazoEmDias { get; set; }

        public Boleto(DateTime dataEmissao, int prazoEmDias)
        {
            DataEmissao = dataEmissao;
            PrazoEmDias = prazoEmDias;
        }

        public DateTime CalcularDataVencimento()
        {
            return DataEmissao.AddDays(PrazoEmDias);
        }


    }
}
