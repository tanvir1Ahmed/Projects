using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Newtonsoft.Json;


namespace Library_Management_System.Controllers
{
    public class DemoController : ApiController
    {
        [HttpGet]
        [Route("api/library/record")]
        public async Task<HttpResponseMessage> ShowRecord()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://localhost:44306/api/record/details");
            if (!response.IsSuccessStatusCode)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            var content = await response.Content.ReadAsStringAsync();
            var list = JsonConvert.DeserializeObject(content);
            return Request.CreateResponse(HttpStatusCode.OK, list);
        }
    }
}
