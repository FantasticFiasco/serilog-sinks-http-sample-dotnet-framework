﻿using System.Web.Http;
using Owin;

namespace LogServer
{
    public class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();

            config.MapHttpAttributeRoutes();
            
            appBuilder.UseWebApi(config);
        }
    }
}
