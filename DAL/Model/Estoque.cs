using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Model
{
    public class Estoque
    {
        public int PK_GERAL { get; set; }

        public int FK_PRODUTO { get; set; }

        public int QTDE { get; set; }

        public int QTDS { get; set; }

        public string Origem { get; set; }

        public string Destino { get; set; }

        public string Usuario { get; set; }

        public string Status { get; set; }

        public string Protocolo { get; set; }

        public string Obs { get; set; }

        public DateTime Data { get; set; }
    }
}