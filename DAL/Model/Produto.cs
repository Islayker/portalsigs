using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Model
{
    public class Produto
    {
        public int Pedido { get; set; }
        public int Cod_Produto { get; set; }
        
        public string Descricao { get; set; }
        
        public string Status { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Tipo { get; set; }
        public string Usuario { get; set; }
    }
}