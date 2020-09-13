using System;
using Microsoft.AspNetCore.Mvc;
using Mongolab.Models;
using System.Collections.Generic;
using Mongolab.Services;

namespace Mongolab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComponentController : ControllerBase
    {
        private readonly ComponentService _cmptSvc;
        public ComponentController(ComponentService cmptSvc)
        {
            _cmptSvc = cmptSvc;
        }

        [HttpGet]
        public List<Component> Get()
        {
            return _cmptSvc.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Component> Get(string id)
        {
            var cmpt = _cmptSvc.Get(id);
            if (cmpt != null)
                return cmpt;
            else
                return NotFound();
        }


        [HttpPost]
        public ActionResult<Component> Insert(Component cmpt)
        {
            _cmptSvc.Insert(cmpt);
            return Ok(cmpt.Id);
        }

        [HttpDelete("{id}")]
        public ActionResult<Component> Delete(string id)
        {
            _cmptSvc.Delete(id);
            return NoContent();
        }
    }

}