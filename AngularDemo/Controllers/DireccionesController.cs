using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularDemo.Models;

namespace AngularDemo.Controllers
{
    [Produces("application/json")]
    [Route("api/Direcciones")]
    public class DireccionesController : Controller
    {
        private readonly AppDbContext dbContext;

        public DireccionesController(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("delete/list")]
        public IActionResult DeleteList([FromBody] List<int> ids)
        {
            try
            {
                List<Address> direcciones = ids.Select(id => new Address() { AddressId = id }).ToList();
                dbContext.RemoveRange(direcciones);
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

    }
}
