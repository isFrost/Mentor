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
    
    public partial class Lesson
    {
        public int Lesson_Id { get; set; }
        public Nullable<System.DateTime> Les_Date { get; set; }
        public int Subj_Id { get; set; }
        public int T_Id { get; set; }
        public int Gr_Id { get; set; }
    
        public virtual Group Group { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Tutor Tutor { get; set; }
    }
}
