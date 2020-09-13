using System;
using Microsoft.AspNetCore.Mvc;
using Mongolab.Models;
using System.Collections.Generic;
using Mongolab.Services;

namespace Mongolab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TemplateController : ControllerBase
    {
        private readonly ExperimentTemplateService _exptTmpSvc;
        public TemplateController(ExperimentTemplateService exptTmpSvc)
        {
            _exptTmpSvc = exptTmpSvc;
        }
        [HttpGet]
        public List<Experiment> Get()
        {
            return _exptTmpSvc.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Experiment> Get(string id)
        {
            var tmp = _exptTmpSvc.Get(id);
            if (tmp != null)
                return tmp;
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult<Experiment> Insert(Experiment expt)
        {
            _exptTmpSvc.Insert(expt);
            return Ok(expt);
        }

        [HttpDelete("{id}")]
        public ActionResult<Experiment> Delete(string id)
        {
            _exptTmpSvc.Delete(id);
            return NoContent();
        }
    }

}
