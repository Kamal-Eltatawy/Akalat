using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aklat.Models
{
    public class Order
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Order Count Cant Be Empity")]
        public int Count { get; set; }

        [Required(ErrorMessage ="OrderDate Cant Be Empity")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Order Price Cant Be Empity ")]
        [DataType("Money")]
        public decimal TotalPrice { get; set; }
        public string? OrderNote { get; set; }
        public bool IsDeleted { get; set; } = false;
        [ForeignKey("User")]
        public string UserID { get; set; }
        public User? User { get; set; }
        
       public  List<OrderProduct>? OrderProducts { get; set; }


    }
}
