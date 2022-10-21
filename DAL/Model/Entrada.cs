using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Model
{
    public class Entrada
    {
        public int Cod_Entrada { get; set; }
        public int ID_Demanda { get; set; }
        public int ID_PRODUTO { get; set; }
        public string NF { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public int QtdE { get; set; }
        public int QtdS { get; set; }
        public DateTime Data { get; set; }
        public string Usuario { get; set; }
        public string Status { get; set; }
    }
}