//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proje.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class emanet
    {
        public int emanet_id { get; set; }
        public System.DateTime emanetTarihi { get; set; }
        public System.DateTime teslimTarihi { get; set; }
        public double ceza { get; set; }
        public int uye_id { get; set; }
        public int kitap_id { get; set; }
    
        public virtual kitaplar kitaplar { get; set; }
        public virtual uyeler uyeler { get; set; }
    }
}
