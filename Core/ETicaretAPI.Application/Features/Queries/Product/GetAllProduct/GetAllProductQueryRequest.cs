using ETicaretAPI.Application.RequestParameters;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Product.GetAllProduct
{
    public abstract class PageableQueryRequest
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
    public class GetAllProductQueryRequest : PageableQueryRequest, IRequest<GetAllProductQueryReponse>
    {
        public Pagination? Pagination { get; set; }
    }
}
