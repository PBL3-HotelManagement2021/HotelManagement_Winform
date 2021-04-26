using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HotelManagement.Model
{
    [Table("user_role")]
    public partial class UserRole
    {
        [Key]
        [Column("id_userol")]
        public int IdUserol { get; set; }
        [Column("userol_iduser")]
        public int UserolIduser { get; set; }
        [Column("userol_idrole")]
        public int UserolIdrole { get; set; }
        [Required]
        [Column("userol_activeflag")]
        public bool? UserolActiveflag { get; set; }

        [ForeignKey(nameof(UserolIdrole))]
        [InverseProperty(nameof(Role.UserRoles))]
        public virtual Role UserolIdroleNavigation { get; set; }
        [ForeignKey(nameof(UserolIduser))]
        [InverseProperty(nameof(User.UserRoles))]
        public virtual User UserolIduserNavigation { get; set; }
    }
}
