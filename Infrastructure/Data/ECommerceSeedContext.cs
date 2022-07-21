using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ECommerceSeedContext
    {
        public static async Task SeedAsync(ECommerceDbContext dbContext, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!dbContext.Products.Any())
                {
                    var productsData = File
                        .ReadAllText("../Infrastructure/Data/SeedData/products.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                    foreach (var item in products)
                    {
                        dbContext.Products.Add(item);
                    }

                    await dbContext.SaveChangesAsync();
                }

                if (!dbContext.ProductBrands.Any())
                {
                    var brandsData = File
                        .ReadAllText("../Infrastructure/Data/SeedData/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                    foreach (var item in brands)
                    {
                        dbContext.ProductBrands.Add(item);
                    }

                    await dbContext.SaveChangesAsync();
                }
                
                if (!dbContext.ProductTypes.Any())
                {
                    var typesData = File
                        .ReadAllText("../Infrastructure/Data/SeedData/types.json");
                    var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                    foreach (var item in types)
                    {
                        dbContext.ProductTypes.Add(item);
                    }

                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<ECommerceDbContext>();
                logger.LogError(ex.Message);
            }
        }
    }
}
