using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using HotelManagement.BLL.Interface;
using HotelManagement.ViewModel;
using Newtonsoft.Json;
using System.Windows.Forms;

namespace HotelManagement.View
{
    public partial class UserControl_Receptionist_Admin : UserControl
    {
        private IRoomTypeBLL _iRoomTypeBLL;
        private IRoomBLL _iRoomBLL;
        public UserControl_Receptionist_Admin(IRoomTypeBLL iRoomTypeBLL, IRoomBLL iRoomBLL)
        {
            InitializeComponent();
            _iRoomBLL = iRoomBLL;
            _iRoomTypeBLL = iRoomTypeBLL;
            getAllRoom();
        }
        public void getAllRoomType()
        {
            List<RoomTypeVM> listVM = _iRoomTypeBLL.getAll();
            Console.WriteLine(listVM.Count);
            Console.WriteLine("fefel");

            string json = JsonConvert.SerializeObject(listVM, Formatting.Indented);
            //richTextBox1.Text = json;
            dataGridView1.DataSource = json;
            Console.WriteLine(json);
        }

        public void getAllRoom()
        {
            List<RoomVM> listVm = _iRoomBLL.getAll(1, 2, "HELO");
            string json = JsonConvert.SerializeObject(listVm, Formatting.Indented);
            //richTextBox1.Text = json;
            dataGridView1.DataSource = json;
        }
    }
}
