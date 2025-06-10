using System.Configuration;
//bununla app.configdeki bağlantı cümlesini otomatik çekeceğiz
namespace TinyHouse.Data.Utilities
{
    public static class DbHelper
    {
        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }
    }
}
