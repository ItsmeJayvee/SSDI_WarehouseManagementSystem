using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseManagementSystem.Server.Data;
using WarehouseManagementSystem.Server.Helpers;
using WarehouseManagementSystem.Shared;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace SonicWarehouseManagement.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessPartnersController : ControllerBase
    {
        private readonly AppDBContext _context;

        public BusinessPartnersController(AppDBContext context)
        {
            _context = context;
        }

        // GET: api/BusinessPartners
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusinessPartner>>> GetBusiness_Partners([FromQuery] SalesInvoicePagination pagination, [FromQuery] string card)
        {
            var queryable = _context.Business_Partners.AsQueryable();
            if (!string.IsNullOrEmpty(card))
            {
                queryable = queryable.Where(x => x.Card_Code.Contains(card));
            }
            await HttpContext.InsertPaginationParameterResponse(queryable, pagination.QuantityPerPage);
            return await queryable.Paginate(pagination).ToListAsync();
        }

        // GET: api/BusinessPartners/totalBP
        [HttpGet("totalBP")]
        public async Task<ActionResult<IEnumerable<BusinessPartner>>> GetBusiness_Partners_Count()
        {
            var totalCount = _context.Business_Partners.Count();

            return Ok(totalCount);
        }

        // GET: api/BusinessPartners/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BusinessPartner>> GetBusinessPartner(int id)
        {
            var businessPartner = await _context.Business_Partners.FindAsync(id);

            if (businessPartner == null)
            {
                return NotFound();
            }

            return businessPartner;
        }

        // GET: api/BusinessPartners/5
        [HttpGet("getbp/{id}")]
#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        public async Task<ActionResult<BusinessPartner>> GetBusinessPartner2(string id)
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
        {
            var businessPartner = _context.Business_Partners.Where(x => x.Card_Code == id).Distinct().FirstOrDefault();

            if (businessPartner == null)
            {
                return NotFound();
            }

            return Ok(businessPartner);
        }

        // PUT: api/BusinessPartners/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("updatebp/{id}")]
        public async Task<IActionResult> PutBusinessPartner(int id, BusinessPartner businessPartner)
        {
            if (id != businessPartner.Id)
            {
                return BadRequest();
            }

            _context.Entry(businessPartner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessPartnerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BusinessPartners
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<BusinessPartner>> PostBusinessPartner(BusinessPartner businessPartner)
        {
            _context.Business_Partners.Add(businessPartner);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBusinessPartner", new { id = businessPartner.Id }, businessPartner);
        }

        [HttpPost("checkDup/{outletcode}")]
        public async Task<ActionResult<BusinessPartner>> PostBusinessPartner(string outletcode, BusinessPartner businessPartner)
        {
            var bp = _context.Business_Partners.Where(x => x.Card_Code == outletcode).Distinct().Count();

            if (bp == 0)
            {
                _context.Business_Partners.Add(businessPartner);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetBusinessPartner", new { id = businessPartner.Id }, businessPartner);
            }

            return Ok("Duplicate");
        }

        // DELETE: api/BusinessPartners/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BusinessPartner>> DeleteBusinessPartner(int id)
        {
            var businessPartner = await _context.Business_Partners.FindAsync(id);
            if (businessPartner == null)
            {
                return NotFound();
            }

            _context.Business_Partners.Remove(businessPartner);
            await _context.SaveChangesAsync();

            return businessPartner;
        }

        private bool BusinessPartnerExists(int id)
        {
            return _context.Business_Partners.Any(e => e.Id == id);
        }
    }
}
