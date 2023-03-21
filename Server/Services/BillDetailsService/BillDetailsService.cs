using hSenidPos.Server.Data;
using hSenidPos.Server.Services.UserService;
using hSenidPos.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hSenidPos.Server.Services.BillDetailsService
{
    public class BillDetailsService : IBillDetailsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;
        public BillDetailsService(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<BillDetails> DeleteBillDetails(int id)
        {
            var billDetails = await _context.BillDetails.FindAsync(id);
            _context.BillDetails.Remove(billDetails);
            await _context.SaveChangesAsync();
            return billDetails;
        }

        public async Task<IEnumerable<BillDetails>> DeleteBillDetailsById(int id)
        {
            var billDetails = await _context.BillDetails.Where(c => c.BillMasterId == id).ToListAsync();
            foreach (var bill in billDetails)
            {
                _context.BillDetails.Remove(bill);
            }
            await _context.SaveChangesAsync();
            return billDetails;
        }

        public async Task<BillDetails> GetBillDetail(int id)
        {
            return await _context.BillDetails.FindAsync(id);
        }

        public async Task<IEnumerable<BillDetails>> GetBillDetailById(int id)
        {
            return await _context.BillDetails.Where(c => c.BillMasterId == id).ToListAsync();
        }

        public async Task<IEnumerable<BillDetails>> GetBillDetails()
        {
            return await _context.BillDetails.Include(i => i.Item)
                                                .Include(c => c.BillMaster)
                                                .ToListAsync();
        }

        public async Task<IEnumerable<BillDetails>> PostBillDetails(IEnumerable<BillDetails> billDetails)
        {
            foreach (var bill in billDetails)
            {
                bill.CreatedBy = _userService.GetUserId();
                bill.CreatedDate = DateTime.UtcNow;
                _context.BillDetails.Add(bill);
            }
            await _context.SaveChangesAsync();
            return billDetails;
        }

        public async Task PutBillDetails(int id, IEnumerable<BillDetails> billDetails)
        {
            foreach (var bill in billDetails)
            {
                if (bill.BillMasterId == 0)
                {
                    bill.CreatedBy = _userService.GetUserId();
                    bill.CreatedDate = DateTime.UtcNow;
                    _context.BillDetails.Add(bill);
                }
                else
                {
                    bill.UpdatedBy = _userService.GetUserId();
                    bill.UpdatedDate = DateTime.UtcNow;
                    _context.Entry(bill).State = EntityState.Modified;
                }
            }
            await _context.SaveChangesAsync();
        }

        public bool BillDetailsExists(int id)
        {
            return _context.BillDetails.Any(c => c.BillMasterId == id);
        }
    }
}
