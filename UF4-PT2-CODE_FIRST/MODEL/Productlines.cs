using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UF4_PT2_CODE_FIRST.MODEL
{
    [Table("Productlines")]
    public class ProductLine
    {
        [Key]

        [Column(TypeName = "varchar(50)")]
        public string ProductLines { get; set; }

        [Column(TypeName = "varchar(4000)")]
        public string TextDescription { get; set; }

        [Column(TypeName = "MEDIUMTEXT")]

        public string HtmlDescription { get; set; }

        [Column(TypeName = "MEDIUMBLOB")]

        public byte[] Image { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
