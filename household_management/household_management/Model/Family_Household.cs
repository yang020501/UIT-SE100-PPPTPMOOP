//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace household_management.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Family_Household
    {
        public string Id_Household { get; set; }
        public string Id_Owner { get; set; }
        public string Id_Person { get; set; }
        public string Name_Person { get; set; }
    
        public virtual Household_Registration Household_Registration { get; set; }
        public virtual Population Population { get; set; }
        public virtual Population Population1 { get; set; }
    }
}