using ActivityTracker.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ActivityTracker.API.Controllers
{
    public class ActivitiesController : ApiController
    {
        //  GET api/activities
        /// <returns> List of all activities of a logged user </returns> 
        //public IEnumerable<Activity> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //  GET api/activities/5
        /// <returns> A specified activity for a logged user </returns>
        //public Activity Get(int id)
        //{

        //    return "value";
        //}

        // POST api/activities
        public void Post([FromBody]string value)
        {
        }

        // PUT api/activities/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/activities/5
        public void Delete(int id)
        {
        }
    }
}