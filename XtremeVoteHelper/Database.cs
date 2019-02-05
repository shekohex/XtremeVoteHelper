using System;
using System.Data;
using System.Data.SQLite;
namespace XtremeVoteHelper
{
    public class Database
    {
        private readonly SQLiteConnection conn;
        public Database(string path)
        {
            conn = new SQLiteConnection($"Data Source={path};Version=3;New=False;FailIfMissing=True;Read Only=True");
            conn.Open();
        }

        /// <summary>
        /// Return the player vote points by it's username.
        /// If the player dose not exist in the database, then it will return 0.
        /// </summary>
        /// <param name="username">the player username.</param>
        /// <returns>Vote Points</returns>
        public int GetPlayerVotePoints(string username)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT points FROM 'uvotes' WHERE username = @username LIMIT 1";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Prepare();
            var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                var points = reader.GetOrdinal("points");
                return reader.GetInt32(points);
            }
            else
            {

                return 0;
            }
        }

        ~Database()
        {
            conn.Close();
        }
    }
}
