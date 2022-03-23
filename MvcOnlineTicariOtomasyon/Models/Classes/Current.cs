using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Classes
{
    public class Current
    {
        [Key]
        public int CurrentID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30,ErrorMessage ="En fazla 30 karakter yazabilirsiniz.")]
        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        public string CurrentName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        [Required(ErrorMessage ="Boş Bırakılamaz!")]
        public string CurrentSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        public string CurrentCity { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Boş Bırakılamaz!")]
        public string CurrentMail { get; set; }

        public bool Status { get; set; }

        public ICollection<SalesMovement> SalesMovements { get; set; }
    }
}