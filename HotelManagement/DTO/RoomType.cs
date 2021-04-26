using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HotelManagement.Model
{
    [Table("room_type")]
    public partial class RoomType
    {
        public RoomType()
        {
            ImgStorages = new HashSet<ImgStorage>();
            Rooms = new HashSet<Room>();
        }

        [Key]
        [Column("id_roomtype")]
        public int IdRoomtype { get; set; }
        [Required]
        [Column("roty_name")]
        [StringLength(100)]
        public string RotyName { get; set; }
        [Column("roty_description")]
        [StringLength(250)]
        public string RotyDescription { get; set; }
        [Column("roty_currentprice", TypeName = "decimal(10, 2)")]
        public decimal RotyCurrentprice { get; set; }
        [Column("roty_capacity")]
        public int RotyCapacity { get; set; }

        [InverseProperty(nameof(ImgStorage.ImgstoIdrootypNavigation))]
        public virtual ICollection<ImgStorage> ImgStorages { get; set; }
        [InverseProperty(nameof(Room.RoomIdroomtypeNavigation))]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
