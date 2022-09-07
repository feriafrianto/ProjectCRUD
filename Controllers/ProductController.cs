using System;
using System.Collections.Generic;
using TraderSys.Portfolios.Helpers;
using System.Linq;
using System.Threading.Tasks;
using TraderSys.Portfolios.Services;
using Grpc.Core;
using TraderSys.Portfolios.Models.Entities;
using AutoMapper;

namespace TraderSys.Portfolios.Controllers
{

    public class ProductController : ProductProto.ProductProtoBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService,IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public override async Task<CreateProductResponse> Create(CreateProductRequest request, ServerCallContext context)
        {
            try
            {
                // var validationResult = new CreateCargoValidator().Validate(request);
                // if (!validationResult.IsValid)
                //     return new CreateCargoResponse
                //     {
                //         Header = ResponseHeaderBuilder.Build(false, "Create Cargo failed.", 400),
                //         Errors = Utilities.GetValidationErrors(validationResult.Errors)
                //     };

                await _productService.Create(_mapper.Map<Product>(request));

                return new CreateProductResponse
                {
                    Header = ResponseHeaderBuilder.Build(true, "Successfully create the Cargo", 200),
                };
            }
            catch (System.Exception e)
            {
                return new CreateProductResponse
                {
                    Header = ResponseHeaderBuilder.Build(false, e.ToString(), 500),
                };
            }
        }
    }
}