using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductReadRepository _productReadRepository;
        IProductWriteRepository _productWriteRepository;

        public ProductsController( IProductReadRepository productReadRepository, 
                            IProductWriteRepository productWriteRepository) 
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async Task<List<Product>> Get()
        {
            await _productWriteRepository.AddRangeAsync
                (
                    new List<Product>
                    {
                        new Product{ CreatedDate = new DateTime(), Id = Guid.NewGuid(), Name = "Product 1", Price = 100, Stock = 13,  },
                        new Product{ CreatedDate = new DateTime(), Id = Guid.NewGuid(), Name = "Product 2", Price = 200, Stock = 15,  },
                        new Product{ CreatedDate = new DateTime(), Id = Guid.NewGuid(), Name = "Product 3", Price = 300, Stock = 17,  },

                    }
                );

            await _productWriteRepository.SaveAsync();

            List<Product> products =  _productReadRepository.GetAll().ToList();
            return products;


        }

        [HttpGet("{id}")]
        public async Task<Product> GetById(string id)
        {
            var founded = await _productReadRepository.GetByIdAsync("5a09f529-0e64-4ae7-81a4-243c833c08cb");
            founded.Price = 1378;
            await _productWriteRepository.SaveAsync();
            return founded;
        }
    }
}
