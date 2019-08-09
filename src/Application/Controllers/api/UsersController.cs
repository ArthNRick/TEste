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
    public class UsersController : Controller
    {
        private IService<User> _service;
        private IService<Detail> _serviceDetail;

        public UsersController(IService<User> service, IService<Detail> serviceDetail)
        {
            _service = service;
            _serviceDetail = serviceDetail;
        }

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var users = _service.Get();

            if (users?.Any() == true)
                return Json(users);

            return StatusCode(404, "Nenhum usuário encontrado.");

        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _service.Get(id);
            if (user != null)
                return Json(user);
            return StatusCode(404, "Usuário não existe");
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            var inserted = _service.Insert(user);
            return Json(inserted);
        }

        // PUT api/<controller>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]User user)
        {

            if (id != user.Id)
                return StatusCode(400, "Requisição inválida");

            _service.Update(user);

            return Ok();


        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var details = _serviceDetail.Get().Where(detail => detail.UserId == id).ToList();
            details.ForEach(detail => _serviceDetail.Delete(detail.Id));
            _service.Delete(id);
            return Ok();
        }
    }
}
