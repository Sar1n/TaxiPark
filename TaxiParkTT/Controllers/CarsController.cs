using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using TaxiParkTT.Models;
using System.Text.Json;
using System.Threading;
using System.ComponentModel;
using Microsoft.Ajax.Utilities;

namespace TaxiParkTT.Controllers
{
	[EnableCors("*", "*", "*")]
	public class CarsController : ApiController
    {
		public HttpResponseMessage Get()
		{
			CarsContext db = new CarsContext(); 
			var cars = from c in db.Cars
					   select new { Brand = c.Model.Brand.BrandName, Id = c.Id, Model = c.Model.Model, LicenseNumber = c.LicenseNumber, Mileage = c.Mileage, RegistrationDate = c.RegistrationDate };
			var Cars = cars.ToList();
			string body = "";
			body += JsonSerializer.Serialize(Cars);
			HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
			response.Content = new StringContent(body);
			return response;
		}
		public HttpResponseMessage Get(int id)
		{
			CarsContext db = new CarsContext();
			var Car = from c in db.Cars
					  where c.Id  == id
					  select new { Brand = c.Model.Brand.BrandName, Id = c.Id, Model = c.Model.Model, LicenseNumber = c.LicenseNumber, Mileage = c.Mileage, RegistrationDate = c.RegistrationDate };

			string body = JsonSerializer.Serialize(Car);
			HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
			response.Content = new StringContent(body);
			return response;
		}
		public HttpResponseMessage Post([FromBody] CarDTO car)
		{
			try
			{
				CarsContext db = new CarsContext();
				Cars Newcar = new Cars();
				var newcarmodel = from m in db.Models
								  where m.Model.ToLower() == car.Model.ToLower()
								  select m;
				Newcar.Model = newcarmodel.First();
				Newcar.Mileage = int.Parse(car.Mileage);
				Newcar.LicenseNumber = car.Licence;
				Newcar.RegistrationDate = DateTime.Now;
				db.Cars.Add(Newcar);
				db.SaveChanges();
				HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
				return response;
			}
			catch (Exception)
			{
				HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError);
				return response;
			}
		}
		public HttpResponseMessage Put([FromBody] CarPutDTO car)
		{
			try
			{
				CarsContext db = new CarsContext();
				int idtochange = int.Parse(car.Id);
				var actualcar = from c in db.Cars
								where c.Id == idtochange
								select c;
				if (actualcar.First() != null)
				{
					actualcar.First().LicenseNumber = car.Licence;
					actualcar.First().Mileage = int.Parse(car.Mileage);
					var newcarmodel = from m in db.Models
									  where m.Model.ToLower() == car.Model.ToLower()
									  select m;
					actualcar.First().Model = newcarmodel.First();
					db.SaveChanges();
					HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
					return response;
				}
				else
					throw new Exception();
			}
			catch (Exception)
			{
				HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.InternalServerError);
				return response;
			}
		}
		public HttpResponseMessage Delete(int id)
		{
			CarsContext db = new CarsContext();
			Cars CarToDelete = db.Cars.Find(id);
			db.Cars.Remove(CarToDelete); 
			db.SaveChanges();
			return new HttpResponseMessage(HttpStatusCode.OK);
		}
	}
}
