using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HotelManagement.Model
{
    [Table("menu")]
    public partial class Menu
    {
        public Menu()
        {
            Auths = new HashSet<Auth>();
        }

        [Key]
        [Column("id_menu")]
        public int IdMenu { get; set; }
        [Column("menu_parentid")]
        public int MenuParentid { get; set; }
        [Required]
        [Column("menu_url")]
        [StringLength(100)]
        public string MenuUrl { get; set; }
        [Required]
        [Column("menu_name")]
        [StringLength(100)]
        public string MenuName { get; set; }
        [Column("menu_orderindex")]
        public int MenuOrderindex { get; set; }
        [Column("menu_activeflag")]
        public bool MenuActiveflag { get; set; }
        [Column("menu_createdate", TypeName = "date")]
        public DateTime MenuCreatedate { get; set; }
        [Column("menu_updatedate", TypeName = "date")]
        public DateTime MenuUpdatedate { get; set; }

        [InverseProperty(nameof(Auth.AuthIdmenuNavigation))]
        public virtual ICollection<Auth> Auths { get; set; }
    }
}
