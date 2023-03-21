using hSenidPos.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace hSenidPos.Client.Services.BillMasterService
{
    public class BillMasterService : IBillMasterService
    {
        private readonly HttpClient _http;

        public BillMasterService(HttpClient http)
        {
            _http = http;
        }

        public async Task<BillMaster> DeleteBillMaster(int id)
        {
            var result = await _http.DeleteAsync($"api/BillMasters/{id}");

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                return new BillMaster { BillNo = message };
            }
            else
            {
                return await result.Content.ReadFromJsonAsync<BillMaster>();
            }
        }

        public async Task<BillMaster> GetBillMaster(int id)
        {
            return await _http.GetFromJsonAsync<BillMaster>($"api/BillMasters/{id}");
        }

        public async Task<IEnumerable<BillMaster>> GetBillMasters()
        {
            return await _http.GetFromJsonAsync<List<BillMaster>>("api/BillMasters");
        }

        public async Task<BillMaster> PostBillMaster(BillMaster billMaster)
        {
            var result = await _http.PostAsJsonAsync($"api/BillMasters", billMaster);
            return await result.Content.ReadFromJsonAsync<BillMaster>();
        }

        public async Task PutBillMaster(int id, BillMaster billMaster)
        {
            var result = await _http.PutAsJsonAsync($"api/BillMasters/{id}", billMaster);

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                new BillMaster { BillNo = message };
            }
            else
            {
                await result.Content.ReadFromJsonAsync<BillMaster>();
            }
        }
    }
}
