using System.Linq;
using System.Threading.Tasks;
using Balloon.Database;
using Balloon.Entities;
using Balloon.Hubs;
using Balloon.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace Balloon.Controllers
{
    [ApiController]
    [Route("api/balloon")]
    public class BalloonController: ControllerBase
    {
        private readonly BalloonDbContext _dbContext;
        private readonly IHubContext<BallonHub> _hubContext;

        public BalloonController(BalloonDbContext dbContext, IHubContext<BallonHub> hubContext)
        {
            _dbContext = dbContext;
            _hubContext = hubContext;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_dbContext.Params.FirstOrDefault());
        }

        [HttpPut]
        public async Task<ActionResult> UpdateValue([FromBody] ParamViewModel newParam)
        {
            Param param = _dbContext.Params?.FirstOrDefault();

            if (param != null)
            {
                //TODO: se puede mejorar usando automapper
                param.Color = newParam.Color;
                param.Diameter = newParam.Diameter;
                
                _dbContext.Update(param);
                _dbContext.SaveChanges();
            }

            await _hubContext.Clients.All.SendCoreAsync("circleUpdated", new object[]{ newParam });
            
            return Ok();

        }
    }
}