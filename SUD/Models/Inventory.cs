﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SUD.Models
{
    [Table("tbl_Inventories")]

    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Bodega:")]
        public int CellarId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Paso")]
        public int Step { get; set; }

        public virtual Cellar Cellar { get; set; }

        public virtual ICollection<InventoryDetail> InventoryDetails { get; set; }


    }
}