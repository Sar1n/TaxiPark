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
	public class ModelsController : ApiController
    {
		public HttpResponseMessage Get()
		{
			HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
			return response;
		}
		public HttpResponseMessage Get(string id)
		{
			CarsContext db = new CarsContext(); 
			var models = from m in db.Models
						 where m.Brand.BrandName.ToLower() == id.ToLower()
						 select new { Model = m.Model };
			var Models = models.ToList();
			string body = "";
			body += JsonSerializer.Serialize(Models);
			HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
			response.Content = new StringContent(body);
			return response;
		}
	}
}
