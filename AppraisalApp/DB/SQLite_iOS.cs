using System;
using System.IO;
using SQLite.Net;

namespace ExtAppraisalApp.DB
{
    public class SQLite_iOS
    {
        public static SQLiteConnection GetConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);// Documents Folder
            var libraryPath = Path.Combine(documentsPath, DBConstant.SEPARATOR, DBConstant.LIBRARY);// Library Folder
            var path = Path.Combine(libraryPath, DBConstant.DB_NAME);

            Console.WriteLine("The Database path is : {0}", path);

            if (!File.Exists(path))
            {
                File.Create(path);
            }

            var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLite.Net.SQLiteConnection(platform, path);

            return connection;
        }
    }
}
