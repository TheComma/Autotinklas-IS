//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Autotinklo_Informacine_sistema
{
    using System;
    using System.Collections.Generic;
    
    public partial class Gedimas
    {
        public int id { get; set; }
        public string pavadinimas { get; set; }
        public Nullable<int> fk_uzsakymas { get; set; }
    
        public virtual Uzsakymas Uzsakymas { get; set; }
    }
}
