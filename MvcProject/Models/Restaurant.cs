using System.Collections.Generic;

namespace MvcProject.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Image { get; set; }
        public int Phone { get; set; }

        public virtual List<Order> Orders { get; set; }
        public virtual List<Item> Items { get; set; }
       




    }
}
