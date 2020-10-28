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
using System.Net;
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
        private readonly GetAllProductsService getAllProductsService;

        private readonly Guid nonExistingId = new Guid("db2287f6-ac18-4fd6-bfd8-d8e1ed1985a6");
        private readonly Guid existingId = new Guid("db2207f6-ac18-4fd6-bfd8-d8e1ed1985a6");

        public ProductTests()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApiNetCoreContext>()
            .UseInMemoryDatabase(databaseName: DATABASE).Options;

            this.context = new ApiNetCoreContext(optionsBuilder);

            this.dataRepository = new ProductRepository(this.context);

            this.getProductByIdService = new GetProductByIdService(this.dataRepository);

            this.getAllProductsService = new GetAllProductsService(this.dataRepository);

            this.InitData();
        }

        [SetUp]
        public void Setup() { }

        [TestCase(TestName = "Controller Should Return a Product ")]
        public async Task Controller_Should_Return_a_Product()
        {
            GetProductByIdController controller = new GetProductByIdController(this.getProductByIdService);
           
            var result = await controller.GetProduct(existingId);

            Assert.IsNotNull(result.Value);

            Assert.That(result.Value, Is.InstanceOf<ProductDto>());

            Assert.AreEqual(result.Value.ProductId, existingId);
        }
        
        [TestCase(TestName = "Controller Should Return NULL given a non existing ProductId")]
        public async Task Controller_Should_Return_NULL_Given_a_Non_Existing_ProductId()
        {
            GetProductByIdController controller = new GetProductByIdController(this.getProductByIdService);
           
            var result = await controller.GetProduct(nonExistingId);

            Assert.IsNull(result.Value);

        }

        [TestCase(TestName = "Repository Should return a product by id")]
        public async Task Product_Repository_Should_return_a_product_by_id()
        {
            var result = await this.dataRepository.GetProductById(existingId);

            Assert.That(result, Is.Not.Null);

            Assert.AreEqual(result.Id, existingId);
        } 
        
        [TestCase(TestName = "Repository Should return NULL given a non existing ProductId")]
        public async Task Product_Repository_Should_return_NULL_given_a_non_existing_ProductId()
        {
            var result = await this.dataRepository.GetProductById(nonExistingId);

            Assert.IsNull(result);
        }
        
        [TestCase(TestName = "Repository Should return ALL products")]
        public async Task Product_Repository_Should_Return_ALL_Products()
        {
            var result = await this.dataRepository.GetAllProducts();

            Assert.IsNotEmpty(result);
        }

        [TestCase(TestName = "Controller Should Return All Products ")]
        public async Task Controller_Should_Return_All_Product()
        {
            GetAllProductsController controller = new GetAllProductsController(this.getAllProductsService);

            var result = await controller.GetAllProducts();

            Assert.IsNotNull(result.Value);

            Assert.IsNotEmpty(result.Value);
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
            
            this.context.Products.Add(new Product()
            {
                Id = new Guid("db2207f6-ac18-4fd6-bfd8-d8e1ed1985a6"),
                Description = "Product 2"
            }); 
            
            this.context.Products.Add(new Product()
            {
                Id = new Guid("5d0d3fe1-2367-419f-9fc4-1d981f855e97"),
                Description = "Product 3"
            });
            
            this.context.Products.Add(new Product()
            {
                Id = new Guid("b0e178ff-b104-4fac-9f4a-cf13dc56d2bc"),
                Description = "Product 4"
            });  
            
            this.context.Products.Add(new Product()
            {
                Id = new Guid("a5f270dd-b435-4684-8dd8-f3224a7cf417"),
                Description = "Product 5"
            });
        }
    }
}