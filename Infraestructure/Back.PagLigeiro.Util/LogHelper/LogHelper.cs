using Serilog;

namespace Back.PagLigeiro.Util.LogHelper
{
    public class LogHelper
    {
        public static void Information(string msg)
        {
            Log.Information("[INFOR] " + msg);
        }

        public static void Warning(string msg)
        {
            Log.Warning(msg);
        }

        public static void Error(string msg)
        {
            Log.Error(msg);
        }

        public static void Fatal(string msg)
        {
            Log.Fatal(msg);
        }
    }
}