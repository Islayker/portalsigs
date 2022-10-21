using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Model
{
    public class Pedido
    {
        public int ID_Pedido { get; set; }
        public int NumPedido { get; set; }
        public string UF { get; set; }
    }
}