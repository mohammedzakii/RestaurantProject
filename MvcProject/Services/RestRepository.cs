using Microsoft.EntityFrameworkCore;
using MvcProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcProject.Services
{
    public class RestRepository : IRestRepository
    {

        RestDB obj = new RestDB();
        public Restaurant GetRest()
        {
            Restaurant restant = obj.Restaurants.FirstOrDefault();
            Restaurant rest = obj.Restaurants.Include(t => t.Items).FirstOrDefault(i => i.Id == restant.Id);
            return rest;
        }
        public int delete(int id)
        {
            Item theitem = obj.Items.FirstOrDefault(s => s.Id == id);
            obj.Items.Remove(theitem);
            int raws = obj.SaveChanges();
            return raws;
        }
        public int insert(Item item)
        {
            Restaurant restant = obj.Restaurants.FirstOrDefault();
            item.Rest_Id = restant.Id;
            item.Image = "/image/faces-clipart/Bigmac.png";
            obj.Items.Add(item);
            int raws = obj.SaveChanges();
            return (raws);
        }
        public int update(int id, Item edit)
        {
            Item olditem = obj.Items.FirstOrDefault(s => s.Id == id);
            olditem.Name = edit.Name;
            olditem.Description = edit.Description;
            olditem.Price = edit.Price;
            olditem.Image = edit.Image;
            int raws = obj.SaveChanges();

            return raws;
        }

        public List<Order> GetOrdersList()
        {
            List<Order> orders = obj.Orders.Include(i => i.ItemOrder).ThenInclude(s => s.Item).ToList();
            return orders;
        }
        public int RemoveOrder(int id)
        {
            Order ord = obj.Orders.FirstOrDefault(i => i.Id == id);
            obj.Orders.Remove(ord);
            int raws = obj.SaveChanges();
            return raws;
        }



    }
}

