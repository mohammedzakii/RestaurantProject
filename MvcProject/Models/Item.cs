using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        public decimal Price { get; set; }
        [ForeignKey("Rest")]
        public int? Rest_Id { get; set; }
        [ForeignKey("Category")]
        public int? cat_id { get; set; } 

        public virtual Category Category { get; set; }  
        public virtual List<ItemOrder> ItemOrder { get; set; }

        public virtual Restaurant Rest { get; set; }




    }
}
