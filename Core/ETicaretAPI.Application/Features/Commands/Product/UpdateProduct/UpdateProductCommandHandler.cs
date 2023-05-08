using ETicaretAPI.Application.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.Product.UpdateProduct
{
    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest, UpdateProductCommandResponse>
    {
        readonly IProductReadRepository _productReadRepository;
        readonly IProductWriteRepository _productWriteRepository;
        readonly ILogger<UpdateProductCommandHandler> _logger;

        public UpdateProductCommandHandler(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository, ILogger<UpdateProductCommandHandler> logger)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
            _logger = logger;
        }

        public async Task<UpdateProductCommandResponse> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product product = await _productReadRepository.GetbyIdAsync(request.Id);
            product.Stock = request.Stock;
            product.Price = request.Price;
            product.Name = request.Name;
            await _productWriteRepository.SaveAsync();
            _logger.LogInformation("Product updated.");
            return new();
        }
    }
}
