using hSenidPos.Server.Services.BillDetailsService;
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
    public class BillDetailsController : ControllerBase
    {
        private readonly IBillDetailsService _billDetailsService;

        public BillDetailsController(IBillDetailsService billDetailsService)
        {
            _billDetailsService = billDetailsService;
        }

        //GET: api/BillDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillDetails>>> GetBillDetails()
        {
            return Ok(await _billDetailsService.GetBillDetails());
        }

        //GET: api/BillDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillDetails>> GetBillDetail(int id)
        {
            return await _billDetailsService.GetBillDetail(id);
        }

        //GET: api/BillDetails/GetBillDetailById/5
        [HttpGet("{GetBillDetailById}/{id}")]
        public async Task<ActionResult<IEnumerable<BillDetails>>> GetBillDetailById(int id)
        {
            return Ok(await _billDetailsService.GetBillDetailById(id));
        }

        //PUT: api/BillDetails/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutBillDetails(int id, IEnumerable<BillDetails> billDetails)
        {
            try
            {
                await _billDetailsService.PutBillDetails(id, billDetails);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BillDetailsExists(id))
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

        //POST: api/BillDetails
        [HttpPost]
        public async Task<ActionResult<IEnumerable<BillDetails>>> PostBillDetails(IEnumerable<BillDetails> billDetails)
        {
            return Ok(await _billDetailsService.PostBillDetails(billDetails));
        }

        //DELETE: api/BillDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BillDetails>> DeleteBillDetails(int id)
        {
            var bill = await _billDetailsService.DeleteBillDetails(id);
            if (bill == null)
            {
                return NotFound();
            }
            return bill;
        }

        //DELETE: api/BillDetails/DeleteBillDetailsById/5
        [HttpDelete("{DeleteBillDetailsById}/{id}")]
        public async Task<ActionResult<IEnumerable<BillDetails>>> DeleteBillDetailsById(int id)
        {
            return Ok(await _billDetailsService.DeleteBillDetailsById(id));
        }

        private bool BillDetailsExists(int id)
        {
            return _billDetailsService.BillDetailsExists(id);
        }
    }
}
