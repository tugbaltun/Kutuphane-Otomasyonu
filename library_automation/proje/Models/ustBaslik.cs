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
    
    public partial class ustBaslik
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ustBaslik()
        {
            this.kitaplar = new HashSet<kitaplar>();
        }
    
        public int ust_id { get; set; }
        public string ustAd { get; set; }
        public int alt_id { get; set; }
    
        public virtual altBaslik altBaslik { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kitaplar> kitaplar { get; set; }
    }
}