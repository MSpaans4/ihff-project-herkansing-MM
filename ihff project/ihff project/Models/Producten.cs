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
    
    public partial class Producten
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producten()
        {
            this.BesteldeItems = new HashSet<BesteldeItems>();
        }
    
        public int Product_ID { get; set; }
        public Nullable<double> Prijs { get; set; }
        public Nullable<bool> Highlight { get; set; }
        public string Highlight_text_NL { get; set; }
        public string Highlight_text_EN { get; set; }
        public string Image_Path { get; set; }
        public Nullable<int> Locatie_ID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BesteldeItems> BesteldeItems { get; set; }
        public virtual Locaties Locaties { get; set; }
        public virtual Restaurants Restaurants { get; set; }
        public virtual Voorstellingen Voorstellingen { get; set; }
    }
}
