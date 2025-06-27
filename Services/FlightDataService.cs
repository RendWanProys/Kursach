using KursProjectISP31.Model;
using System.Collections.Generic;
using System.Linq;

namespace KursProjectISP31.Services
{
    public class FlightDataService : BaseService<FlightData>
    {
        public override bool Add(FlightData obj)
        {
            using (var db = new KursovayaContext())
            {
                db.FlightData.Add(obj);
                db.SaveChanges();
                return true;
            }
        }

        public override bool Delete(FlightData obj)
        {
            using (var db = new KursovayaContext())
            {
                db.FlightData.Remove(obj);
                db.SaveChanges();
                return true;
            }
        }

        public override List<FlightData> GetAll()
        {
            using (var db = new KursovayaContext())
            {
                return db.FlightData.ToList();
            }
        }

        public override List<FlightData> Search(string searchText)
        {
            using (var db = new KursovayaContext())
            {
                return db.FlightData
                    .Where(f => f.FlightNumber.Contains(searchText) ||
                               f.Date.ToString().Contains(searchText) ||
                               f.Passengers.ToString().Contains(searchText) ||
                               f.LoadPercentage.ToString().Contains(searchText) ||
                               f.Profit.ToString().Contains(searchText))
                    .ToList();
            }
        }

        public override bool Update(FlightData obj)
        {
            using (var db = new KursovayaContext())
            {
                db.FlightData.Update(obj);
                db.SaveChanges();
                return true;
            }
        }
    }
}