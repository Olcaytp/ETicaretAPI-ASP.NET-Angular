﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryReponse
    {
        public int TotalProductCount { get; set; }
        public object Products { get; set; }
    }
}
