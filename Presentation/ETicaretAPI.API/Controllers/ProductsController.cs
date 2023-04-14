using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.RequestParameters;
using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository  _productReadRepository;
        /* -1.0
        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;

        readonly private ICustomerWriteRepository _customerWriteRepository; */

        public ProductsController(
            IProductWriteRepository productWriteRepository, 
            IProductReadRepository productReadRepository
            /* -1.0
            IOrderWriteRepository orderWriteRepository,
            ICustomerWriteRepository customerWriteRepository,
            IOrderReadRepository orderReadRepository */
            )
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            /* -1.0
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
            _customerWriteRepository = customerWriteRepository; */

        }
        [HttpGet]

        public async Task<IActionResult> Get([FromQuery]Pagination pagination)
        {
           var totalCount = _productReadRepository.GetAll(false).Count();
           var products = _productReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(p => new
            {
                p.Id,
                p.Name,
                p.Price,
                p.Stock,
                p.CreatedDate,
                p.UpdatedDate
            }).ToList();
            //take-skip yapısı ile sayfalama yapılabilir. 3.sayfada 5 eleman varsa 15. elemandan başlayıp 5 eleman getirir.
            return Ok(new
            {
                totalCount,
                products
            });
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productReadRepository.GetbyIdAsync(id, false));
        }

        [HttpPost]

        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Price= model.Price,
                Stock = model.Stock,
            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]

        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetbyIdAsync(model.Id);
            product.Stock = model.Stock;
            product.Price = model.Price;
            product.Name = model.Name;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }
        /* -1.0
        //public async Task Get()
        //{
            //var customerId = Guid.NewGuid();
            //await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Gençay" });

            //await _orderWriteRepository.AddAsync(new() { Description = "bla bla bla", Address = "Ankara, Çankaya", CustomerId = customerId });
            //await _orderWriteRepository.AddAsync(new() { Description = "bla bla bla 2", Address = "Ankara, Keçiören", CustomerId = customerId });
            //await _orderWriteRepository.SaveAsync();
        //    Order order = await _orderReadRepository.GetbyIdAsync("2dbc5caf-3894-40e5-ad91-02e04153a7f4");
        //    order.Address = "IStanbul";
        //    await _orderWriteRepository.SaveAsync();
        //}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(string id)
        //{
        //    Product product = await _productReadRepository.GetbyIdAsync(id);
        //    return Ok(product);
        //}
        */
    

    }
}

