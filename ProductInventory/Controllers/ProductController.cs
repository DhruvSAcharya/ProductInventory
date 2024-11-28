using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProductInventory.Models;
using Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProductInventory.Controllers
{
    [ApiController]
    [Route("api")]
    [Authorize]
    public class ProductController : ControllerBase
    {

        private readonly ILogger<ProductController> _logger;

        private readonly IConfiguration _configuration;

        private readonly IMediator _mediatR;

        public ProductController(ILogger<ProductController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediatR = mediator;
        }


        [HttpGet]
        [Route("products")]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _mediatR.Send(new GetProductListQuery());
        }

        [HttpPost]
        [Route("products")]
        public async Task<Product> CreateProduct(Product product)
        {
            return await _mediatR.Send(new AddProductCommand(product));
        }

        [HttpGet]
        [Route("products/{id}")]
        public async Task<Product> GetProductbyId(int id)
        {
            return await _mediatR.Send(new GetProductByIdQuery(id));
        }

        [HttpPut]
        [Route("products/{id}")]
        public async Task<Product> UpdateProductInfo(int id, Product product)
        {
            return await _mediatR.Send(new UpdateProductByIdCommand(product));
        }

        [HttpDelete]
        [Route("products/{id}")]
        public async Task<IActionResult> DeleteProductById(int id)
        {
            bool isSuccess =  await _mediatR.Send(new DeleteProductByIdCommand(id));
            if (isSuccess) {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
