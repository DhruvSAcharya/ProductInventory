using MediatR;
using ProductInventory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly IDataAccess _data;
        public AddProductHandler(IDataAccess data)
        {
            _data = data;
        }
        Task<Product> IRequestHandler<AddProductCommand, Product>.Handle(AddProductCommand request, CancellationToken cancellationToken)
        {

            Product product = _data.AddProduct(request.Product);

            return Task.FromResult(product);
        }
    }

    public class DeleteProductByIdHandler : IRequestHandler<DeleteProductByIdCommand, bool>
    {
        private readonly IDataAccess _data;
        public DeleteProductByIdHandler(IDataAccess data)
        {
            _data = data;
        }

        public Task<bool> Handle(DeleteProductByIdCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_data.DeleteProductById(request.Id));
        }
    }

    public class UpdateProductByIdHandler : IRequestHandler<UpdateProductByIdCommand, Product>
    {
        private readonly IDataAccess _data;
        public UpdateProductByIdHandler(IDataAccess data)
        {
            _data = data;
        }

        public Task<Product> Handle(UpdateProductByIdCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_data.UpdateProductById(request.Product.ProductId, request.Product));
        }
    }

}
