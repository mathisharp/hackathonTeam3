using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.Models
{
    /// <summary>
    /// PatientDetails
    /// </summary>

    public class PatientDetails
    {
        /// <summary>
        /// Id
        /// </summary>

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// patient Name
        /// </summary>

        [MaxLength(255)]
        public string Name { get; set; }

        /// <summary>
        /// patient age
        /// </summary>
        
        public int Age { get; set; }

        /// <summary>
        /// patient Gender
        /// </summary>

        [MaxLength(6)]
        public string Gender { get; set; }

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