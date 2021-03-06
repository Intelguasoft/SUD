﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SUD.Models
{
    [Table("tbl_Measures")]

    public class Measure
    {
        [Key]
        public int MeasureId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Unidad de Medida")]
        public string Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }


    }
}