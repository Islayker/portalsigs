using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DAL.Model
{
    public class Time
    {
        public int PK_RECEBEDOR { get; set; }

        public string Recebedor { get; set; }

        public string Cargo { get; set; }

        public string UF { get; set; }
    }
}