using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TrainingsForAllDay.Models
{
    public class DateModel
    {
        public int DateId { get; set; }
        public string Datetime { get; set; }


        public virtual ICollection<MondayModel> MondayModels { get; set; }
        public virtual ICollection<WednesdayModel> WednesdayModels { get; set; }
        public virtual ICollection<FridayModel> FridayModels { get; set; }

    }

    
}