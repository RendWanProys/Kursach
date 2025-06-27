using System;
using System.Collections.Generic;

namespace KursProjectISP31.Model;

public partial class FlightData
{
    public int Id { get; set; }

    public string FlightNumber { get; set; }

    public DateTime Date { get; set; }

    public int Passengers { get; set; }

    public double LoadPercentage { get; set; }

    public decimal Profit { get; set; }

    public virtual RouteSheet RouteSheet { get; set; }
}