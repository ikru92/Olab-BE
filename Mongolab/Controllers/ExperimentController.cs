﻿using System;
using Microsoft.AspNetCore.Mvc;
using Mongolab.Models;
using System.Collections.Generic;
using Mongolab.Services;

namespace Mongolab.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExperimentController : ControllerBase
    {
        private readonly ExperimentService _exptSvc;
        public ExperimentController(ExperimentService exptSvc)
        {
            _exptSvc = exptSvc;
        }


        [HttpGet]
        public List<Experiment> Get()
        {
            return _exptSvc.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Experiment> Get(string id)
        {
            var expt = _exptSvc.Get(id);
            if (expt != null)
                return expt;
            else
                return NotFound();
        }

        [HttpPost]
        public ActionResult<Experiment> Insert(Experiment expt)
        {
            _exptSvc.Insert(expt);
            return Ok(expt);
        }

        [HttpDelete("{id}")]
        public ActionResult<Experiment> Delete(string id)
        {
            _exptSvc.Delete(id);
            return NoContent();
        }
    }

}
