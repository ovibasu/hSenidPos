using hSenidPos.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hSenidPos.Server.Services.BillDetailsService
{
    public interface IBillDetailsService
    {
        Task<IEnumerable<BillDetails>> GetBillDetails();
        Task<IEnumerable<BillDetails>> GetBillDetailById(int id);
        Task<BillDetails> GetBillDetail(int id);
        Task<IEnumerable<BillDetails>> PostBillDetails(IEnumerable<BillDetails> billDetails);
        Task PutBillDetails(int id, IEnumerable<BillDetails> billDetails);
        Task<BillDetails> DeleteBillDetails(int id);
        Task<IEnumerable<BillDetails>> DeleteBillDetailsById(int id);
        bool BillDetailsExists(int id);
    }
}
