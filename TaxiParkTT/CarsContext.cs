using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaxiParkTT.Models;
using System.Data.Entity;
using System.Data.Common;

namespace TaxiParkTT
{
	public class CarsContext : DbContext
	{
		public CarsContext () : base ("DBConnection")
		{
		}
		public DbSet<Cars> Cars { get; set; }
		public DbSet<Brands> Brands { get; set; }
		public DbSet<CarModels> Models { get; set; }
	}
}