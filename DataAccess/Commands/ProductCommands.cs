using MediatR;
using ProductInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public record AddProductCommand(Product Product) : IRequest<Product>;

    public record DeleteProductByIdCommand(int Id) : IRequest<bool>;

    public record UpdateProductByIdCommand(Product Product) : IRequest<Product>;
}
