using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.Models
{
    /// <summary>
    /// DoctorDetails
    /// </summary>
    public class DoctorDetails
    {
        /// <summary>
        /// doctors Id
        /// </summary>

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// doctors Description
        /// </summary>

        [MaxLength(128)]
        public string Name { get; set; }

        /// <summary>
        /// doctors email id
        /// </summary>
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [MaxLength(128)]
        public string EmailId { get; set; }

        /// <summary>
        /// Foreign key reference to Speciality Table
        /// </summary>
        
        [ForeignKey("Speciality")]
        public Guid SpecialityId { get; set; }


        /// <summary>
        /// Reference object for Speciality
        /// </summary>
        public virtual Speciality Speciality { get; set; }


    }
}