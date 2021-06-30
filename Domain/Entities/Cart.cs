using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Cart
    {
        private List<Cartline> LineCollection = new List<Cartline>();

        public IEnumerable<Cartline> lines { get { return LineCollection; } }
        public void AddItem(Product product, int quantity)
        {
            Cartline line = LineCollection
                .Where(p => p.product.ProductId == product.ProductId)
                .FirstOrDefault();
            if(line == null)
            {
                LineCollection.Add(new Cartline { product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            LineCollection.RemoveAll(l => l.product.ProductId == product.ProductId);
        }

        public decimal ComputeTotalValue()
        {
            return LineCollection.Sum(e => e.product.Price * e.Quantity);
        }

        public void Clear()
        {
            LineCollection.Clear();
        }
    }

    public class Cartline
    {
        public Product product { get; set; }
        public int Quantity { get; set; }

    }
}
