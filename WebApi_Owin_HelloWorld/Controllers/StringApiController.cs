using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi_Owin_HelloWorld.Controllers
{
    [AllowAnonymous]
    public class StringApiController : ApiController
    {
        [HttpPost]
        public MergeResponse ContatenateStrings(MergeRequest request)
        {
            if (request != null)
            {
                string concatenated = request.StrA + " " + request.StrB;

                return new MergeResponse { Success = true, Concatenated = concatenated };
            }
            else
            {
                return new MergeResponse { Success = false };
            }
        }
    }


    public class MergeRequest
    {
        public string StrA { get; set; }
        public string StrB { get; set; }
    }

    public class MergeResponse
    {
        public bool Success { get; set; }
        public string Concatenated { get; set; }
    }
}
