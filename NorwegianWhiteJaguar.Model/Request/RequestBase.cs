using RestSharp;

namespace NorwegianWhiteJaguar.Model.Request
{
    public abstract class RequestBase : RestRequest
    {
        protected RequestBase()
        {
            Method = Method.GET;
        }
    }
}
