//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PTRex.MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Exercise
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Exercise()
        {
            this.TargetWorkouts = new HashSet<TargetWorkout>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public string HowTo { get; set; }
        public string Equipment { get; set; }
        public string ResourceVideo { get; set; }
        public string ResourcePhoto { get; set; }
        public string ResourceText { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TargetWorkout> TargetWorkouts { get; set; }
    }
}
