using System.Collections.Generic;

namespace MvcProject.Models
{
    public class Category
    {
        public int  id { get; set; }
        public string name { get; set; }    
        public virtual List<Item> items { get; set; }   



    }
}
