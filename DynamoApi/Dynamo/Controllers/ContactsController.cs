using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dynamo.Common.DTOs;
using Dynamo.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dynamo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ILogger<ContactsController> _logger;
        private readonly IContactsService _contactsService;
        public ContactsController(ILogger<ContactsController> logger, IContactsService contactsService)
        {
            _logger = logger;
            _contactsService = contactsService;
        }

        [HttpGet("GetContacts")]
        public IActionResult GetContacts()
        {
            var result = _contactsService.GetContacts();
            return Ok(result);
        }

        [HttpGet("GetContactById/{id}")]
        public IActionResult GetContactById(int id)
        {
            var result = _contactsService.GetContactById(id);
            return Ok(result);
        }

        [HttpPost("Edit")]
        public IActionResult Edit([FromBody]ContactDTO contact)
        {
            _contactsService.Edit(contact);
            return Ok();
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody]ContactSlimDTO contact)
        {   

            _contactsService.Create(contact);
            return Ok();
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromBody]int id)
        {
            _contactsService.Delete(id);
            return Ok();
        }
    }
}