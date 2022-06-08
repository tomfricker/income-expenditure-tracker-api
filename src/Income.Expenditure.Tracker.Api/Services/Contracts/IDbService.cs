using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Income.Expenditure.Tracker.Api.Models;

namespace Income.Expenditure.Tracker.Api.Services.Contracts
{
    public interface IDbService
    {
        Task<IEnumerable<Item>> GetItemsAsync();
        Task<Item> GetItemAsync(string id);
        Task AddItemAsync(Item item);
        Task UpdateItemAsync(string id, Item item);
        Task DeleteItemAsync(string id);
    }
}
