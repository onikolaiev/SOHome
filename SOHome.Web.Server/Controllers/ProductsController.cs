using AutoMapper;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SOHome.Common.DataModels;
using SOHome.Common.Models;
using SOHome.Domain.Data;
using SOHome.Domain.Models;

namespace SOHome.Web.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> logger;
        private readonly SOHomeDbContext dbContext;
        private readonly IMapper mapper;

        public ProductsController(ILogger<ProductsController> logger, SOHomeDbContext dbContext, IMapper mapper)
        {
            this.logger = logger;
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var products = await dbContext.Products
                .Select(x => mapper.Map<ProductModel>(x))
                .ToArrayAsync();
            return Ok(products);
        }
        [HttpGet("{code}")]
        public async Task<IActionResult> GetProductAsync(int code)
        {
            var product = await dbContext.Products
                .Where(x => x.Code == code)
                .Select(product => mapper.Map<ProductModel>(product))
                .FirstOrDefaultAsync();
            return Ok(mapper.Map<ProductModel>(product));
        }
        [HttpGet("ById/{id}")]
        public async Task<IActionResult> GetProductByIdAsync(long id)
        {
            var product = await dbContext.Products
                .Where(x => x.Id == id)
                .Select(product => mapper.Map<ProductModel>(product))
                .FirstOrDefaultAsync();
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> AddProductsAsync(ProductModel productModel)
        {
            var product = mapper.Map<Product>(productModel);
            dbContext.Products.Add(product);
            await dbContext.SaveChangesAsync();
            return Ok(mapper.Map<ProductModel>(product));
        }
        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateProductAsync(ProductModel productModel, int code)
        {
            var product = await dbContext.Products
                .Where(x => x.Code == code)
                .FirstAsync();

            mapper.Map(productModel, product);

            await dbContext.SaveChangesAsync();

            return Ok(productModel);
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> UpdateProductAsync(ProductModel productModel, long id)
        {
            var product = await dbContext.Products
                .Where(x => x.Id == id)
                .FirstAsync();

            mapper.Map(productModel, product);

            await dbContext.SaveChangesAsync();

            return Ok(productModel);
        }

        [HttpDelete("ById/{id}")]
        public async Task<IActionResult> DeleteProductAsync(long id)
        {
            var product = await dbContext.Products
                .Where(x => x.Id == id)
                .FirstAsync();

            dbContext.Products.Remove(product);

            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteProductAsync(int code)
        {
            var product = await dbContext.Products
                .Where(x => x.Code == code)
                .FirstAsync();

            dbContext.Products.Remove(product);

            await dbContext.SaveChangesAsync();

            return Ok();
        }
    }
}
