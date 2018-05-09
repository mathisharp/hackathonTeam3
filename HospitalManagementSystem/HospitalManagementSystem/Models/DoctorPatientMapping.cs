using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.Models
{
    public class DoctorPatientMapping
    {
        /// <summary>
        /// Id
        /// </summary>

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        /// <summary>
        /// Foreign key reference to UserType Table
        /// </summary>

        [ForeignKey("PatientDetails")]
        public Guid PatientDetailsId { get; set; }


        /// <summary>
        /// Reference object for UserType
        /// </summary>
        public virtual PatientDetails PatientDetails { get; set; }

        /// <summary>
        /// Foreign key reference to DoctorDetails Table
        /// </summary>

        [ForeignKey("DoctorDetails")]
        public Guid DoctorDetailsId { get; set; }


        /// <summary>
        /// Reference object for DoctorDetails
        /// </summary>
        public virtual DoctorDetails DoctorDetails { get; set; }

        /// <summary>
        /// FromDateTime
        /// </summary>
        public DateTime FromDateTime { get; set; }

        /// <summary>
        /// ToDateTime
        /// </summary>
        public DateTime ToDateTime { get; set; }


        /// <summary>
        /// IsCancelled
        /// </summary>
        public bool IsCancelled { get; set; }

    }
}