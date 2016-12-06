using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using System.Reflection;
using Common;
using AutoMapper;
using BookStore.Service.Mapping;
using Microsoft.Owin.Cors;

[assembly: OwinStartup(typeof(BookStore.Startup))]

namespace BookStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            ConfigureAuth(app);
        }
    }
}
