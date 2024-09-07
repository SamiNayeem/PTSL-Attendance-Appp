﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PTSLAttendanceManager.Models.Entity
{
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public required DateTime Date { get; set; }

        // Foreign key property for Users
        public required string UserId { get; set; }

        // Navigation property with ForeignKey attribute
        [ForeignKey(nameof(UserId))]
        public required Users Users { get; set; }

        public required DateTime CheckIn { get; set; }

        // Make CheckOut nullable to allow setting it later during check-out
        public DateTime? CheckOut { get; set; } = null;

        public bool IsActive { get; set; } = true;

        public required double Latitude { get; set; }

        public required double Longitude { get; set; }  // Corrected spelling for Longitude

        public void Deactivate()
        {
            IsActive = false;
        }
    }
}