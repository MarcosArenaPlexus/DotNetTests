using ApiNetCore.Controllers;
using ApiNetCore.Data;
using ApiNetCore.Domain.Modules.Product.Entities;
using ApiNetCore.Domain.Modules.Product.Repositories;
using ApiNetCore.Dtos.Product;
using ApiNetCore.Repositories.Product;
using ApiNetCore.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiNetCoreTests.Tests
{
    public class ProductTests
    {
        private const string DATABASE = "DotNetTests";

        private readonly ApiNetCoreContext context;
        private readonly IProductRepository dataRepository;
        private readonly GetProductByIdService getProductByIdService;
        public ProductTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApiNetCoreContext>()
            .UseInMemoryDatabase(databaseName: DATABASE)
            .Options;

            this.context = new ApiNetCoreContext(optionsBuilder);

            this.dataRepository = new ProductRepository(this.context);

            this.getProductByIdService = new GetProductByIdService(this.dataRepository);

            this.InitData();
        }


        [SetUp]
        public void Setup() { }

        [TestCase(TestName = "Controller Should Return a Product")]
        public async Task Controller_Should_Return_a_Product()
        {
            // Arrange
            GetProductByIdController controller = new GetProductByIdController(this.getProductByIdService);

            var result = await controller.GetProduct(new Guid("4ffd76f7-44bc-467f-a4fe-3083189f3729"));

            Assert.IsNotNull(result.Value);

            Assert.That(result.Value, Is.InstanceOf<ProductDto>());
        }


        [TestCase(TestName = "Should return a product by id")]
        public async Task Product_Repository_Should_return_a_product_by_id()
        {
            Guid existingId = new Guid("4ffd76f7-44bc-467f-a4fe-3083189f3729");

            var result = await this.dataRepository.GetProductById(existingId);

            Assert.That(result, Is.Not.Null);
        }

        private void InitData()
        {
            this.context.RemoveRange(this.context.Products);

            this.context.SaveChanges();

            this.InitProducts();

            this.context.SaveChanges();
        }

        private void InitProducts()
        {
            this.context.Products.Add(new Product()
            {
                Id = new Guid("4ffd76f7-44bc-467f-a4fe-3083189f3729"),
                Description = "Product 1"
            });
        }
    }
}