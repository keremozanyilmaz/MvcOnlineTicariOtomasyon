using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class SalesMovement
    {
        [Key]
        public int SalesMovementsID { get; set; }

        public DateTime SalesMovementDate { get; set; }
        public int SalesMovementQuantity { get; set; }
        public decimal SalesMovementPrice { get; set; }
        public decimal SalesMovementTotalAmount { get; set; }

        public Product Product { get; set; }
        public Current Current { get; set; }
        public Employee Employee { get; set; }
    }
}