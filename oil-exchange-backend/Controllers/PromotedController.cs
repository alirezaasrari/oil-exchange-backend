using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using oil_exchange_backend.Context;
using oil_exchange_backend.Models;
using oil_exchange_backend.Models.ViewModels;

namespace oil_exchange_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotedController : ControllerBase
    {
        private readonly DataContext _context;

        public PromotedController(DataContext context)
        {
            _context = context;
        }
        [HttpPost("promote"), Authorize]
        public async Task<IActionResult> Promote (PromotedDto request)
        {
            try
            {
                Promoted promoted = new()
                {
                    Userid = request.Userid,
                    Promoteddate = DateTime.Now,
                };

                _context.Promotedusers.Add(promoted);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {

                var ineerexception = ex.InnerException;
                if (ineerexception != null)
                {
                    return BadRequest(ineerexception.Message);
                }
                else
                {
                    return BadRequest("bad request");
                };
            } 
        }
        [HttpGet("get-promoted"), Authorize]
        public async Task<ActionResult<string>> DatePromoted(int request)
        {
            
            try
            {
                var user = await _context.Promotedusers.FirstOrDefaultAsync(e => e.Userid == request);
                if (user is null)
                {
                    return BadRequest();
                }
                var date = user.Promoteddate;
                return Ok(date.ToString());
            }
            catch (Exception ex)
            {

                var ineerexception = ex.InnerException;
                if (ineerexception != null)
                {
                    return BadRequest(ineerexception.Message);
                }
                else
                {
                    return BadRequest("bad request");
                };
            }
        }
    }
}
