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
    
    public partial class Temporary_Absence
    {
        public int Stt { get; set; }
        public string Id { get; set; }
        public string Id_Owner { get; set; }
        public string NameOfOwner { get; set; }
        public string Id_Household { get; set; }
        public string HouseOwnerName { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> ExpireDate { get; set; }
    
        public virtual Household_Registration Household_Registration { get; set; }
        public virtual Population Population { get; set; }
    }
}
