using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.Models
{
    /// <summary>
    /// UserManagement
    /// </summary>
    public class UserManagement
    {

        /// <summary>
        /// Id
        /// </summary>

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// UserName
        /// </summary>

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "User Name should be E-mail")]
        [MaxLength(128)]
        [Index(IsUnique = true)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Foreign key reference to UserType Table
        /// </summary>

        [ForeignKey("UserType")]
        public Guid UserTypeId { get; set; }


        /// <summary>
        /// Reference object for UserType
        /// </summary>
        public virtual UserType UserType { get; set; }
    }
}