//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrainingsForAllDay.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Monday
    {
        public int MondayId { get; set; }
        public string NameOfTraining { get; set; }
        public double WeightOfTraining { get; set; }
        public int Approach { get; set; }
        public Nullable<int> Appr1 { get; set; }
        public Nullable<int> Appr2 { get; set; }
        public Nullable<int> Appr3 { get; set; }
        public Nullable<int> Appr4 { get; set; }
        public Nullable<int> Appr5 { get; set; }
        public int DateDateId { get; set; }
    
        public virtual Date Date { get; set; }
    }
}
