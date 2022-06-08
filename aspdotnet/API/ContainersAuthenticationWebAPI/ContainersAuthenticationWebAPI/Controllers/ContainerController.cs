using ContainersAuthenticationWebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ContainersAuthenticationWebAPI.Data;

namespace ContainersAuthenticationWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        [HttpGet,Authorize]
        public IActionResult GetAllContainers()
        {
            var containers = ContainerStore.GetContainers();
            return Ok(containers);
        }

        [HttpGet("{id}"),Authorize]
        public IActionResult GetContainer(int id)
        {
            var container = ContainerStore.GetContainer(id);
            if(container == null)
                return BadRequest("Wrong Container");
            return Ok(container);
        }

    }
}
