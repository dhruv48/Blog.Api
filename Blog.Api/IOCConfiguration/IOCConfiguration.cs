using Blog.Api.Authorization;
using Blog.Api.Services.Implement;
using Blog.Api.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Blog.Api.IOCConfiguration
{
    public class IOCConfiguration
    {
        public static void Configuration(IServiceCollection services)
        {
            Configure(services, Blog.DB.IOC.Module.GetTypes());
            Configure(services, Blog.Manager.IOC.Module.GetTypes());
            //Configure(services, Blog.Services.IOC.Module.GetTypes());
            services.AddScoped(typeof(IJwtManager), typeof(JwtManager));
            services.AddScoped(typeof(IEmailService), typeof(EmailService));
        }


        private static void Configure(IServiceCollection services, Dictionary<Type, Type> types)
        {
            foreach (var type in types)
            {
                services.AddScoped(type.Key, type.Value);
            }

        }
    }
}
