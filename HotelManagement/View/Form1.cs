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
        public Form1 (IRoomTypeBLL iRoomTypeBLL)
        {
            InitializeComponent();
            Console.WriteLine("dasda");
            _iRoomTypeBLL = iRoomTypeBLL;
            test();
        }

        public void test()
        {
            List<RoomTypeVM> listVM = _iRoomTypeBLL.getAll();
            Console.WriteLine(listVM.Count);
            Console.WriteLine("fefel");

            string json = JsonConvert.SerializeObject(listVM, Formatting.Indented);
            richTextBox1.Text = json;
            Console.WriteLine(json);
        }

    }
}
