using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
       // public enum Status { Pending ,Acepted , Declined , Prepare , OnWay , arrived }
      
        [ForeignKey("Rest")]
        public int? Rest_Id { get; set; }
        [ForeignKey("Status")]
        public int? OrderStatus_Id { get; set;}
        public virtual List<ItemOrder> ItemOrder { get; set; }

        

        public virtual Restaurant Rest { get; set; }  

        public virtual OrderStatus Status { get; set; }




    }
}
