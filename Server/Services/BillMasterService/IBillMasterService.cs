using hSenidPos.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hSenidPos.Server.Services.BillMasterService
{
    public interface IBillMasterService
    {
        Task<IEnumerable<BillMaster>> GetBillMasters();
        Task<BillMaster> GetBillMaster(int id);
        Task<BillMaster> PostBillMaster(BillMaster billMaster);
        Task PutBillMaster(int id, BillMaster billMaster);
        Task<BillMaster> DeleteBillMaster(int id);
        bool BillMasterExists(int id);
    }
}
