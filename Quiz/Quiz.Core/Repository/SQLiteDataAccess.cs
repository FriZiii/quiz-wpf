using Quiz.Core.ViewModels;
using System.Configuration;
using System.Data.SQLite;

namespace Quiz.Core.Repository
{
    public class SQLiteDataAccess
    {
        public static void CreateQuizz(CreateViewModel model)
        {
            SQLiteConnection conn = new SQLiteConnection(LoadConnectionString());
            conn.Open();

            string sql = "INSERT INTO Quizzes (Name) VALUES (@Name)";

            SQLiteCommand command = new SQLiteCommand(sql, conn);

            command.Parameters.AddWithValue("@Name", model.Name);

            command.ExecuteNonQuery();

            conn.Close();
        }

        private static string LoadConnectionString(string id = "Default" )
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
