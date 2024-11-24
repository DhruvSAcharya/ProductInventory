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

        //[HttpPost]
        //[Route("products")]
        //public Product CreateProduct(Product product)
        //{
        //    _applicationDbContext.products.Add(product);
        //    _applicationDbContext.SaveChanges();

        //    return product;
        //}

        [HttpGet]
        [Route("products/{id}")]
        public async Task<Product> GetProductbyId(int id)
        {
            return await _mediatR.Send(new GetProductByIdQuery(id));
        }

        //[HttpPut]
        //[Route("products/{id}")]
        //public Product UpdateProductInfo(int id,Product product)
        //{
        //    Product newp = _applicationDbContext.products.Find(id);
        //    newp.Price = product.Price;
        //    newp.Quantity = product.Quantity;
        //    newp.ProductName = product.ProductName;
        //    newp.Description = product.Description;
        //    _applicationDbContext.Entry(newp).State = EntityState.Modified;
        //    _applicationDbContext.SaveChanges();
        //    return _applicationDbContext.products.Find(id);
        //}

        //[HttpDelete]
        //[Route("products/{id}")]
        //public IActionResult DeleteProductById(int id)
        //{
        //    Product newp = _applicationDbContext.products.Find(id);
        //    _applicationDbContext.Remove(newp);
        //    _applicationDbContext.SaveChanges();
        //    return NoContent();
        //}

    }
}
