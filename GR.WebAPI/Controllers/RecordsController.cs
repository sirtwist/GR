using GR.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Caching;
using System.Web.Http;

namespace GR.WebAPI.Controllers
{
    public class RecordsController : ApiController
    {


        [HttpGet]
        [Route("records/{sort}")]
        public IEnumerable<Record> Get(string sort)
        {
            SortOrder outputType = SortOrder.GenderThenName;
            switch (sort.ToLower())
            {
                case "gender":
                    outputType = SortOrder.GenderThenName;
                    break;
                case "birthdate":
                    outputType = SortOrder.Birthdate;
                    break;
                case "name":
                    outputType = SortOrder.Lastname;
                    break;
            }
            List<Record> people = new List<Record>();
            if (MemoryCache.Default.Contains("People"))
            {
                people = (List<Record>)MemoryCache.Default["People"];
            }
            return Output.Sort(people, outputType);
        }


        // POST: api/Records
        [HttpPost]
        [Route("records")]
        public void Post([FromBody]string value)
        {
            List<Record> people = new List<Record>();
            if (MemoryCache.Default.Contains("People"))
            {
                people = (List<Record>)MemoryCache.Default["People"];
            }
            var factory = new PersonFactory();
            people.Add(Input.ParseLine(factory, value));

            MemoryCache.Default.Set("People", people, DateTimeOffset.Now.AddDays(30));
        }

    }
}
