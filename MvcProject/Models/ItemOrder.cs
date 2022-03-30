using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcProject.Models
{
    public class ItemOrder
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Order")]
        

        public int Order_Id { get; set; }
        [Key, Column(Order = 1)]
        [ForeignKey("Item")]

        public int? Item_Id { get; set; }


        public virtual Order Order { get; set; }

        public virtual Item Item { get; set; }
    }
}
