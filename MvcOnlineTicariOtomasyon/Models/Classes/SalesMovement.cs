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

        public int ProductID { get; set; }
        public int CurrentID { get; set; }
        public int EmployeeID { get; set; }

        public virtual Product Product { get; set; }
        public virtual Current Current { get; set; }
        public virtual Employee Employee { get; set; }
    }
}