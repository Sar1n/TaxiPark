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
	public class BrandsController : ApiController
    {
		public HttpResponseMessage Get()
		{
			CarsContext db = new CarsContext(); 
			var brands = from b in db.Brands
					   select new { Brand = b.BrandName };
			var Brands = brands.ToList();
			string body = "";
			body += JsonSerializer.Serialize(Brands);
			HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
			response.Content = new StringContent(body);
			return response;
		}
	}
}
