using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using myweb.Models;

namespace myweb.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        public List<Product> _products = new List<Product>();

        public ProductsController()
        {
            _products.Add(new Product { Id = 1, Name = "to-to", Category = "gro", Price = 1 });
            _products.Add(new Product { Id = 2, Name = "yo-yo", Category = "toy", Price = 3.75M });
            _products.Add(new Product { Id = 3, Name = "hammer", Category = "hardware", Price = 16.75M });
        }


        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _products;
        }


        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _products.FirstOrDefault((e) => e.Id == id);
        }

        [HttpPost]
        [Route("addProduct")]
        public Product Add([FromBody] Product product)
        {

            _products.Add(product);
            // product.Price = 689;
            return product;
        }

    };


};
