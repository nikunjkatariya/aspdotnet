using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IUserService" in both code and config file together.
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [WebInvoke(Method ="GET",UriTemplate ="/Users",RequestFormat =WebMessageFormat.Json,
            ResponseFormat =WebMessageFormat.Json,
            BodyStyle =WebMessageBodyStyle.Bare)]
        IEnumerable<User> GetUser();

        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "/Users", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        string PostUser(User user);

        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "/Users/{id}", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        string PutUser(string id,User user);

        [OperationContract]
        [WebInvoke(Method = "DELETE", UriTemplate = "/Users/{id}", RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare)]
        string DeleteUser(string id);
    }
}
