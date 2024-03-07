using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UF4_PT2_CODE_FIRST.MODEL
{
    [Table("Orders")]
    public class Orders
    {
        [Key]
        [Column(TypeName = "INT(11)")]
        public int OrderNumber { get; set; }

        [Column(TypeName = "DATE")]

        public DateTime OrderDate { get; set; }

        [Column(TypeName = "DATE")]


        public DateTime RequiredDate { get; set; }

        [Column(TypeName = "DATE")]


        public DateTime? ShippedDate { get; set; }

        [Column(TypeName = "varchar(15)")]
        public string Status { get; set; }

        [Column(TypeName = "TEXT")]

        public string Comments { get; set; }

        [ForeignKey("Customers")]


        [Column(TypeName = "INT(11)")]
        public int? CustomerNumberId { get; set; }
        public Customer Customer { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }

}
