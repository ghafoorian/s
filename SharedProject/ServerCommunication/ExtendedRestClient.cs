using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using RestSharp;


namespace SharedProject
{
    class ExtendedRestClient : RestClient
    {

        public ExtendedRestClient(string baseUrl) : base(baseUrl)
        {
        }

        public override RestRequestAsyncHandle ExecuteAsync(IRestRequest request, Action<IRestResponse, RestRequestAsyncHandle> callback)
        {
            var restRequestAsyncHandle = base.ExecuteAsync(request, callback);

            if (restRequestAsyncHandle?.WebRequest != null)
                restRequestAsyncHandle.WebRequest.AllowWriteStreamBuffering = false;

            return restRequestAsyncHandle;
        }
    }
}
