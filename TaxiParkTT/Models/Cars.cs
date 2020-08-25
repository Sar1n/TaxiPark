using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiParkTT.Models
{
	public class Cars
	{
		public int Id { get; set; }
		//public string Model { get; set; }
		public CarModels Model { get; set; }
		public string LicenseNumber { get; set; }
		public int Mileage { get; set; }
		public DateTime RegistrationDate { get; set; }
	}
}