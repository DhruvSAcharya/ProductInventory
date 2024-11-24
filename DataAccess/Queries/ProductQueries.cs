using MediatR;
using ProductInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public record GetProductListQuery() : IRequest<IEnumerable<Product>>;
    public record GetProductByIdQuery(int Id) : IRequest<Product>;

}
