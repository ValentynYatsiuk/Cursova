using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TrainingsForAllDay.Models;

namespace TrainingsForAllDay.DAL
{
    public class TrainingInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<TrainingContext>
    {
        protected override void Seed(TrainingContext context)
        {
            var dates = new List<DateModel>
            {
                new DateModel {Datetime="25/03/2011" ,},
                new DateModel {Datetime="08/07/2018" ,},
                
            };
            dates.ForEach(s => context.DateModels.Add(s));
            context.SaveChanges();

            var monday = new List<MondayModel>
            {
                new MondayModel{NameOfTraining="Жим гантелей лежа", WeightOFTraining = 12 , Approach =4 , Appr1=12,Appr2=12,Appr3=10,Appr4=8,Appr5=0 ,},
                new MondayModel{NameOfTraining="Приседания со штангой", WeightOFTraining = 40, Approach =3 , Appr1=12,Appr2=12,Appr3=10,Appr4=0,Appr5=0 ,},
            };
            monday.ForEach(s => context.MondayModels.Add(s));
            context.SaveChanges();

            var wednesday = new List<WednesdayModel>
            {
                new WednesdayModel{NameOfTraining="Жим гантелей лежа", WeightOFTraining = 12 , Approach =4 , Appr1=12,Appr2=12,Appr3=10,Appr4=8,Appr5=0 ,},
                new WednesdayModel{NameOfTraining="Приседания со штангой", WeightOFTraining = 40, Approach =3 , Appr1=12,Appr2=12,Appr3=10,Appr4=0,Appr5=0 ,},
            };
            wednesday.ForEach(s => context.WednesdayModels.Add(s));
            context.SaveChanges();

            var friday = new List<FridayModel>
            {
                new FridayModel{NameOfTraining="Жим гантелей лежа", WeightOFTraining = 12 , Approach =4 , Appr1=12,Appr2=12,Appr3=10,Appr4=8,Appr5=0 ,},
                new FridayModel{NameOfTraining="Приседания со штангой", WeightOFTraining = 40, Approach =3 , Appr1=12,Appr2=12,Appr3=10,Appr4=0,Appr5=0 ,},
            };
           friday.ForEach(s => context.FridayModels.Add(s));
            context.SaveChanges();
        }

    }
}