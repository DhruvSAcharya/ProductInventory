using MediatR;
using ProductInventory.Models;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class GetProductListHandler : IRequestHandler<GetProductListQuery, List<Product>>
    {
        private readonly IDataAccess _data;
        public GetProductListHandler(IDataAccess data)
        {
            _data = data;
        }
        public Task<List<Product>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_data.GetAllProducts().ToList());
        }
    }

    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IDataAccess _data;
        public GetProductByIdHandler(IDataAccess data)
        {
            _data = data;
        }

        Task<Product> IRequestHandler<GetProductByIdQuery, Product>.Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_data.GetProductbyId(request.Id));
        }
    }
}
