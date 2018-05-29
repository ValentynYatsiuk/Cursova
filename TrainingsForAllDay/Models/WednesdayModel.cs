using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingsForAllDay.Models
{
    public class WednesdayModel
    {
        public int WednesdayId { get; set; }
        public string NameOfTraining { get; set; }
        public float WeightOFTraining { get; set; }
        public int Approach { get; set; }
        public int Appr1 { get; set; }
        public int Appr2 { get; set; }
        public int Appr3 { get; set; }
        public int Appr4 { get; set; }
        public int Appr5 { get; set; }

        public virtual DateModel DateModel { get; set; }

    }
}