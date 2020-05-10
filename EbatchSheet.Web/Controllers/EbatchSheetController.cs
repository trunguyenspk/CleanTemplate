using System.Threading.Tasks;
using Application.EbatchSheets.Commands;
using Application.EbatchSheets.Queries;
using Domain.Commands;
using Domain.Enumerations;
using EbatchSheet.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Comvita.EbatchSheet.Web.Controllers
{
    //[Authorize]
    //[AllowAnonymous]
    public class EbatchSheetController : ApiController
    {
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await Mediator.Send(new GetEbatchSheetsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(string id)
        {
            var result = await Mediator.Send(new GetEbatchSheetQuery() { Id = id });
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateEbatchSheetCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> Update(string id, UpdateEbatchSheetCommand command)
        {
            command.Id = id;
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteById(string id)
        {
            return Ok(await Mediator.Send(new DeleteEbatchSheetCommand() { Id = id }));
        }

        [HttpGet("EbatchStates")]
        public async Task<ActionResult> GetStateEnum()
        {
            return Ok(await Task.FromResult(Enumeration.GetAll<EbatchState>()));
        }
    }
}