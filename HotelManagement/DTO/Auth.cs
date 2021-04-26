using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HotelManagement.Model
{
    [Table("auth")]
    public partial class Auth
    {
        [Key]
        [Column("id_auth")]
        public int IdAuth { get; set; }
        [Column("auth_idrole")]
        public int AuthIdrole { get; set; }
        [Column("auth_idmenu")]
        public int AuthIdmenu { get; set; }
        [Column("auth_permission")]
        public bool AuthPermission { get; set; }
        [Column("auth_activeflag")]
        public bool AuthActiveflag { get; set; }
        [Column("auth_createdate", TypeName = "date")]
        public DateTime AuthCreatedate { get; set; }
        [Column("auth_updatedate", TypeName = "date")]
        public DateTime AuthUpdatedate { get; set; }

        [ForeignKey(nameof(AuthIdmenu))]
        [InverseProperty(nameof(Menu.Auths))]
        public virtual Menu AuthIdmenuNavigation { get; set; }
        [ForeignKey(nameof(AuthIdrole))]
        [InverseProperty(nameof(Role.Auths))]
        public virtual Role AuthIdroleNavigation { get; set; }
    }
}
