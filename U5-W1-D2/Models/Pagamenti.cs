using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace U5_W1_D2.Models
{
    public class Pagamenti
    {
        public int PagamentoID { get; set; }
        public int DipendenteID { get; set; }
        public DateTime PeriodoPagamento { get; set; }
        public decimal Ammontare { get; set; }
        public string TipoPagamento { get; set; }
    }
}