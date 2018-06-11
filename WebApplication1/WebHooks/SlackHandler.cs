using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Collections.Specialized;
using System.Net.Http.Formatting;
using System.Net.Http;
using System.Web.Http.Controllers;

namespace WebApplication1.WebHooks
{
    public class SlackWebHookHandler : WebHookHandler
    {
        public override Task ExecuteAsync(string generator, WebHookHandlerContext context)
        {
            NameValueCollection nvc;
            if (context.TryGetData<NameValueCollection>(out nvc))
            {
                string question = nvc["subtext"];
                string msg = string.Format("TEST");
                SlackResponse reply = new SlackResponse(msg);
                context.Response = context.Request.CreateResponse(reply);
            }
            return Task.FromResult(true);
        }
    }
}