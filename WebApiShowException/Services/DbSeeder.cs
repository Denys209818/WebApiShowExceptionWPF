using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiShowException.Entities;
using WebApiShowException.Entities.Identities;

namespace WebApiShowException.Services
{
    public struct ROLES {
        public static readonly string ADMIN = "ADMIN";
        public static readonly string USER = "USER";
    };

    public static class DbSeeder
    {
        public async static Task SeedAll(this IApplicationBuilder app) 
        {
            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope()) 
            {
                EFDbContext context = scope.ServiceProvider.GetRequiredService<EFDbContext>();

                await SeedCars(context);

                await SeedIdentity(scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>(), 
                    scope.ServiceProvider.GetRequiredService<RoleManager<AppRole>>());
            } 
        }
        private async static Task SeedCars(EFDbContext context) 
        {
            await Task.Run(() => { 
                if (!context.Cars.Any()) 
                {
                    context.Cars.AddRange(new List<AppCar> { 
                    new AppCar
                    {
                        Mark = "BMW",
                        Model = "X7",
                        Capacity = 3.1F,
                        Year = 2021,
                        Image = "https://cdn.motor1.com/images/mgl/PEEOy/s1/inkas-armored-bmw-x7.jpg"
                    },
                    new AppCar
                    {
                        Mark = "Bentley",
                        Model = "Continental",
                        Capacity = 3.1F,
                        Year = 2021,
                        Image = "https://auto.ironhorse.ru/wp-content/uploads/2018/06/Continental-GT-3.jpg"
                    },
                    new AppCar
                    {
                        Mark = "Chevrolet",
                        Model = "Camaro",
                        Capacity = 3.1F,
                        Year = 2021,
                        Image = "https://i.pinimg.com/originals/59/bb/6f/59bb6f462714b5e7036fe28cf82c18b6.jpg"
                    }
                });

                    context.SaveChanges();
                }
            });
        }
        private async static Task SeedIdentity(UserManager<AppUser> manUser, RoleManager<AppRole> manRole) 
        {
            if (!manRole.Roles.Any()) 
            {
                await manRole.CreateAsync(new AppRole { 
                    Name = ROLES.ADMIN,
                });

                await manRole.CreateAsync(new AppRole { 
                    Name = ROLES.USER
                });
            }
        }
    }
}
