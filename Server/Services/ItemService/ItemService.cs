using hSenidPos.Server.Data;
using hSenidPos.Server.Services.UserService;
using hSenidPos.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hSenidPos.Server.Services.ItemService
{
    public class ItemService : IItemService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;

        public ItemService(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<Item> DeleteItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<Item> GetItem(int id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            return await _context.Items.OrderBy(m => m.ItemName).ToListAsync();
        }

        public async Task<Item> PostItem(Item item)
        {
            item.CreatedBy = _userService.GetUserId();
            item.CreatedDate = DateTime.UtcNow;
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task PutItem(int id, Item item)
        {
            item.UpdatedBy = _userService.GetUserId();
            item.UpdatedDate = DateTime.UtcNow;
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public bool ItemExists(int id)
        {
            return _context.Items.Any(i => i.ItemId == id);
        }
    }
}
