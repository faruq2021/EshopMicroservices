﻿

namespace Catalog.API.Products;

    public record CreateProductCommand(string Name, List<string> Category, string Description, string ImageFile, decimal Price )
        :ICommand<CreateProductResult>;

    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler(IDocumentSession session)
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
            session.Store( product );
            await session.SaveChangesAsync(cancellationToken);

            // return a result 

            return new CreateProductResult(product.Id);

        }
    }

 