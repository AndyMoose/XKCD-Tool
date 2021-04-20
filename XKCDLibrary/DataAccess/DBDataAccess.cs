using Microsoft.Data.Sqlite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XKCDLibrary.Handlers;
using XKCDLibrary.Models;

namespace XKCDLibrary.DataAccess
{
    public class DBDataAccess : IDBDataAccess
    {
        //Used for quick searches on existing saved comics without making DB calls
        public List<int> SavedComicList { get; set; }

        public List<int> UnsavedComicList { get; set; }

        private const int COMMAND_TIMEOUT = 10;

        public DBDataAccess()
        {
            SavedComicList = new List<int>();
            Initialize(this);
        }

        private async static void Initialize(DBDataAccess db)
        {
            await db.GenerateSavedComicList();
            await db.GenerateUnsavedComicList();
        }

        public async Task<ComicModel> Insert(ComicModel xkcd)
        {
            try
            {
                //Set up database connection
                using var sqlite = new SqliteConnection();
                sqlite.ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                sqlite.Open();

                //Set up database command
                using var command = sqlite.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "INSERT INTO Comics VALUES(";

                //Create list of properties and add these to database command
                var last = xkcd.GetType().GetProperties().Last();
                foreach (var property in xkcd.GetType().GetProperties())
                {
                    string propertyText = property.GetValue(xkcd).ToString();
                    string parameter = "@" + property.Name;

                    command.CommandText += parameter;
                    command.Parameters.AddWithValue(parameter, propertyText);

                    if (property != last)
                    {
                        command.CommandText += ",";
                    }
                }
                command.CommandText += ")";

                //Execute database command
                command.CommandTimeout = COMMAND_TIMEOUT;
                await command.ExecuteNonQueryAsync();

                //Add value to num list
                SavedComicList.Add(xkcd.Num);
                UnsavedComicList.Remove(xkcd.Num);

                //Return comic which was inserted
                return xkcd;
            }
            catch
            {
                MessageBox.Show("Unable to connect to or make changes to database.  " +
                    "Please make sure the database file exists (XKCDStorage.db) " +
                    "and ensure that the file is not open in another program.");

                return xkcd;
            };
        }

        public async Task<ComicModel> Delete(ComicModel xkcd)
        {
            try
            {
                //Set up database connection
                using var sqlite = new SqliteConnection();
                sqlite.ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                sqlite.Open();

                //Set up database command for deleting comic from DB by 'Num' value
                using var command = sqlite.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "DELETE FROM Comics WHERE Num = @Num";

                //Create "Num" parameter and set value to comic 'Num'
                var param = new SqliteParameter("@Num", SqliteType.Integer)
                {
                    Value = xkcd.Num
                };
                command.Parameters.Add(param);

                //Execute command
                command.CommandTimeout = COMMAND_TIMEOUT;
                await command.ExecuteNonQueryAsync();

                //Remove num from num list
                SavedComicList.Remove(xkcd.Num);
                UnsavedComicList.Add(xkcd.Num);

                //Return deleted comic
                return xkcd;
            }
            catch
            {
                MessageBox.Show("Unable to connect to or make changes to database.  " +
                    "Please make sure the database file exists (XKCDStorage.db) " +
                    "and ensure that the file is not open in another program.");
                return xkcd;
            }
        }

        private Task GenerateSavedComicList()
        {
            try
            {
                //Create SQL connection
                using var sqlite = new SqliteConnection();
                sqlite.ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                sqlite.Open();

                //Create SQL Command for selecting all 'Num' values from comics and execute command
                using var command = sqlite.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT Num FROM Comics";
                command.CommandTimeout = COMMAND_TIMEOUT;
                SqliteDataReader reader = command.ExecuteReader();

                //Read each num value into Num list
                while (reader.Read())
                {
                    SavedComicList.Add(Convert.ToInt32(reader.GetInt32(reader.GetOrdinal("Num"))));
                }
            }
            catch
            {
                MessageBox.Show("Unable to connect to or make changes to database.  " +
                    "Please make sure the database file exists (XKCDStorage.db) " +
                    "and ensure that the file is not open in another program.");
            }
            return Task.CompletedTask;
        }
        private Task GenerateUnsavedComicList()
        {

            var mostRecentComic = APIDataAccess.XKCD_MOST_RECENT_COMIC_NUMBER;

            UnsavedComicList = new List<int>();
            for (int i = 1; i <= mostRecentComic; i++)
            {
                if (!SavedComicList.Contains(i))
                {
                    UnsavedComicList.Add(i);
                }
            }

            return Task.CompletedTask;
        }

        public Task<List<ComicModel>> GetListofSavedComics()
        {
            var comicList = new List<ComicModel>();

            try
            {
                //Create SQL connection
                using var sqlite = new SqliteConnection();
                sqlite.ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                sqlite.Open();

                //Create and execute SQL command
                using var command = sqlite.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT * FROM Comics";
                command.CommandTimeout = COMMAND_TIMEOUT;
                SqliteDataReader reader = command.ExecuteReader();

                //Read comics stored in DB into a list of ComicModels
                while (reader.Read())
                {
                    var comic = new ComicModel();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        int index = 0;
                        comic.Month = reader.GetInt32(index++);
                        comic.Num = reader.GetInt32(index++);
                        comic.Link = reader.GetString(index++);
                        comic.Year = reader.GetInt32(index++);
                        comic.News = reader.GetString(index++);
                        comic.Safe_title = reader.GetString(index++);
                        comic.Transcript = reader.GetString(index++);
                        comic.Alt = reader.GetString(index++);
                        comic.Img = reader.GetString(index++);
                        comic.Title = reader.GetString(index++);
                        comic.Day = reader.GetInt32(index++);
                    }
                    comicList.Add(comic);
                }
            }
            catch
            {
                MessageBox.Show("Unable to connect to or make changes to database.  " +
                    "Please make sure the database file exists (XKCDStorage.db) " +
                    "and ensure that the file is not open in another program.");
            }
            return Task.FromResult(comicList);
        }
    }
}
