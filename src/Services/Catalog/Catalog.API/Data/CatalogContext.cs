using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products { get; }

        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase("DatabaseSettings:DatabaseName");
            Products = database.GetCollection<Product>("DatabaseSettings:CollectionName");
            CatalogContextSeed.Seed(Products);
        }
    }
}
