﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SUD.Models
{
    [Table("tbl_UsersSud")]

    //se le colocó el Nombre de UserSud debido que al crear el controlador con el Nombre User, no se generaba la entidad en el IdentityModel
    public class UserSud
    {
        [Key]
        public int UserSudId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre:")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Apellido:")]
        public string LastName { get; set; }




        public string UserSudFullName
        {
            get
            {
                return string.Format("{0} {1}", this.Name, this.LastName);
            }
        }



        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(255, ErrorMessage = "Debe contener entre 8 caracteres", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña:")]
        public string Password { get; set; }

        [Display(Name = "Fecha de Modificación:")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ModificationDatePassword { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Rol:")]
        public int RolId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Ruta:")]
        public int RouteId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(255, ErrorMessage = "Debe contener entre 8 y 25 caracteres", MinimumLength = 8)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-.]+$", ErrorMessage = "Debe ser un correo electronico valido")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo Electrónico")]
        [Index("UserSud_Email_Index", IsUnique = true)]
        public string Email { get; set; }

        [Display(Name = "Activo")]
        public Boolean Status { get; set; }

        [Display(Name = "Imagen")]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase FotografiaFile { get; set; }




        public virtual Rol Rol { get; set; }
        public virtual Route Route { get; set; }

    }

}