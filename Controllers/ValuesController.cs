using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace RHDPApi.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        [EnableCors("MyPolicy")]
        public async Task<string> GetHomePage()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://smatraffi.southindia.cloudapp.azure.com:5000/API/Homepage");
                    var response = await client.GetAsync("http://smatraffi.southindia.cloudapp.azure.com:5000/API/Homepage");
                    response.EnsureSuccessStatusCode();

                    var stringResult = await response.Content.ReadAsStringAsync();

                    return stringResult;
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
