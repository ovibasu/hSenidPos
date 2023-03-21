using hSenidPos.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace hSenidPos.Client.Services.ItemService
{
    public class ItemService : IItemService
    {
        private readonly HttpClient _http;

        public ItemService(HttpClient http)
        {
            _http = http;
        }

        public async Task<Item> DeleteItem(int id)
        {
            var result = await _http.DeleteAsync($"api/Items/{id}");

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                return new Item { ItemName = message };
            }
            else
            {
                return await result.Content.ReadFromJsonAsync<Item>();
            }
        }

        public async Task<Item> GetItem(int id)
        {
            return await _http.GetFromJsonAsync<Item>($"api/Items/{id}");
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            return await _http.GetFromJsonAsync<List<Item>>("api/Items");
        }

        public async Task<Item> PostItem(Item item)
        {
            var result = await _http.PostAsJsonAsync($"api/Items", item);
            return await result.Content.ReadFromJsonAsync<Item>();
        }

        public async Task PutItem(int id, Item item)
        {
            var result = await _http.PutAsJsonAsync($"api/Items/{id}", item);

            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var message = await result.Content.ReadAsStringAsync();
                Console.WriteLine(message);
                new Item { ItemName = message };
            }
            else
            {
                await result.Content.ReadFromJsonAsync<Item>();
            }
        }
    }
}
