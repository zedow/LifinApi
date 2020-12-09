using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LifinAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LifinAPI.Models
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<LifinContext>());
            }

        }

        public static void SeedData(LifinContext context)
        {
            Console.WriteLine("Applying migration");
            context.Database.Migrate();
        }
    }
}
