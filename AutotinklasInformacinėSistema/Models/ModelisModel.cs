using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutotinklasInformacinėSistema.Models
{
    public class ModelisModel
    {
        public int id { get; set; }
        public string pavadinimas { get; set; }
        public int fk_marke { get; set; }
        public MarkeModel marke { get; set; }

    }
}