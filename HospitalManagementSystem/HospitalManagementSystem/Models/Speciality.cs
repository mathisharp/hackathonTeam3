using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.Models
{
    /// <summary>
    /// Speciality
    /// </summary>
    public class Speciality
    {
        /// <summary>
        /// Speciality Id
        /// </summary>

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Speciality Description
        /// </summary>

        [MaxLength(255)]
        public string Description { get; set; }

    }
}