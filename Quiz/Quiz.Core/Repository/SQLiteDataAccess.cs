using Quiz.Core.Models;
using Quiz.Core.UserControls.ViewModels;
using Quiz.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;

namespace Quiz.Core.Repository
{
    public class SQLiteDataAccess
    {
        public static void CreateQuizz(CreateViewModel model)
        {
            using (var connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Open();

                //Adding a quiz
                string insertQuizSql = "INSERT INTO Quizzes (Name) VALUES (@name);";
                var insertQuizCommand = new SQLiteCommand(insertQuizSql, connection);
                insertQuizCommand.Parameters.AddWithValue("@name", model.Name);
                insertQuizCommand.ExecuteNonQuery();

                //Getting ID of added quiz
                string selectQuizSql = "SELECT ID FROM Quizzes WHERE Name = @name;";
                var selectQuizCommand = new SQLiteCommand(selectQuizSql, connection);
                selectQuizCommand.Parameters.AddWithValue("@name", model.Name);
                int quizId = Convert.ToInt32(selectQuizCommand.ExecuteScalar());

                //Adding questions and answers
                foreach (var question in model.NewQuestionList)
                {
                    //Adding questions
                    string insertQuestionSql = "INSERT INTO Questions (Text, QuizID) VALUES (@text, @quizId);";
                    var insertQuestionCommand = new SQLiteCommand(insertQuestionSql, connection);
                    insertQuestionCommand.Parameters.AddWithValue("@text", question.Question);
                    insertQuestionCommand.Parameters.AddWithValue("@quizId", quizId);
                    insertQuestionCommand.ExecuteNonQuery();

                    //Getting ID of added questions
                    string selectQuestionSql = "SELECT last_insert_rowid();";
                    var selectQuestionCommand = new SQLiteCommand(selectQuestionSql, connection);
                    int questionId = Convert.ToInt32(selectQuestionCommand.ExecuteScalar());

                    //Adding answers
                    foreach (var answer in question.Answers)
                    {
                        string insertAnswerSql = "INSERT INTO Answers (Text, IsCorrect, QuestionID) VALUES (@text, @isCorrect, @questionId);";
                        var insertAnswerCommand = new SQLiteCommand(insertAnswerSql, connection);
                        insertAnswerCommand.Parameters.AddWithValue("@text", answer.Answer);
                        insertAnswerCommand.Parameters.AddWithValue("@isCorrect", answer.IsCorrect);
                        insertAnswerCommand.Parameters.AddWithValue("@questionId", questionId);
                        insertAnswerCommand.ExecuteNonQuery();
                    }
                }
                connection.Close();
            }
        }

        public static void RemoveQuiz(int quizId)
        {
            using(var connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Open();

                using (var command = new SQLiteCommand("DELETE FROM Answers WHERE QuestionID IN (SELECT ID FROM Questions WHERE QuizID = @quizId)", connection))
                {
                    command.Parameters.AddWithValue("@quizId", quizId);
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand("DELETE FROM Questions WHERE QuizID = @quizId", connection))
                {
                    command.Parameters.AddWithValue("@quizId", quizId);
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand("DELETE FROM Quizzes WHERE ID = @quizId", connection))
                {
                    command.Parameters.AddWithValue("@quizId", quizId);
                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public static List<FoundSingleQuizModel> GetQuizz()
        {
            List<FoundSingleQuizModel> quizzesFound = new List<FoundSingleQuizModel>();
            using (var connection = new SQLiteConnection(LoadConnectionString()))
            {
                connection.Open();

                string selectQuizzesSql = "SELECT ID, Name FROM Quizzes;";
                var selectQuizzesCommand = new SQLiteCommand(selectQuizzesSql, connection);

                using (var reader = selectQuizzesCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int quizId = reader.GetInt32(0);
                        string quizName = reader.GetString(1);
                        var quizInfo = new FoundSingleQuizModel()
                        {
                            ID = quizId,
                            QuizName = quizName,
                        };
                        quizzesFound.Add(quizInfo);
                    }
                }
                connection.Close();
            }
            return quizzesFound;
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
