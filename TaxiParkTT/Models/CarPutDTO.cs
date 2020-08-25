using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiParkTT.Models
{
	public class CarPutDTO
	{
		public string Id { get; set; }
		public string Model { get; set; }
		public string Licence { get; set; }
		public string Mileage { get; set; }
	}
}