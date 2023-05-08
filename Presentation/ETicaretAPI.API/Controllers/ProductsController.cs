using ETicaretAPI.Application.Abstractions.Storage;
using ETicaretAPI.Application.Features.Commands.Product.CreateProduct;
using ETicaretAPI.Application.Features.Commands.Product.RemoveProduct;
using ETicaretAPI.Application.Features.Commands.Product.UpdateProduct;
using ETicaretAPI.Application.Features.Commands.ProductImageFile.RemoveProductImage;
using ETicaretAPI.Application.Features.Commands.ProductImageFile.UploadProductImage;
using ETicaretAPI.Application.Features.Queries.Product.GetAllProduct;
using ETicaretAPI.Application.Features.Queries.Product.GetByIdProduct;
using ETicaretAPI.Application.Features.Queries.ProductImageFile.GetProductImages;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.RequestParameters;
using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        readonly IMediator _mediator;
        readonly ILogger<ProductsController> _logger;

        /* -1.0
        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;

        readonly private ICustomerWriteRepository _customerWriteRepository; */

        public ProductsController(IMediator mediator, ILogger<ProductsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductQueryRequest getAllProductQueryRequest)
        {
            _logger.LogInformation("asmdlasmdlamsd");
            GetAllProductQueryReponse response = await _mediator.Send(getAllProductQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetByIdProductQueryRequest getByIdProductQueryRequest)
        {
            GetByIdProductQueryResponse response = await _mediator.Send(getByIdProductQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommandRequest createProductCommandRequest)
        {
            CreateProductCommandResponse response = await _mediator.Send(createProductCommandRequest);
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateProductCommandRequest updateProductCommandRequest )
        {
            UpdateProductCommandResponse response = await _mediator.Send(updateProductCommandRequest);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveProductCommandRequest removeProductCommandRequest)
        {
            RemoveProductCommandResponse response = await _mediator.Send(removeProductCommandRequest);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload([FromQuery] UploadProductImageCommandRequest uploadProductImageCommandRequest )
        {
            uploadProductImageCommandRequest.Files = Request.Form.Files;
            UploadProductImageCommandResponse response = await _mediator.Send(uploadProductImageCommandRequest);
            return Ok();

            /*
            ////var datas = await _storageService.UploadAsync("files", Request.Form.Files); // Azure Blob Storage
            //var datas = await _storageService.UploadAsync("resource/files", Request.Form.Files);
            //var datas = await _fileService.UploadAsync("resource/product-images", Request.Form.Files);
            ////await _productImageFileWriteRepository.AddRangeAsync(datas.Select(d => new ProductImageFile()
            ////{
            ////    FileName = d.fileName,
            ////    Path = d.pathOrContainerName,
            ////    Storage = _storageService.StorageName
            ////}).ToList());
            ////await _productImageFileWriteRepository.SaveAsync();

            //var datas = await _fileService.UploadAsync("resource/invoices", Request.Form.Files);
            //await _invoiceFileWriteRepository.AddRangeAsync(datas.Select(d => new InvoiceFile()
            //{
            //    FileName = d.fileName,
            //    Path = d.path,
            //    Price = new Random().Next()
            //}).ToList());
            //await _invoiceFileWriteRepository.SaveAsync();

            //var datas = await _fileService.UploadAsync("resource/file", Request.Form.Files);
            //await _fileWriteRepository.AddRangeAsync(datas.Select(d => new ETicaretAPI.Domain.Entities.File()
            //{
            //    FileName = d.fileName,
            //    Path = d.path
            //}).ToList());
            //await _fileWriteRepository.SaveAsync();

            //var d1 = _fileReadRepository.GetAll(false);
            //var d2 = _productImageFileReadRepository.GetAll(false);
            //var d3 = _invoiceFileReadRepository.GetAll(false);

            ////return Ok();
            ///*/
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetProductImages([FromRoute] GetProductImagesQueryRequest getProductImagesQueryRequest)
        {
            List<GetProductImagesQueryResponse> responses = await _mediator.Send(getProductImagesQueryRequest);
            return Ok(responses);
        }

        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> DeleteProductImage([FromRoute] RemoveProductImageCommandRequest removeProductImageCommandRequest, [FromQuery] string imageId)
        {
            removeProductImageCommandRequest.ImageId = imageId;
            RemoveProductImageCommandResponse response = await _mediator.Send(removeProductImageCommandRequest);
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

