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
    
    public partial class Population
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Population()
        {
            this.Family_Household = new HashSet<Family_Household>();
            this.Family_Household1 = new HashSet<Family_Household>();
            this.Household_Registration = new HashSet<Household_Registration>();
            this.Temporary_Absence = new HashSet<Temporary_Absence>();
            this.Temporary_Residence = new HashSet<Temporary_Residence>();
            this.Transfer_Household = new HashSet<Transfer_Household>();
        }
    
        public int Stt { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Id_Household { get; set; }
        public string PlaceOfBirth { get; set; }
        public string Address { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<bool> Sex { get; set; }
        public string Relegion { get; set; }
        public string Career { get; set; }
        public Nullable<bool> isAbsence { get; set; }
        public Nullable<bool> isTResidence { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Family_Household> Family_Household { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Family_Household> Family_Household1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Household_Registration> Household_Registration { get; set; }
        public virtual Household_Registration Household_Registration1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Temporary_Absence> Temporary_Absence { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Temporary_Residence> Temporary_Residence { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transfer_Household> Transfer_Household { get; set; }
    }
}
