using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WcfMVCApplication.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {
        ServiceReference1.UserServiceClient ser = new ServiceReference1.UserServiceClient();
        // GET api/values
        public IEnumerable<ServiceReference1.User> Get()
        {
            var data = ser.GetUser();
            return data;
        }

        // GET api/values/5
/*        public string Get(int id)
        {
            return ser.;
        }*/

        // POST api/values
        public string Post([FromBody] ServiceReference1.User user)
        {
            return ser.PostUser(user);
        }

        // PUT api/values/5
        public string Put(string id, [FromBody] ServiceReference1.User user)
        {
            return ser.PutUser(Convert.ToString(id), user);

        }

        // DELETE api/values/5
        public string Delete(string id)
        {
            return ser.DeleteUser(Convert.ToString(id));
        }
    }
}
