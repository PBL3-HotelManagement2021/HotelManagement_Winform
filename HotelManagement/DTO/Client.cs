using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HotelManagement.Model
{
    [Table("client")]
    public partial class Client
    {
        public Client()
        {
            Bookings = new HashSet<Booking>();
            Invoices = new HashSet<Invoice>();
        }

        [Key]
        [Column("id_client")]
        public int IdClient { get; set; }
        [Required]
        [Column("cl_name")]
        [StringLength(100)]
        public string ClName { get; set; }
        [Required]
        [Column("cl_gmail")]
        [StringLength(100)]
        public string ClGmail { get; set; }
        [Column("cli_idclityp")]
        public int CliIdclityp { get; set; }

        [InverseProperty(nameof(Booking.BookIdclientNavigation))]
        public virtual ICollection<Booking> Bookings { get; set; }
        [InverseProperty(nameof(Invoice.InvIdclientNavigation))]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
