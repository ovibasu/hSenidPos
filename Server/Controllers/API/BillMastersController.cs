using hSenidPos.Server.Services.BillMasterService;
using hSenidPos.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hSenidPos.Server.Controllers.API
{
    [Authorize(Roles = "Admin")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BillMastersController : ControllerBase
    {
        public readonly IBillMasterService _billMasterService;

        public BillMastersController(IBillMasterService billMasterService)
        {
            _billMasterService = billMasterService;
        }

        //GET: api/BillMasters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillMaster>>> GetBillMasters()
        {
            return Ok(await _billMasterService.GetBillMasters());
        }

        //GET: api/BillMasters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillMaster>> GetBillMaster(int id)
        {
            return await _billMasterService.GetBillMaster(id);
        }

        //PUT: api/BillMasters/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutBillMaster(int id, BillMaster billMaster)
        {
            if (id != billMaster.BillMasterId)
            {
                return BadRequest();
            }
            try
            {
                await _billMasterService.PutBillMaster(id, billMaster);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillMasterExists(id))
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

        //POST: api/BillMasters
        [HttpPost]
        public async Task<ActionResult<BillMaster>> PostBillMaster(BillMaster billMaster)
        {
            await _billMasterService.PostBillMaster(billMaster);
            return CreatedAtAction("GetBillMaster", new { id = billMaster.BillMasterId }, billMaster);
        }

        //DELETE: api/BillMasters/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BillMaster>> DeleteChallanMaster(int id)
        {
            var bill = await _billMasterService.DeleteBillMaster(id);
            if (bill == null)
            {
                return NotFound();
            }
            return bill;
        }

        private bool BillMasterExists(int id)
        {
            return _billMasterService.BillMasterExists(id);
        }
    }
}
