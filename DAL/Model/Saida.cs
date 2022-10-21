using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Model
{
    public class Saida
    {
        public int Cod_Saida { get; set; }
        public int Cod_Entrada { get; set; }
        public int Cod_Produto { get; set; }
        public int QtdS { get; set; }
        public DateTime Data { get; set; }
        public string Usuario { get; set; }
        public string NumPedido { get; set; }
        public string Liberador { get; set; }
        public string Recebedor { get; set; }
        public string Autorizado { get; set; }
        public string StatusPedido { get; set; }
    }
}