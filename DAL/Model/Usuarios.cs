using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Model
{
    public class Usuarios
    {
        public int ID { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string Controle { get; set; }
        public string Estado { get; set; }
    }
}