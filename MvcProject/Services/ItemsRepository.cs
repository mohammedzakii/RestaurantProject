using Microsoft.EntityFrameworkCore;
using MvcProject.Models;

using System.Collections.Generic;
using System.Linq;

namespace MvcProject.Services
{
    public class ItemsRepository : IItemsRepository
    {
        RestDB db = new RestDB();

        public int delete(int id)
        {
            Item theitem = db.Items.FirstOrDefault(s => s.Id == id);

            db.Remove(theitem);
            int raws = db.SaveChanges();
            return raws;
        }

        public List<Item> getAll()
        {
            List<Item> items = db.Items.ToList();
            return items;
        }

        public Item getByID(int id)
        {
            Item it = db.Items.Include(s=>s.Category).FirstOrDefault(s=>s.Id == id);
            return it;
        }

        public int insert(Item item)
        {
            db.Items.Add(item);
            int raws = db.SaveChanges();
            return (raws);
        }

        public int update(int id, Item edit)
        {
            Item olditem = db.Items.FirstOrDefault(s => s.Id == id);
            olditem.Name = edit.Name;
            olditem.Description = edit.Description;
            olditem.Price = edit.Price;
            olditem.Image = edit.Image;
            int raws = db.SaveChanges();

            return raws;

        }
        public List<Item> Itemgetallcard(int catid)

        {
            List<Item> itemModel = db.Items.Where(d => d.cat_id == catid).Include(d => d.Category).ToList();
            return itemModel;

        }
    }
}
