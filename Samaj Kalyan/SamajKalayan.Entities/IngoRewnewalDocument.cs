//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Samaj_Kalyan.SamajKalayan.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class IngoRewnewalDocument
    {
        public int DocumentId { get; set; }
        public string DocumentLocation { get; set; }
        public Nullable<int> RewnewalId { get; set; }
        public string FileName { get; set; }
    
        public virtual IngoRenewal IngoRenewal { get; set; }
    }
}
