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
using XKCDLibrary.Models;

namespace XKCDLibrary.DataAccess
{
    public class DBDataAccess
    {
        public List<ComicModel> ComicList { get; set; }
        public List<int> Nums { get; set; }

        public DBDataAccess()
        {
            Nums = new List<int>();
            GenerateNumList();
        }

        internal async Task<ComicModel> Insert(ComicModel xkcd)
        {
            try
            {
                using var sqlite = new SqliteConnection();
                sqlite.ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                sqlite.Open();

                using var command = sqlite.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "INSERT INTO Comics VALUES(";

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

                command.CommandTimeout = 5;
                await command.ExecuteNonQueryAsync();

                Nums.Add(xkcd.Num);

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

        internal async Task<ComicModel> Delete(ComicModel xkcd)
        {
            try
            {
                using var sqlite = new SqliteConnection();
                sqlite.ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                sqlite.Open();

                using var command = sqlite.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "DELETE FROM Comics WHERE Num = @Num";

                var param = new SqliteParameter("@Num", SqliteType.Integer)
                {
                    Value = xkcd.Num
                };
                command.Parameters.Add(param);

                command.CommandTimeout = 5;
                await command.ExecuteNonQueryAsync();

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

        internal Task GenerateNumList()
        {
            try
            {
                using var sqlite = new SqliteConnection();
                sqlite.ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                sqlite.Open();

                using var command = sqlite.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT Num FROM Comics";
                command.CommandTimeout = 5;
                SqliteDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Nums.Add(Convert.ToInt32(reader.GetInt32(reader.GetOrdinal("Num"))));
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

        internal Task<List<ComicModel>> GetList()
        {
            var comicList = new List<ComicModel>();

            try
            {
                using (var sqlite = new SqliteConnection())
                {
                    using var command = sqlite.CreateCommand();
                    sqlite.ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
                    sqlite.Open();

                    command.CommandType = System.Data.CommandType.Text;
                    command.CommandText = "SELECT * FROM Comics";
                    command.CommandTimeout = 5;
                    SqliteDataReader reader = command.ExecuteReader();
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
                ComicList = comicList;
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
