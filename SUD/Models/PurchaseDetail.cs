﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SUD.Models
{
    [Table("tbl_PurchaseDetails")]
    public class PurchaseDetail
    {
        [Key]
        public long PurchaseDetailsId { get; set; }

        [Required]
        [Display(Name = "Compra")]
        public long PurchaseId { get; set; }

        [Required]
        [Display(Name = "Producto")]
        public long ProductId { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Range(1, double.MaxValue, ErrorMessage = "Debe ingresar en el campo {0} un valor entre {1} y {2}")]
        public decimal Cost { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [Range(1, double.MaxValue, ErrorMessage = "Debe ingresar en el campo {0} un valor entre {1} y {2}")]
        public double Quantity { get; set; }

        [Display(Name = "Lote")]
        public string ManufacturingLot { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Fecha de fabricación")]
        public DateTime DueDate { get; set; }

        public virtual Product Product { get; set; }

        public virtual Purchase Purchase { get; set; }

        public virtual Kardex Kardex { get; set; }

    }
}