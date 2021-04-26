using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HotelManagement.Model
{
    [Table("Invoice")]
    public partial class Invoice
    {
        [Key]
        [Column("id_invoice")]
        public int IdInvoice { get; set; }
        [Column("inv_totalbooking", TypeName = "decimal(10, 2)")]
        public decimal InvTotalbooking { get; set; }
        [Column("inv_createdate", TypeName = "date")]
        public DateTime InvCreatedate { get; set; }
        [Column("inv_updatedate", TypeName = "date")]
        public DateTime InvUpdatedate { get; set; }
        [Column("inv_idclient")]
        public int InvIdclient { get; set; }
        [Column("inv_iduser")]
        public int InvIduser { get; set; }

        [ForeignKey(nameof(InvIdclient))]
        [InverseProperty(nameof(Client.Invoices))]
        public virtual Client InvIdclientNavigation { get; set; }
        [ForeignKey(nameof(InvIduser))]
        [InverseProperty(nameof(User.Invoices))]
        public virtual User InvIduserNavigation { get; set; }
    }
}
