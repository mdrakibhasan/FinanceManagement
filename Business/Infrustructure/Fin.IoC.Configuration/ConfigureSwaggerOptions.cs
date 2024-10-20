﻿using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fin.IoC.Configuration
{
    public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
       
        public ConfigureSwaggerOptions()
        {
            
        }
        public void Configure(SwaggerGenOptions options)
        {
            //foreach (var desc in _apiVersion.ApiVersionDescriptions)
            //{
            //    options.SwaggerDoc(
            //        desc.GroupName, new Microsoft.OpenApi.Models.OpenApiInfo()
            //        {
            //            Title = $"Financial Management API {desc.ApiVersion}",
            //            Contact = new OpenApiContact
            //            {
            //                Name = "MD Rakib Hasan",
            //                Email = "rakib.data95@gmail.com",
            //            },
            //            Version = desc.ApiVersion.ToString()
            //        });

            //}
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description =
               "JWT Authorization header using the Bearer scheme. \r\n\r\n " +
               "Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\n" +
               "Example: \"Bearer 12345abcdef\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });

            //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //   var xmlPath = System.IO.Path.Combine(AppContext.BaseDirectory, xmlFile);
            //   options.IncludeXmlComments(xmlPath);


        }
    }
}
