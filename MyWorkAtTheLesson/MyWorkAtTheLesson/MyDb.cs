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
            CMD1.CommandText = "create table if not exists Dishes(id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT); ";
            CMD1.ExecuteNonQuery();

            SQLiteCommand CMD2 = DB.CreateCommand();
            CMD2.CommandText = "create table if not exists Recipes(id INTEGER PRIMARY KEY AUTOINCREMENT, recipe TEXT, idDish INTEGER); ";
            CMD2.ExecuteNonQuery();
            
            SQLiteCommand CMD4 = DB.CreateCommand();
            CMD4.CommandText = "create table if not exists Quantities(id INTEGER PRIMARY KEY AUTOINCREMENT," 
                + " idRecipe INTEGER, product TEXT, numberOfUnits INTEGER, unitsName TEXT);";
            CMD4.ExecuteNonQuery();
        }

        public static void InsertDish(string name)
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "INSERT INTO Dishes (name) VALUES(@name);";
            CMD.Parameters.Add("@name", System.Data.DbType.String).Value = name;
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

        public static string DishId(string nameDish)
        {
            string id;
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "SELECT id FROM Dishes WHERE name = @name;";
            CMD.Parameters.Add("@name", System.Data.DbType.String).Value = nameDish;
            SQLiteDataReader SQL = CMD.ExecuteReader();
            if (SQL.HasRows)
            {
                SQL.Read();
                id = "" + SQL[0];
                return id;
            }
            return "" + 0;
        }

        public static void InsertRecipe(string recipe, int idDish)
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "INSERT INTO Recipes (recipe, idDish) VALUES(@recipe, @idDish);";
            CMD.Parameters.Add("@recipe", System.Data.DbType.String).Value = recipe;
            CMD.Parameters.Add("@idDish", System.Data.DbType.Int32).Value = idDish;
            CMD.ExecuteNonQuery();
        }
        public static string RecipeId(string nameRecipe)
        {
            string id;
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "SELECT id FROM Recipes WHERE recipe = @recipe;";
            CMD.Parameters.Add("@recipe", System.Data.DbType.String).Value = nameRecipe;
            SQLiteDataReader SQL = CMD.ExecuteReader();
            SQL.Read();
            id = "" + SQL[0];
            return id;
        }
        public static string RecipeIdByDishId(int dishId)
        {
            string id;
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "SELECT id FROM Recipes WHERE idDish = @dishId;";
            CMD.Parameters.Add("@dishId", System.Data.DbType.Int32).Value = dishId;
            SQLiteDataReader SQL = CMD.ExecuteReader();
            SQL.Read();
            id = "" + SQL[0];
            return id;
        }
        public static string GetRecipe(int id)
        {
            string text;
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "SELECT recipe FROM Recipes WHERE id = @id;";
            CMD.Parameters.Add("@id", System.Data.DbType.Int32).Value = id;
            SQLiteDataReader SQL = CMD.ExecuteReader();
            SQL.Read();
            text = "" + SQL[0];
            return text;
        }
        public static void InsertQuantities(int idRecipe, string nameProduct, int numberOfUnit, string unitsName)
        {
            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "INSERT INTO Quantities (idRecipe, product, numberOfUnits, unitsName)" +
                " VALUES(@idRecipe, @nameProduct, @numberOfUnit, @unitsName);";
            CMD.Parameters.Add("@idRecipe", System.Data.DbType.Int32).Value = idRecipe;
            CMD.Parameters.Add("@nameProduct", System.Data.DbType.String).Value = nameProduct;
            CMD.Parameters.Add("@numberOfUnit", System.Data.DbType.Int32).Value = numberOfUnit;
            CMD.Parameters.Add("@unitsName", System.Data.DbType.String).Value = unitsName;
            CMD.ExecuteNonQuery();
        }
        public static List<Tuple<string, int, string>> GetQuantities(int id)
        {
            List<Tuple<string, int, string>> list = new List<Tuple<string, int, string>>();

            SQLiteCommand CMD = DB.CreateCommand();
            CMD.CommandText = "SELECT * FROM Quantities WHERE idRecipe = @recipe;";
            CMD.Parameters.Add("@recipe", System.Data.DbType.Int32).Value = id;
            SQLiteDataReader SQL = CMD.ExecuteReader();
            if (SQL.HasRows)
            {
                while (SQL.Read())
                {
                    list.Add(new Tuple<string, int, string>("" + SQL[2], int.Parse("" + SQL[3]), "" + SQL[4]));
                }
            }           
            return list;
        }
        public static void ClearDB()
        {
            SQLiteCommand CMD1 = DB.CreateCommand();
            SQLiteCommand CMD2 = DB.CreateCommand();
            SQLiteCommand CMD3 = DB.CreateCommand();
            CMD1.CommandText = "drop table if exists Quantities;";
            CMD2.CommandText = "drop table if exists Dishes;";
            CMD3.CommandText = "drop table if exists Recipes;";
            CMD1.ExecuteNonQuery();
            CMD2.ExecuteNonQuery();
            CMD3.ExecuteNonQuery();
        }
        public static void End()
        {
            //ClearDB();
            DB.Close();
        }
    }
}
