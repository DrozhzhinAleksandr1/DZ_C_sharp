using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWorkAtTheLesson
{
    static class MyDb
    {
        private static SQLiteConnection DB;

        public static void Go()
        {
            DB = new SQLiteConnection("Data Source =../../db/dish.db");
            DB.Open();

            SQLiteCommand CMD1 = DB.CreateCommand();
            CMD1.CommandText = "create table if not exists Dishes(id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT, idRecipe INTEGER); ";
            CMD1.ExecuteNonQuery();

            SQLiteCommand CMD2 = DB.CreateCommand();
            CMD2.CommandText = "create table if not exists Recipes(id INTEGER PRIMARY KEY AUTOINCREMENT, recipe TEXT, idDish INTEGER); ";
            CMD2.ExecuteNonQuery();

            SQLiteCommand CMD3 = DB.CreateCommand();
            CMD3.CommandText = "create table if not exists Products(id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT); ";
            CMD3.ExecuteNonQuery();

            SQLiteCommand CMD4 = DB.CreateCommand();
            CMD4.CommandText = "create table if not exists Quantities(id INTEGER PRIMARY KEY AUTOINCREMENT," 
                + " idRecipe INTEGER, idProduct INTEGER, numberOfUnits INTEGER, unitsName TEXT);";
            CMD4.ExecuteNonQuery();
        }

        public static void InsertDish(string name, int idRecipe)
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "INSERT INTO Dishes (name, idRecipe) VALUES(@name, @idRecipe);";
            CMD.Parameters.Add("@name", System.Data.DbType.String).Value = name;
            CMD.Parameters.Add("@idRecipe", System.Data.DbType.Int32).Value = idRecipe;
            CMD.ExecuteNonQuery();
        }

        public static List<string> ShowAllDish()
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "SELECT * FROM Dishes name";
            SQLiteDataReader SQL = CMD.ExecuteReader();
            List<string> list = new List<string>();
            while (SQL.Read())
            {
                list.Add((string)SQL[1]);
            }
            return list;
        }
        //public static int DishId()
        //{
        //    int id;
            
        //    return id;
        //}
        public static void InsertRecipe(string recipe, int idDish)
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "INSERT INTO Recipes (recipe, idDish) VALUES(@recipe, @idDish);";
            CMD.Parameters.Add("@recipe", System.Data.DbType.String).Value = recipe;
            CMD.Parameters.Add("@idDish", System.Data.DbType.Int32).Value = idDish;
            CMD.ExecuteNonQuery();
        }

        public static void End()
        {
            DB.Close();
        }
    }
}
