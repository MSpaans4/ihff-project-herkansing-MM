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
    
    public partial class Cultuur
    {
        public int Cultuur_ID { get; set; }
        public string Soort { get; set; }
        public Nullable<int> Locatie { get; set; }
        public string Beschrijving_NL { get; set; }
        public string Beschrijving_EN { get; set; }
    
        public virtual Locaties Locaties { get; set; }
    }
}
