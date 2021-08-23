
using ApiConsumoEletrico.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiConsumoEletrico.CrossCutting.IoC.Config
{
    public static class Configurations
    {

        public static IServiceCollection ProjectConfigurations(this IServiceCollection service, IConfiguration configuration)
        {
                        string connectionString = configuration.GetSection("ConnectionString").GetSection("Connection").Value;
            service.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connectionString));
            return service;
        }
    }
}
