using System;
using System.Collections.Generic;
using SQLite;

namespace LinqSample001
{
    //テーブル名を指定
    [Table("User")]
    public class UserModel008
    {
        //主キーー　自動採番される
        [PrimaryKey, AutoIncrement, Column("_id")]
        //id列
        public int Id { get; set; }
        //名前列
        public string Name { get; set; }

        /****************************インサートメソッド********************/
        public static void insertUser(string name)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにUserテーブルを作成する
                    db.CreateTable<UserModel008>(); 
                                                    
                    db.Insert(new UserModel008() { Name = name });
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        /********************インサートメソッド（オーバーロード）*********************/
        public static void insertUser(int id, string name)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにUserテーブルを作成する
                    db.CreateTable<UserModel008>(); 
                                                   
                    db.Insert(new UserModel008() { Id = id, Name = name });
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        /*******************セレクトメソッド**************************************/
        public static List<UserModel008> selectUser() 
        {
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {

                try
                {
                    //データベースに指定したSQLを発行
                    return db.Query<UserModel008>("SELECT * FROM [User]"); 

                }
                catch (Exception e)
                {

                    System.Diagnostics.Debug.WriteLine(e);
                    return null;
                }
            }
        }

        /********************デリートメソッド*************************************/
        public static void deleteUser(int id)
        {
            //データベースに接続する
            using (SQLiteConnection db = new SQLiteConnection(App.dbPath))
            {
                try
                {
                    //データベースにUserテーブルを作成する
                    db.CreateTable<UserModel008>();
                    
                    db.Delete<UserModel008>(id);//デリートで渡す値は主キーじゃないといけない説
                    db.Commit();
                }
                catch (Exception e)
                {
                    db.Rollback();
                    System.Diagnostics.Debug.WriteLine(e);
                }
            }
        }

        /*********************Idの降順にソートするメソッド**********************/
        public static void Orderby()
        {
          
        }
    }
}