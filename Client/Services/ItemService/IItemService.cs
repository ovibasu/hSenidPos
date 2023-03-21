using hSenidPos.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hSenidPos.Client.Services.ItemService
{
    public interface IItemService
    {
        Task<IEnumerable<Item>> GetItems();
        Task<Item> GetItem(int id);
        Task<Item> PostItem(Item item);
        Task PutItem(int id, Item item);
        Task<Item> DeleteItem(int id);
    }
}
