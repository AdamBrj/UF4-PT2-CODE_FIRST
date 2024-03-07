using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace UF4_PT2_CODE_FIRST.MODEL
{
    [Table("Customers")]
    public class Customer
    {
        [Key]
        [Column(TypeName = "INT(11)")]
        public int CustomerNumber { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string CustomerName { get; set; }

        [Column(TypeName = "varchar(50)")]

        public string ContactLastName { get; set; }

        [Column(TypeName = "varchar(50)")]

        public string ContactFirstName { get; set; }

        [Column(TypeName = "varchar(50)")]

        public string Phone { get; set; }

        [Column(TypeName = "varchar(50)")]

        public string AddressLine1 { get; set; }

        [Column(TypeName = "varchar(50)")]

        public string AddressLine2 { get; set; }

        [Column(TypeName = "varchar(50)")]

        public string City { get; set; }

        [Column(TypeName = "varchar(50)")]

        public string State { get; set; }

        [Column(TypeName = "varchar(15)")]

        public string PostalCode { get; set; }

        [Column(TypeName = "varchar(50)")]

        public string Country { get; set; }

        [ForeignKey("employees")]


        [Column(TypeName = "INT(11)")]
        public int? SalesRepEmployeeNumber { get; set; }

        [Column(TypeName = "DECIMAL(10,2)")]
        public decimal? CreditLimit { get; set; }

        public  Employee SalesRep { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
