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
    using System.ComponentModel.DataAnnotations;

    public partial class tblOy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblOy()
        {
            this.tblBlock = new HashSet<tblBlock>();
        }
        [Key]
        public int oyId { get; set; }
        public Nullable<int> kId { get; set; }
        public Nullable<int> secenekId { get; set; }
        public Nullable<System.DateTime> oyTarih { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblBlock> tblBlock { get; set; }
        public virtual tblKullanici tblKullanici { get; set; }
        public virtual tblSecenek tblSecenek { get; set; }
    }
}
