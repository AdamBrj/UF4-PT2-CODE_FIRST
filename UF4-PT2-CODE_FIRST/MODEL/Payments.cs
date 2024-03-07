using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UF4_PT2_CODE_FIRST.MODEL
{
    [Table("Payments")]
    public class Payment
    {
        [Key]
        [Column(TypeName = "INT(11)")]

        public int CustomerNumber { get; set; }

        [Key]

        [Column(TypeName = "varchar(50)")]
        public string CheckNumber { get; set; }

        [Column(TypeName = "DATE")]

        public DateTime PaymentDate { get; set; }

        [Column(TypeName = "DECIMAL(10,2)")]
        public decimal Amount { get; set; }

        public Customer Customer { get; set; }
    }
}
