using MvcProject.Models;
using System.Collections.Generic;

namespace MvcProject.Services
{
    public interface IItemsRepository
    {
        List<Item> getAll();
        Item getByID(int id);
        int insert(Item item);
        int update(int id, Item edit);
        int delete(int id);

        List<Item> Itemgetallcard(int catid);
    }
}

