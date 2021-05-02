using HotelManagement.BLL.Interface;
using HotelManagement.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagement
{
    public partial class Form1 : Form
    {
        private IRoomTypeBLL _iRoomTypeBLL;
        private IRoomBLL _iRoomBLL;
        private IUserBLL _iUserBLL;
        public Form1(IRoomTypeBLL iRoomTypeBLL, IRoomBLL iRoomBLL, IUserBLL iUserBLL)
        {
            InitializeComponent();
            _iUserBLL = iUserBLL;
            _iRoomBLL = iRoomBLL;
            _iRoomTypeBLL = iRoomTypeBLL;
            /* getAllRoom();*/
          /*  getAllUSer();*/
            UpdateRoom();
        }

        public void  UpdateRoom()
        {
            RoomVM roomVM = _iRoomBLL.getAll(1, 2, "hello")[0];
            roomVM.RoomName = "Room1";
            //edit status time
            roomVM.ListStatusTime[1].StatimTodate = Convert.ToDateTime("01/10/2021");

            //add Status time
          /*  StatusVM statusVM = new StatusVM();
            statusVM.IdStatus = 1;
            StatusTimeVM statusTimeVM = new StatusTimeVM();
            //statusTimeVM.IdStatim = 4; //gia su minh sua lai thong tin tk status_time da co trong db
            statusTimeVM.StatimFromdate = DateTime.Now;
            statusTimeVM.StatimTodate = Convert.ToDateTime("12/12/2021");
            statusTimeVM.statusVM = statusVM;
            roomVM.ListStatusTime.Add(statusTimeVM);*/

            //del sattus time
            // List<int>listdel = new List<int>();
            // listdel.Add(3);
            _iRoomBLL.editRoom(roomVM, null);
        }
        public void getAllRoomType()
        {
            List<RoomTypeVM> listVM = _iRoomTypeBLL.getAll();
            Console.WriteLine(listVM.Count);
            Console.WriteLine("fefel");

            string json = JsonConvert.SerializeObject(listVM, Formatting.Indented);
            richTextBox1.Text = json;
            Console.WriteLine(json);
        }

        public void getAllRoom()
        {
            List<RoomVM> listVm = _iRoomBLL.getAll(1, 2, "HELO");
            string json = JsonConvert.SerializeObject(listVm, Formatting.Indented);
            richTextBox1.Text = json;
        }

        public void getAllUSer()
        {
            List<UserVM> userVMlist = _iUserBLL.searchUser("","");
            string json = JsonConvert.SerializeObject(userVMlist, Formatting.Indented);
            richTextBox1.Text = json;
        }
    }
}
