using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UF4_PT2_CODE_FIRST.MODEL
{

    [Table("Orderdetails")]
    public class OrderDetail
    {
        [Key]
        [Column(TypeName = "INT(11)")]

        public int OrderNumber { get; set; }

        [Column(TypeName = "varchar(15)")]

        [Key]
        [ForeignKey("products")]

        public string ProductCode { get; set; }

        [Column(TypeName = "INT(11)")]

        public int QuantityOrdered { get; set; }

        [Column(TypeName = "DECIMAL(10,2)")]
        public decimal PriceEach { get; set; }

        [Column(TypeName = "SMALLINT(6)")]
        public short OrderLineNumber { get; set; }

        public Orders Order { get; set; }
        public Product Product { get; set; }
    }

}
