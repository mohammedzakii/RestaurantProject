using MvcProject.Models;
using System.Collections.Generic;
namespace MvcProject.Services
{
    public interface IRestRepository
    {
        Restaurant GetRest();
        int insert(Item item);
        int update(int id, Item edit);
        int delete(int id);
        List<Order> GetOrdersList();
        int RemoveOrder(int id);
    }
}
