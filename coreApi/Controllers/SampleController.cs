﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreApi.Domain.Interfaces;
using coreApi.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace coreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private readonly IRepository _repository;
        public SampleController(AppDBContext context, IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Member>>> GetMember(int page = 0, int pageSize = 5)
        {
            var model = await _repository.SelectAll<Member>();
            return model;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(long id)
        {
            var model = await _repository.SelectById<Member>(id);

            if (model == null)
            {
                return NotFound();
            }

            return model;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(long id, Member model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            await _repository.UpdateAsync<Member>(model);

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Member>> InsertMember(Member model)
        {
            await _repository.CreateAsync<Member>(model);
            return CreatedAtAction("GetMember", new { id = model.Id }, model);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Member>> DeleteMember(long id)
        {
            var model = await _repository.SelectById<Member>(id);

            if (model == null)
            {
                return NotFound();
            }

            await _repository.DeleteAsync<Member>(model);

            return model;
        }
    }
}