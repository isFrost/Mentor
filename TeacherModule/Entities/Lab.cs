//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TeacherModule.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Lab
    {
        public Lab()
        {
            this.Progresses = new HashSet<Progress>();
        }
    
        public int Lab_Id { get; set; }
        public int Subj_Id { get; set; }
        public int T_id { get; set; }
        public int S_Id { get; set; }
    
        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Tutor Tutor { get; set; }
        public virtual ICollection<Progress> Progresses { get; set; }
    }
}
