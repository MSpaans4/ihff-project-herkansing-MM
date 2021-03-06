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
    
    public partial class Locaties
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Locaties()
        {
            this.Cultuur = new HashSet<Cultuur>();
            this.Producten = new HashSet<Producten>();
        }
    
        public int Locatie_ID { get; set; }
        public string Locatie_Naam { get; set; }
        public string Plaats { get; set; }
        public string Straatnaam { get; set; }
        public Nullable<int> Huisnummer { get; set; }
        public string Toevoeging { get; set; }
        public string Postcode { get; set; }
        public string Breedte { get; set; }
        public string Lengte { get; set; }
        public string Image_path { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cultuur> Cultuur { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Producten> Producten { get; set; }
    }
}
