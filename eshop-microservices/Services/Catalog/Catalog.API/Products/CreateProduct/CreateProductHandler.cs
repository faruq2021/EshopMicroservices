using MediatR;
using BuildingBlocks.CQRS;
using Catalog.API.Models;

namespace Catalog.API.Products;

    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price )
        :ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler 
        : ICommandHandler <CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
        {
            // Business logic to create
            // 1 create product entity from command object
            // 2 save to database
            // 3 return CreateProductResult  object

            var product = new Product
            {
                Name = command.Name,
                Category = command.Category,
                Description = command.Description,
                ImageFile = command.ImageFile,
                Price = command.Price
            };

            //save to database  TODO

            // return a result 

            return new CreateProductResult(Guid.NewGuid());

        }
    }

 