//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ihff_project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Klanten
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Klanten()
        {
            this.Bestellingen = new HashSet<Bestellingen>();
        }
    
        public int Klant_ID { get; set; }
        public string Naam { get; set; }
        public string Emailadres { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bestellingen> Bestellingen { get; set; }
    }
}
