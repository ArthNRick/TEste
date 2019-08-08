using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TR.Domain.Entities;
using TR.Domain.Interfaces;
using TR.Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TR.Application.Controllers.api
{
    [Route("api/[controller]")]
    public class DetailsController : Controller
    {
        private IService<Detail> _service;

        public DetailsController(Domain.Interfaces.IService<Detail> service)
        {
            _service = service;
        }

        // GET: api/<controller>
        [HttpGet("{userId}")]
        public IActionResult Get(int userId)
        {
            var details = _service.Get().Where(d => d.UserId == userId);

            if (details?.Any() == true)
                return Json(details);

            return StatusCode(404, "Nenhum detalhe encontrado para este usuário");

        }

        // GET api/<controller>/5
        [HttpGet("{userId}/{id}")]
        public IActionResult Get(int userId, int id)
        {
            var detail = _service.Get(id);

            if (detail != null)
                return Json(detail);

            return StatusCode(404, "Detalhe não econtrado");

        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Detail detail)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put([FromBody]Detail detail)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
