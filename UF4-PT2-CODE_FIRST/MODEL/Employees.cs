using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UF4_PT2_CODE_FIRST.MODEL
{
    [Table("Employees")]
    public class Employee
    {
        [Key]

        [Column(TypeName = "INT(11)")]
        public int EmployeeNumber { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }

        [Column(TypeName = "varchar(50)")]

        public string FirstName { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string Extension { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(10)")]
        public string OfficeCode { get; set; }

        [ForeignKey("employees")]


        [Column(TypeName = "INT(11)")]
        public int? ReportsTo { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string JobTitle { get; set; }

        public Office Office { get; set; }
        public Employee Manager { get; set; }
        public ICollection<Employee> Reports { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
