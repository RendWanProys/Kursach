using KursProjectISP31.Model;
using System.Collections.Generic;
using System.Linq;

namespace KursProjectISP31.Services
{
    public class RouteSheetService : BaseService<RouteSheet>
    {
        public override bool Add(RouteSheet obj)
        {
            using (var db = new KursovayaContext())
            {
                db.RouteSheets.Add(obj);
                db.SaveChanges();
                return true;
            }
        }

        public override bool Delete(RouteSheet obj)
        {
            using (var db = new KursovayaContext())
            {
                db.RouteSheets.Remove(obj);
                db.SaveChanges();
                return true;
            }
        }

        public override List<RouteSheet> GetAll()
        {
            using (var db = new KursovayaContext())
            {
                return db.RouteSheets.ToList();
            }
        }

        public override bool Update(RouteSheet obj)
        {
            using (var db = new KursovayaContext())
            {
                db.RouteSheets.Update(obj);
                db.SaveChanges();
                return true;
            }
        }

        public override List<RouteSheet> Search(string searchText)
        {
            using (var db = new KursovayaContext())
            {
                return db.RouteSheets
                    .Where(r => r.FlightNumber.Contains(searchText) ||
                                r.RouteNumber.Contains(searchText) ||
                                r.DriverName.Contains(searchText))
                    .ToList();
            }
        }
    }
}