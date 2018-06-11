﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebChat.Areas.Identity.Data;
using WebChat.Models;

[assembly: HostingStartup(typeof(WebChat.Areas.Identity.IdentityHostingStartup))]
namespace WebChat.Areas.Identity
{

        public class IdentityHostingStartup : IHostingStartup
        {
            public void Configure(IWebHostBuilder builder)
            {
                builder.ConfigureServices((context, services) => {
                    services.AddDbContext<WebChatContext>(options =>
                        options.UseSqlServer(
                            context.Configuration.GetConnectionString("WebChatContextConnection")));

                    services.AddDefaultIdentity<WebChatUser>()
                        .AddEntityFrameworkStores<WebChatContext>();
                });
            }
        }
}