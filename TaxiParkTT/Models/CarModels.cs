using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaxiParkTT.Models
{
	public class CarModels
	{
		public int Id { get; set; }
		public string Model { get; set; }
		public Brands Brand { get; set; }
	}
}