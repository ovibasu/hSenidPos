using hSenidPos.Server.Data;
using hSenidPos.Server.Services.UserService;
using hSenidPos.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hSenidPos.Server.Services.BillMasterService
{
    public class BillMasterService : IBillMasterService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;

        public BillMasterService(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<BillMaster> DeleteBillMaster(int id)
        {
            var bill = await _context.BillMasters.FindAsync(id);
            _context.BillMasters.Remove(bill);
            await _context.SaveChangesAsync();
            return bill;
        }

        public async Task<BillMaster> GetBillMaster(int id)
        {
            return await _context.BillMasters.FindAsync(id);
        }

        public async Task<IEnumerable<BillMaster>> GetBillMasters()
        {
            return await _context.BillMasters.OrderBy(c => c.BillNo)
                                             .ToListAsync();
        }

        public async Task<BillMaster> PostBillMaster(BillMaster billMaster)
        {
            var billNo = GenerateBillNo();
            billMaster.BillNo = billNo;
            billMaster.CreatedBy = _userService.GetUserId();
            billMaster.CreatedDate = DateTime.UtcNow;
            _context.BillMasters.Add(billMaster);
            await _context.SaveChangesAsync();
            return billMaster;
        }

        public async Task PutBillMaster(int id, BillMaster billMaster)
        {
            billMaster.UpdatedBy = _userService.GetUserId();
            billMaster.UpdatedDate = DateTime.UtcNow;
            _context.Entry(billMaster).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public bool BillMasterExists(int id)
        {
            return _context.BillMasters.Any(c => c.BillMasterId == id);
        }

        private string GenerateBillNo()
        {
            var b = "BL-";
            var billNo = _context.BillMasters.Max(bm => bm.BillNo);
            int a = 0;
            if (billNo != null)
            {
                a = Convert.ToInt32(billNo.Replace(b, string.Empty));
            }
            int no = ++a;
            var result = b + no.ToString();
            return result;
        }
    }
}
