﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SUD.Models
{
    [Table("tbl_Products")]

    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Categoria")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Unidad de Medida")]
        public int MeasureId { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Producto")]
        public string Description { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Precio")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Nota")]
        public string Note { get; set; }

        [Display(Name = "Imagen")]
        public string Image { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        [Display(Name = "Medida")]
        public string Medida { get; set; }

        [NotMapped]
        public HttpPostedFileBase FotografiaFile { get; set; }

        public virtual ICollection<CellarProduct> CellarProducts { get; set; }

        public virtual ICollection<BarCode> BarCodes { get; set; }

        public virtual ICollection<ClientRefundDetail> ClientRefundDetails { get; set; }

        public virtual ICollection<SaleDetail> SaleDetails { get; set; }

        public virtual ICollection<PurchaseDetail> PurchaseDetails { get; set; }

        public virtual ICollection<PurchaseDetailBk> PurchaseDetailBkps { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual Category Category { get; set; }

        public virtual Measure Measure { get; set; }




    }
}