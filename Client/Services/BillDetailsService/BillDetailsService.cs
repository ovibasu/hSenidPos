using hSenidPos.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace hSenidPos.Client.Services.BillDetailsService
{
    public class BillDetailsService : IBillDetailsService
    {
        private readonly HttpClient _http;

        public BillDetailsService(HttpClient http)
        {
            _http = http;
        }

        public async Task<BillDetails> DeleteBillDetails(int id)
        {
            var result = await _http.DeleteAsync($"api/BillDetails/{id}");

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                return new BillDetails { CreatedBy = message };
            }
            else
            {
                return await result.Content.ReadFromJsonAsync<BillDetails>();
            }
        }

        public async Task<IEnumerable<BillDetails>> DeleteBillDetailsById(int id)
        {
            var result = await _http.DeleteAsync($"api/BillDetails/DeleteBillDetailsById/{id}");
            return await result.Content.ReadFromJsonAsync<IEnumerable<BillDetails>>();
        }

        public async Task<BillDetails> GetBillDetail(int id)
        {
            return await _http.GetFromJsonAsync<BillDetails>($"api/BillDetails/{id}");
        }

        public async Task<IEnumerable<BillDetails>> GetBillDetailById(int id)
        {
            return await _http.GetFromJsonAsync<IEnumerable<BillDetails>>($"api/BillDetails/GetBillDetailById/{id}");
        }

        public async Task<IEnumerable<BillDetails>> GetBillDetails()
        {
            return await _http.GetFromJsonAsync<List<BillDetails>>("api/BillDetails");
        }

        public async Task<IEnumerable<BillDetails>> PostBillDetails(IEnumerable<BillDetails> billDetails)
        {
            var result = await _http.PostAsJsonAsync($"api/BillDetails", billDetails);
            return await result.Content.ReadFromJsonAsync<List<BillDetails>>();
        }

        public async Task PutBillDetails(int id, IEnumerable<BillDetails> billDetails)
        {
            var result = await _http.PutAsJsonAsync($"api/BillDetails/{id}", billDetails);

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                new BillDetails { CreatedBy = message };
            }
            else
            {
                await result.Content.ReadFromJsonAsync<List<BillDetails>>();
            }
        }
    }
}
