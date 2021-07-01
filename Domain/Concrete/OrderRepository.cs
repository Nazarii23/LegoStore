using Domain.Abstract;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private LegoStoreContext context = GeneralContext.context;

        public IEnumerable<OrderDetail> OrderDetails
        {
            get { return context.OrderDetails; }
        }

        public void SaveOrder(OrderDetail orderDetail)
        {
            if (orderDetail.OrderId == 0)
            {
                context.OrderDetails.Add(orderDetail);
            }
            else
            {
                OrderDetail dbOrder = context.OrderDetails.Find(orderDetail.OrderId);

                if (dbOrder != null)
                {
                    dbOrder.Name = orderDetail.Name;
                    dbOrder.OrderEmail = orderDetail.OrderEmail;
                    dbOrder.OrderAdress = orderDetail.OrderAdress;
                    dbOrder.OrderCity = orderDetail.OrderCity;
                    dbOrder.OrderCountry = orderDetail.OrderCountry;
                    dbOrder.OrderDate = orderDetail.OrderDate;
                    dbOrder.GiftWrap = orderDetail.GiftWrap;
                    //dbOrder.Products = orderDetail.Products;
                }
            }

            context.SaveChanges();
        }

        public void DeleteOrder(OrderDetail orderDetail)
        {
            if (orderDetail.OrderId != 0)
            {
                OrderDetail dbOrder = context.OrderDetails.Find(orderDetail.OrderId);

                if (dbOrder != null)
                {
                    context.OrderDetails.Remove(dbOrder);
                    context.SaveChanges();
                }
            }
        }
    }
}
