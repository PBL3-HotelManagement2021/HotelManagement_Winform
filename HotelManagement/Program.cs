using HotelManagement.BBL.Implement;
using HotelManagement.BBL.Interface;
using HotelManagement.BLL.Implement;
using HotelManagement.BLL.Interface;
using HotelManagement.DAL.Impl;
using HotelManagement.DAL.Implement;
using HotelManagement.DAL.Interface;
using HotelManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace HotelManagement
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
     

            var host = Host.CreateDefaultBuilder()
                            .ConfigureAppConfiguration((context, builder) =>
                            {
                                // Add other configuration files...
                                builder.AddJsonFile("appsetting.json", optional: true);
                            })
                            .ConfigureServices((context, services) =>
                            {
                                ConfigureServices(context.Configuration, services);
                            })
                           /* .ConfigureLogging(logging =>
                            {
                                // Add other loggers...
                            })*/
                            .Build();

            var services = host.Services;
            var mainForm = services.GetRequiredService<Form1>();
            Application.Run(mainForm);
        }

        private static void ConfigureServices(IConfiguration configuration, IServiceCollection services)
        {
    /*        services.Configure<AppSettings>(configuration.GetSection(nameof(AppSettings)));*/
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
                 /* configuration.GetConnectionString("DefaultConnection")*/
                 ConfigurationManager.ConnectionStrings["HotelManagementDB"].ConnectionString
          ));
            services.AddTransient<IUserDAL, UserDAL>();
            services.AddTransient<IUserBLL, UserBLL>();
            services.AddTransient<IRoomtypeDAL, RoomtypeDAL>();
            services.AddTransient<IRoomTypeBLL, RoomTypeBLL>();
            services.AddTransient<IImgStorageDAL,ImgStorageDAL>();
            services.AddTransient<IRoomBLL, RoomBLL>();
            services.AddTransient<IRoomDAL, RoomDAL>();
            services.AddTransient<IStatusTImeDAL, StatusTimeDAL>();
            services.AddTransient<IStatusBLL, StatusBLL>();            
      
            

            services.AddAutoMapper(typeof(Program));
       

            services.AddSingleton<Form1>();
            services.AddTransient<Form2>();
        }

      

    }
}
