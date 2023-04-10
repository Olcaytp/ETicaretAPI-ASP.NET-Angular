using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository  _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            //await _productWriteRepository.AddRangeAsync(new()
            //{
            //    new() { Id = Guid.NewGuid(), Name = "Product 1", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10  },
            //    new() { Id = Guid.NewGuid(), Name = "Product 2", Price = 300, CreatedDate = DateTime.UtcNow, Stock = 10  },
            //    new() { Id = Guid.NewGuid(), Name = "Product 3", Price = 500, CreatedDate = DateTime.UtcNow, Stock = 10  },
            //});
            //var count = await _productWriteRepository.SaveAsync();
            Product p = await _productReadRepository.GetbyIdAsync("ef68ebf3-5682-4467-afb9-eef0f4106ad5");
            p.Name = "Ahmet";
            await _productWriteRepository.SaveAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product = await _productReadRepository.GetbyIdAsync(id);
            return Ok(product);
        }
    }
}
