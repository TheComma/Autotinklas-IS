//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutotinklasInformacinėSistema
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class Saskaita
    {
        public string saskaitos_numeris { get; set; }
        [Required(ErrorMessage = "Būtina įvesti datą")]
        public Nullable<System.DateTime> data { get; set; }
        [Required(ErrorMessage = "Būtina įvesti sumą")]
        public Nullable<double> suma { get; set; }
        public Nullable<int> fk_uzsakymas { get; set; }
    
        public virtual Uzsakymas Uzsakymas { get; set; }
    }
}
