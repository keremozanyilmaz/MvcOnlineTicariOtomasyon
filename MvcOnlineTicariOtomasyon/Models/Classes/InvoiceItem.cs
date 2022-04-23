using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class InvoiceItem
    {
        [Key]
        public int InvoiceItemsID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string InvoiceItemsExplanation { get; set; }
        public int InvoiceItemsQuantity { get; set; }
        public decimal InvoiceItemsUnitPrice { get; set; }
        public decimal InvoiceItemsAmount{ get; set; }

        public int InvoiceID { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}