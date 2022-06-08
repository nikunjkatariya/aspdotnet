using AzureCosmosdbWebAPI.Models;
using AzureCosmosdbWebAPI.Services;
using Microsoft.Azure.Cosmos;
using System;
using System.Linq;
using System.Collections;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AzureCosmosdbWebAPI.Services
{
    public interface ICosmosDbService
    {
        Task<IEnumerable<Item>> GetMultipleAsync(string query);
        Task<Item> GetAsync(string id);
        Task AddAsync(Item item);
        Task UpdateAsync(string id,Item item);
        Task DeleteAsync(string id);
    }
}
