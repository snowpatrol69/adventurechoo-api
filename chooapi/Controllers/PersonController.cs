using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using chooapi.Repository;
using Serilog;


namespace chooapi.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class PersonController:ControllerBase
    {
        private readonly IPersonRepository _personRepository;   

        public PersonController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        { 
            var _list = await this._personRepository.GetAll();
            if (_list != null)
            {
                Log.Information("Get Persons => {@_list}", _list);
            
                return Ok(_list);
            }
            else
            {
                return NotFound();
            }

        }


    }
}
