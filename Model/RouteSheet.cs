using System;
using System.Collections.Generic;

namespace KursProjectISP31.Model;

public partial class RouteSheet
{
    public int Id { get; set; }

    public string FlightNumber { get; set; }  

    public string RouteNumber { get; set; }  

    public decimal Price { get; set; }      

    public DateTime DepartureTime { get; set; }

    public DateTime ArrivalTime { get; set; }  

    public string DriverName { get; set; }    

    public DateTime Date { get; set; }   

    public virtual ICollection<FlightData> FlightData { get; set; } = [];
}