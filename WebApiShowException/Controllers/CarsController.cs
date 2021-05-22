using App.Lib.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WebApiShowException.Entities;

namespace WebApiShowException.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private EFDbContext _context;
        public CarsController(EFDbContext context)
        {
            _context = context;
        }

        [Route("add"), HttpPost]
        public async Task<IActionResult> AddCar([FromBody] CarModel car) 
        {
            return await Task.Run(() => {
                IActionResult result = Ok(Encoding.UTF8.GetBytes("Додано у БД!"));
              

                    _context.Cars.Add(new AppCar
                    {
                         Mark = car.Mark,
                        Model = car.Model,
                        Capacity = car.Capacity,
                        Year = car.Year,
                        Image = car.Image
                    });

                    _context.SaveChanges();
                

                return result;
            });
        }

        [Route("get"), HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            return await Task.Run(() => { 
                return Ok(_context.Cars.ToList());
            }); 
        }
    }
}
