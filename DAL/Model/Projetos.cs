using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Model
{
    public class Projetos
    {
        public int ID { get; set; }
        public string OS { get; set; }
        public string Localidade { get; set; }
        public string Site { get; set; }
        public string UF { get; set; }
    }
}