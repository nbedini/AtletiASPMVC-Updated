//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AtletiASPMVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Athlete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Nullable<int> fk_Nationality { get; set; }
        public string Sex { get; set; }
        public Nullable<System.DateTime> Dob { get; set; }
        public Nullable<double> Height { get; set; }
        public Nullable<double> Weight { get; set; }
        public int FK_Sport { get; set; }
        public Nullable<int> gold { get; set; }
        public Nullable<int> silver { get; set; }
        public Nullable<int> bronze { get; set; }
    
        public virtual Nationality Nationality { get; set; }
        public virtual Sport Sport { get; set; }
    }
}
