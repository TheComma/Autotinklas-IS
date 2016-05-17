using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutotinklasInformacinėSistema.Models
{
    public class UzsakymasModel
    {
        public int uzsakymo_nr { get; set; }
        public DateTime data { get; set; }
        public string kliento_vardas { get; set; }
        public string kliento_pavarde { get; set; }
        public string kliento_telefonas { get; set; }
        public int fk_meistras { get; set; }
        public string fk_automobilis { get; set; }
        public string fk_pakaitinis_automobilis { get; set; }
        public AutomobilisModel automobilis { get; set; }
        public SelectList pakaitinislist;
        public SelectList meistraslist;
    }
}