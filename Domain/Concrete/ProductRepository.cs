using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private LegoStoreContext context = GeneralContext.context;
        public IEnumerable<Product> Products
        {
            get { return context.Products; }
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductId == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product dbProduct = context.Products.Find(product.ProductId);

                if (dbProduct != null)
                {
                    dbProduct.Name = product.Name;
                    dbProduct.Interest = product.Interest;
                    dbProduct.Price = product.Price;
                    dbProduct.Age = product.Age;
                }
            }
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            if (product.ProductId != 0)
            {
                Product dbProduct = context.Products.Find(product.ProductId);

                if (dbProduct != null)
                {
                    context.Products.Remove(dbProduct);
                    context.SaveChanges();
                }
            }
        }
    }
}
