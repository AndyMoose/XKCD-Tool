using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using XKCDLibrary.Models;
using Dapper;

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

        public async Task<Comic> Insert(Comic xkcd)
        {
            //Dapper implementation
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                using IDbConnection connection = new SqliteConnection(connectionString);

                string paramList = "@Month, @Num, @Link, @Year, @News, @Safe_title, @Transcript, @Alt, @Img, @Title, @Day";
                await connection.ExecuteAsync("INSERT INTO Comics VALUES(" + paramList + ")", xkcd);

                //Add value to num list
                SavedComicList.Add(xkcd.Num);
                UnsavedComicList.Remove(xkcd.Num);

                return xkcd;
            }
            catch
            {
                MessageBox.Show("Unable to connect to or make changes to database.  " +
                    "Please make sure the database file exists (XKCDStorage.db) " +
                    "and ensure that the file is not open in another program.");

                return xkcd;
            };

            //ADO.NET Implementation
            /**
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
            **/
        }

        public async Task<Comic> Delete(Comic xkcd)
        {
            //Dapper Implementation
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                using IDbConnection connection = new SqliteConnection(connectionString);

                await connection.ExecuteAsync("DELETE FROM Comics WHERE Num = @Num", xkcd);

                //Remove num from num list
                SavedComicList.Remove(xkcd.Num);
                UnsavedComicList.Add(xkcd.Num);

                return xkcd;
            }
            catch
            {
                MessageBox.Show("Unable to connect to or make changes to database.  " +
                                "Please make sure the database file exists (XKCDStorage.db) " +
                                "and ensure that the file is not open in another program.");
                return xkcd;
            }

            //ADO.NET Implementation
            /**
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
            **/
        }

        private async Task GenerateSavedComicList()
        {
            //Dapper implementation
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                using IDbConnection connection = new SqliteConnection(connectionString);

                var output = await connection.QueryAsync<int>(sql: "SELECT Num FROM Comics", commandTimeout: COMMAND_TIMEOUT);

                SavedComicList = output.ToList();
            }
            catch
            {
                MessageBox.Show("Unable to connect to or make changes to database.  " +
                    "Please make sure the database file exists (XKCDStorage.db) " +
                    "and ensure that the file is not open in another program.");
            };


            //ADO.NET Implementation
            /**
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
            **/
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

        public async Task<List<Comic>> GetListofSavedComics()
        {
            //Dapper implementation
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                using IDbConnection connection = new SqliteConnection(connectionString);

                var output = (await connection.QueryAsync<Comic>(sql: "SELECT * FROM Comics", commandTimeout: COMMAND_TIMEOUT)).ToList();
                return output;
            }
            catch
            {
                MessageBox.Show("Unable to connect to or make changes to database.  " +
                "Please make sure the database file exists (XKCDStorage.db) " +
                "and ensure that the file is not open in another program.");

                return null;
            }

            //ADO.NET implementation
            /**
            try
            {
                var comicList = new List<Comic>(); 

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
                    var comic = new Comic();
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
           **/
        }
    }
}
