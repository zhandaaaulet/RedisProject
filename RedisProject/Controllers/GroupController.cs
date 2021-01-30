using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedisProject.Entities;
using RedisProject.Repositories.Interfaces;

namespace RedisProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _repositoty;

        public GroupController(IGroupRepository repositoty)
        {
            _repositoty = repositoty;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Group), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Group>> GetGroup(string name)
        {
            var group = await _repositoty.GetGroup(name);
            return Ok(group ?? new Group(name));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Group), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Group>> UpdateGroup(Group group)
        {
            var updatedGroup = await _repositoty.UpdateGroup(group);
            return Ok(updatedGroup);
        }

        [HttpDelete("{name}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<Group>> DeleteGroup(string name)
        {
            return Ok(await _repositoty.DeleteGroup(name));
        }




    }
}
