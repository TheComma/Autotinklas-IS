using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutotinklasInformacinėSistema.Models
{
    public class AutomobilisModel
    {
        public string valstybinis_numeris { get; set; }
        public string kebulo_tipas { get; set; }
        public string kebulo_numeris { get; set; }
        public string metai { get; set; }
        public int fk_modelis { get; set; }
        public ModelisModel modelis { get; set; }
    }
}