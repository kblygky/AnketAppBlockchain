//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HackatonAnketApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblAnket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblAnket()
        {
            this.tblSecenek = new HashSet<tblSecenek>();
        }
    
        public int anketId { get; set; }
        public Nullable<int> kategoriId { get; set; }
        public string anketAd { get; set; }
        public string aciklama { get; set; }
    
        public virtual tblKategori tblKategori { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblSecenek> tblSecenek { get; set; }
    }
}
