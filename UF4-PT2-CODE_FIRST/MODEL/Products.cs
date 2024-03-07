using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UF4_PT2_CODE_FIRST.MODEL
{

    [Table("Products")]
    public class Product
    {
        [Key]
        [Column(TypeName = "varchar(15)")]
        public string ProductCode { get; set; }

        [Column(TypeName = "varchar(70)")]
        public string ProductName { get; set; }

        [ForeignKey("ProductLines")]


        [Column(TypeName = "varchar(50)")]

        public string ProductLineId { get; set; }

        [Column(TypeName = "varchar(10)")]

        public string ProductScale { get; set; }

        [Column(TypeName = "varchar(50)")]

        public string ProductVendor { get; set; }

        [Column(TypeName = "TEXT")]

        public string ProductDescription { get; set; }

        [Column(TypeName = "SMALLINT(6)")]
        public short QuantityInStock { get; set; }

        [Column(TypeName = "DECIMAL(10,2)")]
        public decimal BuyPrice { get; set; }

        [Column(TypeName = "DECIMAL(10,2)")]

        public decimal MSRP { get; set; }

        public ProductLine ProductLineNavigation { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
